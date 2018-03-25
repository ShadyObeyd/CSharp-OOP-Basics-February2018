using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const double HEAL_POINTS = 20;

        public HealthPotion() : base(5)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += HEAL_POINTS;

            if (character.Health >= character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
