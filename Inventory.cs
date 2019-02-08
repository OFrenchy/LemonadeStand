using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Inventory
    {
        public List<Item> items;
        public Inventory()
        {
            items = new List<Item>();
        }
        public void addItem(Item item)
        {
            items.Add(item);
        }
    }
}