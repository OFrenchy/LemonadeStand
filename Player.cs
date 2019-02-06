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
        public LemonadeRecipe recipe;
        public Inventory inventory;
        public double moneyOnHand;
        
        //TODO - chg to be private?
        public List<Customer> customers;

        // Store historical info needed for day wrapup & final wrapup
        public List<ResultOfDay> resultsOfDays= new List<ResultOfDay>();
        public ResultOfDay resultOfDay;

        //public Pitchers pitchers;

        public Player(Store store, string greeting, double initialInvestment)
        {
            moneyOnHand = initialInvestment;

            name = UserInterface.promptForStringInput($"{greeting}Enter this player's name:");
            recipe = new LemonadeRecipe();
            inventory = new Inventory();// 0, 0, 0, 0, UserInterface.numberOfServingsPerPitcher);
            inventory.addItem(new Lemon("lemon", 0));
            inventory.addItem(new Sugar("sugar", 0));
            inventory.addItem(new Ice("ice", 0));
            inventory.addItem(new Cup("cup", 0));

            // Get the prices from the store:  
            // loop through items & get & set the price from the store
            for (int i = 0; i < recipe.items.Count; i++) 
            {
                recipe.items[i].PriceForQuantity = store.inventory.items[i].PriceForQuantity;
                recipe.items[i].QuantityInPrice = store.inventory.items[i].QuantityInPrice;
            }
            for (int i = 0; i < inventory.items.Count; i++)
            {
                inventory.items[i].PriceForQuantity = store.inventory.items[i].PriceForQuantity;
                inventory.items[i].QuantityInPrice = store.inventory.items[i].QuantityInPrice;
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
            //Pitchers pitchers = new Pitchers(recipe, inventory, resultOfDay);
            //pitchers = new Pitchers(recipe, inventory, resultOfDay);

        }
        public int sellLemonadeForDay(Day day)
        {
            Console.WriteLine("In Sales");
            // moved to player.resetForNewDay
            //// create new results for thisPlayer
            //ResultOfDay resultOfDay = new ResultOfDay(day.dayNumber);
            //Pitchers pitchers = new Pitchers(recipe, inventory); //, resultOfDay);

            resultOfDay.MoneyOnHandAtEOD = moneyOnHand;

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

            // Make the first pitcher of the day
            MakeAnotherPitcher();

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
                    recordSale(resultOfDay);//, pitchers);
                    salesCount++;
                    //resultOfDay.NumberOfCupsSold++;
                    //resultOfDay.SalesIncomeForDay = resultOfDay.SalesIncomeForDay + pricePerCupOfLemonade;
                    
                    // if pitcher is empty, make new pitcher if you can, 
                    // if not, set SoldOut = true;
                    if (CupsRemainingInPitcher == 0)
                    {
                        MakeAnotherPitcher();
                    }
                }
                //else
                //{
                //    Console.WriteLine("Not a customer!");
                //}
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

        public void recordSale(ResultOfDay resultOfDay)//, Pitchers pitchers)
        {   
            resultOfDay.NumberOfCupsSold++;
            resultOfDay.SalesIncomeForDay +=  resultOfDay.PricePerCup;
            //moneyOnHand += resultOfDay.PricePerCup;
            resultOfDay.MoneyOnHandAtEOD += resultOfDay.PricePerCup;
            // decrement inventory of cups by 1
            inventory.items[3].quantity--;
            // increase expenses by the cost of 1 physical cup
            resultOfDay.ExpensesForDay += inventory.items[3].GetPriceEach();

            // decrement cups in pitcher count; 
            resultOfDay.NumberOfCupsRemainingInPitcher--;
            
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
                // increase expenses in the ledger
                resultOfDay.ExpensesForDay += getCostPerPitcher();

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
            for (int i = 0; i < inventory.items.Count - 1; i++)
            {
                // do not decrease cups until you sell a cup
                inventory.items[i].quantity -= recipe.items[i].quantity;
            }
        }
        

        public int getMaxNumberOfPitchers()
        {
            // calculate the number of pitchers you can make based on current inventory
            int maxPitchers = 0;
            int i = 0;
            do
            {
                // numberPerRecipe, numberOnHand
                int numberPerRecipe = recipe.items[i].quantity;
                int numberOnHand = inventory.items[i].quantity;
                int quotient = numberOnHand / numberPerRecipe;
                if (quotient < maxPitchers || i == 0)
                {
                    maxPitchers = quotient;
                    resultOfDay.SoldOutOf = "";
                }
                if (maxPitchers == 0)
                {
                    // set resultOfDay.SoldOutOf to the item of which we don't have enough 
                    resultOfDay.SoldOutOf = inventory.items[i].name;
                    return 0;
                }
                i++;
            }
            while (i < recipe.items.Count);
            return maxPitchers;
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
            // loop through items, multiplying GetPriceEach by quantity &
            // adding to subtotal for pitcher
            double costPerPitcher = 0;
            foreach (Item item in recipe.items)
            {
                costPerPitcher = costPerPitcher + (item.GetPriceEach() * item.quantity);
            }
            return costPerPitcher;
        }
        
        
        public void PurchaseItem(int itemNumber, Store store)
        {
            // get the player's quantity, then check if he/she has enough money;
            // if so, change the inventory & reduce his moneyOnHand
            int quantityToPurchase = UserInterface.promptForIntegerInput(
                    $"Enter the quantity of {store.inventory.items[itemNumber].quantityDescription} to purchase for {store.inventory.items[itemNumber].PriceForQuantity.ToString("C")} each:",
                    0, 80);
            // check that the player has enough money
            if (moneyOnHand >= ((double)quantityToPurchase * store.inventory.items[itemNumber].PriceForQuantity))
            {
                // Add the quantityToPurchase * quantityInPrice to the inventory
                inventory.items[itemNumber].quantity =
                    inventory.items[itemNumber].quantity +
                    (quantityToPurchase * store.inventory.items[itemNumber].QuantityInPrice);
                // Deduct the amount from his moneyOnHand
                moneyOnHand = moneyOnHand -
                    ((double)quantityToPurchase * store.inventory.items[itemNumber].PriceForQuantity);
                Console.WriteLine("purchase complete");
            }
            else
            {
                UserInterface.displayMessage("Sorry, you don't have enought money to buy that many.", true);
            }
        }
    }
}
