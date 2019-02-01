using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Store
    {
        // set price of ingredients.  We will assume the store has unlimited quantities.
        private double priceLemon = 0.30;
        private double priceSugar4lbs10Cups = 2.30;
        private double price50Cups = 1.50;
        private double priceIce5lbs = 1.50;

        public Recipe inventory;

        public Store()
        {
            inventory = new Recipe(10000, 10000, 100000, 100000);
            // inventory = new Recipe(10000, 10000, 100000, 100000);
            inventory.ingredients[0].PriceForQuantity = 0.20;   // lemons
            inventory.ingredients[0].QuantityInPrice = 1;       // each
            inventory.ingredients[1].PriceForQuantity = 2.30;   // sugar
            inventory.ingredients[1].QuantityInPrice = 10;      // cups
            inventory.ingredients[2].PriceForQuantity = 1.50;   // ice
            inventory.ingredients[2].QuantityInPrice = 250;     // cubes
            inventory.ingredients[3].PriceForQuantity = 1.50;   // cups
            inventory.ingredients[3].QuantityInPrice = 100;     // cups



        }
        //public Ingredients Ingredients
        //{
        //    get => default(Ingredients);
        //    set
        //    {
        //    }
        //}
    }
}