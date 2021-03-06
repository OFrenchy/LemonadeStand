﻿using System;
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
        public Inventory inventory;

        public Store()
        {
            inventory = new Inventory();// 10000, 10000, 100000, 100000, 0);
            inventory.addItem(new Lemon("lemon", 10000));
            inventory.addItem(new Sugar("sugar", 10000));
            inventory.addItem(new Ice("ice", 100000));
            inventory.addItem(new Cup("cup", 100000));
            inventory.items[0].PriceForQuantity = priceLemon; //  0.20;   // lemons
            inventory.items[0].QuantityInPrice = 1;       // each
            inventory.items[0].quantityDescription = "lemons";
            inventory.items[1].PriceForQuantity = priceSugar4lbs10Cups; // 2.30;   // sugar
            inventory.items[1].QuantityInPrice = 10;      // cups
            inventory.items[1].quantityDescription = "4 lb. packages of sugar (approx. 10 cups)";
            inventory.items[2].PriceForQuantity = priceIce5lbs;  // 1.50;   // ice
            inventory.items[2].QuantityInPrice = 250;     // cubes
            inventory.items[2].quantityDescription = "5 lb. bags of ice";
            inventory.items[3].PriceForQuantity = price100Cups;  // 1.50;   // cups
            inventory.items[3].QuantityInPrice = 100;     // cups
            inventory.items[3].quantityDescription = "bags of 100 cups";
        }
    }
}