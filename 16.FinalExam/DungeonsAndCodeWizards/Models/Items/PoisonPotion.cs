using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const double POSION_DMG = 20;

        public PoisonPotion() : base(5)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= POSION_DMG;

            if (character.Health <= 0)
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
