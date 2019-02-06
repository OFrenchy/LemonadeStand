using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Pitchers
    {
        //private int servingsPerPitcher = -1;
        ////private int cupsRemainingInPitcher = 0;

        //private LemonadeRecipe recipe;
        //private Inventory inventory;

        //ResultOfDay resultOfDay; // = new ResultOfDay()

        //public Pitchers(LemonadeRecipe recipe, Inventory inventory, ResultOfDay resultOfDay)
        //{
        //    servingsPerPitcher = recipe.servings;
        //    this.recipe = recipe;
        //    this.inventory = inventory;
            
        //    this.servingsPerPitcher = recipe.servings; // if 0, put this back in arguments:  int numberOfServingsPerPitcher,
        //    this.resultOfDay = resultOfDay;
        //}


        //public int CupsRemainingInPitcher
        //{
        //    get => resultOfDay.NumberOfCupsRemainingInPitcher;
        //    //set
        //    //{
        //    //}
        //}
        //public bool MakeAnotherPitcher()
        //{
        //    // if there is enough for another pitcher, make one, 
        //    //  otherwise set soldout, soldoutof, and return false
        //    if (getMaxNumberOfPitchers() > 0)
        //    {
        //        // TODO - 
        //        // decrease inventory by recipe amounts
        //        decreaseInventoryByOneRecipe();

        //        resultOfDay.NumberOfCupsRemainingInPitcher = recipe.servings;
        //        resultOfDay.NumberOfPitchersMade++;

        //        // add # of servings to resultOfDay.servingsin pitcher
        //        // increment # pitchers made in 
        //        return true;
        //    }
        //    else
        //    {
        //        resultOfDay.SoldOut = true;
        //        return false;
        //    }
        //}

        //public void decreaseInventoryByOneRecipe()
        //{
        //    for (int i = 0; i < inventory.items.Count - 1; i++)
        //    {
        //        // do not decrease cups until you sell a cup
        //        inventory.items[i].quantity -= recipe.items[i].quantity;
        //    }
        //}
        //public void SoldCup()
        //{
        //    resultOfDay.NumberOfCupsRemainingInPitcher-- ;

        //    resultOfDay.MoneyOnHandAtEOD += resultOfDay.PricePerCup;

        //    // TODO - decrement inventory of cups by 1
        //    inventory.items[4].quantity-- ;

        //    //throw new System.NotImplementedException();
        //}

        //public int getMaxNumberOfPitchers()
        //{
        //    // calculate the number of pitchers you can make based on current inventory
        //    int maxPitchers = 0;
        //    int i = 0;
        //    do
        //    {
        //        // numberPerRecipe, numberOnHand
        //        int numberPerRecipe = recipe.items[i].quantity;
        //        int numberOnHand = inventory.items[i].quantity;
        //        int quotient = numberOnHand / numberPerRecipe;
        //        if (quotient < maxPitchers || i == 0)
        //        {
        //            maxPitchers = quotient;
        //            resultOfDay.SoldOutOf = "";
        //        }
        //        if (maxPitchers == 0)
        //        {
        //            // set resultOfDay.SoldOutOf to the item of which we don't have enough 
        //            resultOfDay.SoldOutOf = inventory.items[i].name;
        //            return 0;
        //        }
        //        i++;
        //    }
        //    while (i < recipe.items.Count);
        //    return maxPitchers;
        //}
    }
}
