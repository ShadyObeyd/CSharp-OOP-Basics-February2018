using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string inputFaction, string characterType, string characterName)
        {
            if (inputFaction != "CSharp" && inputFaction != "Java")
            {
                throw new ArgumentException($"Invalid faction \"{inputFaction}\"!");
            }

            Faction faction = Enum.Parse<Faction>(inputFaction);

            if (characterType == "Warrior")
            {
                return new Warrior(characterName, faction);
            }
            else if (characterType == "Cleric")
            {
                return new Cleric(characterName, faction);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
        }
    }
}