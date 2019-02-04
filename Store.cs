using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Store
    {
        // set price of ingredients.  We will assume the store has unlimited quantities.
        private double priceLemon = 0.20;
        private double priceSugar4lbs10Cups = 1.75;
        private double priceIce5lbs = 1.50;
        private double price100Cups = 1.50;
        
        public Recipe inventory;

        public Store()
        {
            inventory = new Recipe(10000, 10000, 100000, 100000);
            // inventory = new Recipe(10000, 10000, 100000, 100000);
            inventory.ingredients[0].PriceForQuantity = priceLemon; //  0.20;   // lemons
            inventory.ingredients[0].QuantityInPrice = 1;       // each
            inventory.ingredients[0].quantityDescription = "lemons";
            inventory.ingredients[1].PriceForQuantity = priceSugar4lbs10Cups; // 2.30;   // sugar
            inventory.ingredients[1].QuantityInPrice = 10;      // cups
            inventory.ingredients[1].quantityDescription = "4 lb. packages of sugar (approx. 10 cups)";
            inventory.ingredients[2].PriceForQuantity = priceIce5lbs;  // 1.50;   // ice
            inventory.ingredients[2].QuantityInPrice = 250;     // cubes
            inventory.ingredients[2].quantityDescription = "5 lb. bags of ice";
            inventory.ingredients[3].PriceForQuantity = price100Cups;  // 1.50;   // cups
            inventory.ingredients[3].QuantityInPrice = 100;     // cups
            inventory.ingredients[3].quantityDescription = "bags of 100 cups";

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