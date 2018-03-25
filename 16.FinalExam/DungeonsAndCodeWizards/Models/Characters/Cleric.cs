using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, health: 50, armor: 25, abilityPoints: 40, bag: new Backpack(), faction: faction)
        {

        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.AliveCheck();
            character.AliveCheck();

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;

            if (character.Health >= character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
