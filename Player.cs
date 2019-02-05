using System;
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
        
        //TODO - chg to be private?
        public List<Customer> customers;

        // Store historical info needed for day wrapup & final wrapup
        public List<ResultOfDay> resultsOfDays;
        public ResultOfDay resultOfDay;

        public Pitchers pitchers;

        public Player(Store store, string greeting, double initialInvestment)
        {
            moneyOnHand = initialInvestment;

            name = UserInterface.promptForStringInput($"{greeting}Enter this player's name:");
            recipe = new Recipe();
            inventory = new Recipe(0, 0, 0, 0, UserInterface.numberOfServingsPerPitcher);
            // Get the prices from the store:  
            // loop through ingredients & get & set the price from the store
            for (int i = 0; i < recipe.ingredients.Count; i++) //  each (Ingredient ingredient in recipe.ingredients)
            {
                recipe.ingredients[i].PriceForQuantity = store.inventory.ingredients[i].PriceForQuantity;
                recipe.ingredients[i].QuantityInPrice = store.inventory.ingredients[i].QuantityInPrice;
            }
        }

        //public void addNewResultsOfDay(int dayNumber)
        //{
        //    resultOfDays.Add(new ResultOfDay(dayNumber));
        //}

        public void ResetForNewDay(int dayNumber)
        {
            // create new results for thisPlayer
            resultOfDay = new ResultOfDay(dayNumber, moneyOnHand);
            resultsOfDays.Add(resultOfDay);
            Pitchers pitchers = new Pitchers(recipe, inventory, resultOfDay);

        }
        public int sellLemonadeForDay(Day day)
        {
            Console.WriteLine("In Sales");
            // moved to player.resetForNewDay
            //// create new results for thisPlayer
            //ResultOfDay resultOfDay = new ResultOfDay(day.dayNumber);
            //Pitchers pitchers = new Pitchers(recipe, inventory); //, resultOfDay);

            resultOfDay.CostPerPitcher = getCostPerPitcher();
            // handled in showprepscreen
            //resultOfDay.PricePerCup = pricePerCupOfLemonade;
            // handled in game.playgame, after customers are created
            //resultOfDay.PotentialCustomers = day.NumberOfPotentialCustomers;

            // TODO - find out where handled
            // handled at ??? 
            //resultOfDay.MoneyOnHandAtBOD = moneyOnHand;
            
            // moved to game.playGame, after weather forecast created so it can be used in showPrepScreen
            //resultOfDay.WeatherForecastTemp = day.ForecastTemperature;
            //resultOfDay.WeatherForecastConditionNumber = day.ForecastConditionNumber;
            //resultOfDay.WeatherForecastChanceOfRainPercent = day.RainChancePercent;

            // moved to game.playGame, after actual weather is created so it can be used in showResults
            //resultOfDay.WeatherActualTemp = day.ActualTemperature;
            //resultOfDay.WeatherActualConditionNumber = day.ActualConditionNumber;


            Random randomGenerator = new Random();
            int salesCount = 0;
            foreach (Customer thisCustomer in day.masterListOfCustomersForDay)
            {
                int dieRoll = randomGenerator.Next(1, 7);  // produces roll 1 - 6
                thisCustomer.dieRoll = dieRoll;
                Console.WriteLine($"dieRoll = {dieRoll}, score = {thisCustomer.score}, purchased = {dieRoll <= thisCustomer.score}");
                if (dieRoll <= thisCustomer.score)
                {
                    thisCustomer.dieRoll = dieRoll;
                    // TODO - change this to more fool-proof method
                    thisCustomer.IsActualCustomer = true;
                    soldAnotherOne(resultOfDay, pitchers);
                    salesCount++;
                        //resultOfDay.NumberOfCupsSold++;
                        //resultOfDay.SalesIncomeForDay = resultOfDay.SalesIncomeForDay + pricePerCupOfLemonade;
                }
                else
                {
                    Console.WriteLine("Not a customer!");
                }
                // if we ran out, exit 
                if (resultOfDay.SoldOut)
                {
                    break;
                }
            }// foreach customer
            // TODO - change player object to hold whatever we need to save
            //      for the day's results screen & final wrap-up screen
           // holdThis = salesCount;

            // populate the rest of resultOfDay
             // TODO - add pitcher, #cupsRemaining
            // move to pitchers
                //resultOfDay.numberOfCupsRemainingInPitcher = pitchers.cupsRemaining;
                //resultOfDay.ExpensesForDay = getCostPerPitcher() * pitchers.numberMade;
            
            //resultOfDay.ProfitForDay is a property calculation in resultOfDay class



            // add resultOfDay to list resultsOfDays
            resultsOfDays.Add(resultOfDay);
            return salesCount;
        }

        public void soldAnotherOne(ResultOfDay resultOfDay, Pitchers pitchers)
        {   
            resultOfDay.NumberOfCupsSold++;
            resultOfDay.SalesIncomeForDay +=  resultOfDay.PricePerCup;
            //moneyOnHand += resultOfDay.PricePerCup;
            resultOfDay.MoneyOnHandAtEOD += resultOfDay.PricePerCup;

            Console.WriteLine("check the above value for addition");
            // decrement cups in pitcher count; if 0, 
            // make new pitcher if you can, 
            // if not, set SoldOut = true;
            

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
        
        // moved to pitchers 
        //public int getMaxNumberOfPitchers()
        //{
        //    // calculate the number of pitchers you can make based on current inventory
        //    //foreach (Ingredient ingredient in recipe.ingredients)
        //    int maxPitchers = 0;
        //    //for (int i = 0; i < recipe.ingredients.Count; i++)
        //    int i = 0;
        //    do
        //    {
        //        // numberPerRecipe, numberOnHand
        //        int numberPerRecipe = recipe.ingredients[i].quantity;
        //        int numberOnHand = inventory.ingredients[i].quantity;
        //        int quotient = numberOnHand / numberPerRecipe;
        //        if (quotient < maxPitchers || i == 0)
        //        {
        //            maxPitchers = quotient;
        //        }
        //        if (maxPitchers == 0)
        //        {
        //            return 0;
        //        }
        //        i++;
        //    }
        //    while (i < recipe.ingredients.Count);
        //    return maxPitchers;
        //}
        public void PurchaseItem(int itemNumber, Store store)
        {
            // get the player's quantity, then check if he/she has enough money;
            // if so, change the inventory & reduce his moneyOnHand
            int quantityToPurchase = UserInterface.promptForIntegerInput(
                    $"Enter the quantity of {store.inventory.ingredients[itemNumber].quantityDescription} to purchase for {store.inventory.ingredients[itemNumber].PriceForQuantity.ToString("C")} each:",
                    0, 80);
            // check that the player has enough money
            if (moneyOnHand >= ((double)quantityToPurchase * store.inventory.ingredients[itemNumber].PriceForQuantity))
            {
                // Add the quantityToPurchase * quantityInPrice to the inventory
                inventory.ingredients[itemNumber].quantity =
                    inventory.ingredients[itemNumber].quantity +
                    (quantityToPurchase * store.inventory.ingredients[itemNumber].QuantityInPrice);
                // Deduct the amount from his moneyOnHand
                moneyOnHand = moneyOnHand -
                    ((double)quantityToPurchase * store.inventory.ingredients[itemNumber].PriceForQuantity);
                Console.WriteLine("purchase complete");
            }
            else
            {
                UserInterface.displayMessage("Sorry, you don't have enought money to buy that many.", true);
            }
        }
    }
}
