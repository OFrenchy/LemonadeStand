using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Item
    {
        public string name;
        public int quantity;
        public string quantityDescription;
        private double priceForQuantity;
        private int quantityInPrice;
        
        public Item(string name, int quantity = 0)
        {
            this.name = name;
            this.quantity = quantity;
        }
        public double PriceForQuantity  // allow to be set once
        {
            get => priceForQuantity;
            set
            {
                if (priceForQuantity == 0.00)
                {
                    priceForQuantity = value;
                }
            }
        }
        public int QuantityInPrice  // allow to be set once
        {
            get => quantityInPrice;
            set
            {
                if (quantityInPrice == 0)
                {
                    quantityInPrice = value;
                }
            }
        }
        public double GetPriceEach()
        {
            return priceForQuantity / quantityInPrice;
        }
    }
}