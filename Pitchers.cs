using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Pitchers
    {
        private int servingsPerPitcher = -1;
        //private int cupsRemainingInPitcher = 0;

        private Recipe recipe;
        private Recipe inventory;

        ResultOfDay resultOfDay; // = new ResultOfDay()

        public Pitchers(Recipe recipe, Recipe inventory, ResultOfDay resultOfDay)
        {
            servingsPerPitcher = recipe.servings;
            this.recipe = recipe;
            this.inventory = inventory;

            this.servingsPerPitcher = recipe.servings; // if 0, put this back in arguments:  int numberOfServingsPerPitcher,
        }


        public int CupsRemainingInPitcher
        {
            get => resultOfDay.NumberOfCupsRemainingInPitcher;
            //set
            //{
            //}
        }

        public bool MakeAnotherPitcher()
        {
            // if there is enough for another pitcher, make one, 
            //  otherwise set soldout, soldoutof, and return false
            if (getMaxNumberOfPitchers() > 0)
            {
                // TODO - 
                // decrease inventory by recipe amounts

                decreaseInventoryByOneRecipe();

                resultOfDay.NumberOfCupsRemainingInPitcher = recipe.servings;
                resultOfDay.NumberOfPitchersMade++;

                // add # of servings to resultOfDay.servingsin pitcher
                // increment # pitchers made in 
                return true;
            }
            else
            {
                resultOfDay.SoldOut = true;
                return false;
            }
        }

        public void decreaseInventoryByOneRecipe()
        {
            for (int i = 0; i < inventory.ingredients.Count; i++)
            {
                inventory.ingredients[i].quantity -= recipe.ingredients[i].quantity;
            }
        }
        public void SoldCup()
        {
            resultOfDay.NumberOfCupsRemainingInPitcher-- ;

            resultOfDay.MoneyOnHandAtEOD += resultOfDay.PricePerCup;

            //throw new System.NotImplementedException();
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
                    resultOfDay.SoldOutOf = "";
                }
                if (maxPitchers == 0)
                {
                    // set resultOfDay.SoldOutOf to the ingredient of which we don't have enough 
                    resultOfDay.SoldOutOf = inventory.ingredients[i].name;
                    return 0;
                }
                i++;
            }
            while (i < recipe.ingredients.Count);
            return maxPitchers;
        }
    }
}
