using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private List<Character> party;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private Stack<Item> itemPool;
        private int turnCntr;
        private List<Character> aliveChars;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.itemPool = new Stack<Item>();
            this.turnCntr = 0;
            this.aliveChars = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            string inputFaction = args[0];
            string characterType = args[1];
            string characterName = args[2];

            Character character = characterFactory.CreateCharacter(inputFaction, characterType, characterName);

            this.party.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemFactory.CreateItem(itemName);

            this.itemPool.Push(item);

            return $"{item} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            this.CheckCharacter(characterName);

            Character character = party.First(c => c.Name == characterName);

            if (!itemPool.Any())
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = itemPool.Pop();

            character.Bag.AddItem(item);

            return $"{characterName} picked up {item}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            this.CheckCharacter(characterName);

            Character character = this.party.First(c => c.Name == characterName);

            Item item = character.Bag.GetItem(itemName);

            item.AffectCharacter(character);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            CheckCharacter(giverName);
            CheckCharacter(receiverName);

            Character giver = this.party.First(c => c.Name == giverName);
            Character receiver = this.party.First(c => c.Name == receiverName);

            Item item = giver.Bag.GetItem(itemName);

            item.AffectCharacter(receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            CheckCharacter(giverName);
            CheckCharacter(receiverName);

            Character giver = this.party.First(c => c.Name == giverName);
            Character receiver = this.party.First(c => c.Name == receiverName);

            Item item = giver.Bag.GetItem(itemName);

            receiver.Bag.AddItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Character character in party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                builder.AppendLine(character.ToString());
            }

            return builder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            CheckCharacter(attackerName);
            CheckCharacter(receiverName);

            Character attacker = this.party.First(c => c.Name == attackerName);
            Character receiver = this.party.First(c => c.Name == receiverName);

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            Warrior warrior = (Warrior)attacker;

            warrior.Attack(receiver);

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                builder.AppendLine($"{receiver.Name} is dead!");
            }

            return builder.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            CheckCharacter(healerName);
            CheckCharacter(receiverName);

            Character healer = this.party.First(c => c.Name == healerName);
            Character receiver = this.party.First(c => c.Name == receiverName);

            if (healer.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            Cleric cleric = (Cleric)healer;

            cleric.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            this.aliveChars = party.Where(c => c.IsAlive).ToList();

            StringBuilder builder = new StringBuilder();

            foreach (Character character in aliveChars)
            {
                double hpBeforeRest = character.Health;
                character.Rest();
                builder.AppendLine($"{character.Name} rests ({hpBeforeRest} => {character.Health})");
            }

            if (aliveChars.Count == 1)
            {
                this.turnCntr++;
            }

            return builder.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (this.aliveChars.Count == 1 && this.turnCntr == 2)
            {
                return true;
            }
            return false;
        }

        private void CheckCharacter(string name)
        {
            if (!this.party.Any(c => c.Name == name))
            {
                throw new ArgumentException($"Character {name} not found!");
            }
        }

    }
}
