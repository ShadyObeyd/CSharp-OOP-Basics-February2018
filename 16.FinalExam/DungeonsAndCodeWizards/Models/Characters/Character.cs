using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.BaseHealth = health;
            this.Armor = armor;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health { get; set; }

        public double BaseArmor { get; protected set; }

        public double Armor { get; set; }

        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }

        public Faction Faction { get; protected set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier => 0.2;

        public string Status => IsAlive ? "Alive" : "Dead";

        public void AliveCheck()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void TakeDamage(double hitpoints)
        {
            this.AliveCheck();

            if (this.Armor >= hitpoints)
            {
                this.Armor -= hitpoints;
            }
            else
            {
                double dmgToTake = hitpoints - this.Armor;
                this.Armor = 0;

                this.Health -= dmgToTake;

                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            this.AliveCheck();

            this.Health += (this.BaseHealth * this.RestHealMultiplier);

            if (this.Health > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
        }

        public void UseItem(Item item)
        {
            this.AliveCheck();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.AliveCheck();
            character.AliveCheck();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.AliveCheck();
            character.AliveCheck();

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            AliveCheck();
            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {Status}";
        }
    }
}