using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Ingredient
    {
        public string name;
        public int quantity;
        public string quantityDescription;

        private double priceForQuantity;
        private int quantityInPrice;
        
        public Ingredient(string name, int quantity = 0)
        {
            this.name = name;
        }

        public double PriceForQuantity
        {
            get => priceForQuantity;
            // allow priceForQuantity to be set once
            set
            {
                if (priceForQuantity != 0)
                {
                    priceForQuantity = value;
                }
            }
        }
        public int QuantityInPrice
        {
            get => quantityInPrice;
            // allow quantityInPrice to be set once
            set
            {
                if (quantityInPrice != 0)
                {
                    quantityInPrice = value;
                }
            }
        }

        public double GetPriceEach()
        {
            return PriceForQuantity / quantityInPrice;
        }

            
        //public int PriceEach
        //{
        //    get => default(int);
        //    set
        //    {
        //    }
        //}
    }
}