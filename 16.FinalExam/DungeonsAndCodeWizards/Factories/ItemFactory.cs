using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            if (itemName == "HealthPotion")
            {
                return new HealthPotion();
            }
            else if (itemName == "PoisonPotion")
            {
                return new PoisonPotion();
            }
            else if (itemName == "ArmorRepairKit")
            {
                return new ArmorRepairKit();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
        }
    }
}