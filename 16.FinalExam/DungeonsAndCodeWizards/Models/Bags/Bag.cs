using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; protected set; }

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string itemName)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!this.items.Any(i => i.GetType().Name == itemName))
            {
                throw new ArgumentException($"No item with name {itemName} in bag!");
            }

            Item item = this.items.First(i => i.GetType().Name == itemName);

            this.items.Remove(item);

            return item;
        }
    }
}
