﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        // class - … Is A …
        // member variables - … Has A …
        
        // TODO - change to private with property gets/sets
        public string name;
        public Recipe recipe;
        public Recipe inventory;
        public double moneyOnHand;
        public double pricePerCupOfLemonade = 0.25;

        public Player(Store store, string greeting, double initialInvestment)
        {
            moneyOnHand = initialInvestment;
            name = UserInterface.promptForStringInput($"{greeting}Enter this player's name:");
            recipe = new Recipe();
            inventory = new Recipe(0, 0, 0, 0);
            // Get the prices from the store:  
            // loop through ingredients & get & set the price from the store
            for (int i = 0; i < recipe.ingredients.Count; i++) //  each (Ingredient ingredient in recipe.ingredients)
            {
                recipe.ingredients[i].PriceForQuantity = store.inventory.ingredients[i].PriceForQuantity;
                recipe.ingredients[i].QuantityInPrice = store.inventory.ingredients[i].QuantityInPrice;
            }
        }

        
        //public double moneyOnHand
        //{
        //    get => default(int);
        //    set
        //    {
        //    }
        //}

        //// member methods - … Can Do …
        //public virtual int MakeSelection(int rangeZeroBased)
        //{
        //    // prompt for selection
        //    string message = name + "'s turn: Please make a selection, enter 1 for Rock, 2 for Paper, " +
        //        "3 for Scissors, 4 for Lizard, or 5 for Spock: ";
        //    return Convert.ToInt32(UserInterface.pickWholeNumberOneThrough(5, message, false) - 1);
        //}

        public double getCostPerPitcher()
        {
            // loop through ingredients, multiplying GetPriceEach by quantity &
            // adding to subtotal for pitcher
            double costPerPitcher = 0;
            foreach (Ingredient ingredient in recipe.ingredients)
            {
                costPerPitcher = costPerPitcher + (ingredient.GetPriceEach() * ingredient.quantity);
            }
            return costPerPitcher;
        }
        public int getMaxNumberOfPitchers()
        {
            // calculate the number of pitchers you can make based on current inventory
            //foreach (Ingredient ingredient in recipe.ingredients)
            int maxPitchers = 0;
            //for (int i = 0; i < recipe.ingredients.Count; i++)
            int i = 0;
            do
            {
                // numberPerRecipe, numberOnHand
                int numberPerRecipe = recipe.ingredients[i].quantity;
                int numberOnHand = inventory.ingredients[i].quantity;
                int quotient = numberOnHand / numberPerRecipe;
                if (quotient < maxPitchers || i == 0)
                {
                    maxPitchers = quotient;
                }
                if (maxPitchers == 0)
                {
                    return 0;
                }
                i++;
            }
            while (i < recipe.ingredients.Count);
            return maxPitchers;
        }
    }
}
