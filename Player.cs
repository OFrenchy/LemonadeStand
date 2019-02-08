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
        public double pricePerCupOfLemonade = UserInterface.initialPricePerCupOfLemonade;
        
        public Player(Store store, string greeting, double initialInvestment)
        {
            moneyOnHand = initialInvestment;

            name = UserInterface.promptForStringInput($"{greeting}Enter this player's name:");
            recipe = new LemonadeRecipe();
            inventory = new Inventory();// 0, 0, 0, 0, UserInterface.numberOfServingsPerPitcher);
            inventory.addItem(new Lemon("Lemon(s)", 0));
            inventory.addItem(new Sugar("Cup(s) of Sugar", 0));
            inventory.addItem(new Ice("Ice Cubes", 0));
            inventory.addItem(new Cup("Cup(s)", 0));

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
        public double ProfitToDate()
        {
            double profitToDate = 0;
            for (int i = 0; i < resultsOfDays.Count; i++)
            {
                profitToDate += resultsOfDays[i].ProfitForDay;
            }
            return profitToDate;
        }
        public void ResetForNewDay(int dayNumber, double moneyOnHand, double pricePerCupOfLemonade)
        {
            // create new results for thisPlayer
            resultOfDay = new ResultOfDay(dayNumber, moneyOnHand, pricePerCupOfLemonade);
            resultOfDay.PricePerCup = pricePerCupOfLemonade;
        }
        public int sellLemonadeForDay(Day day)
        {
            Console.WriteLine("In Sales");
            resultOfDay.MoneyOnHandAtEOD = moneyOnHand;
            resultOfDay.CostPerPitcher = getCostPerPitcher();
            resultOfDay.PricePerCup = pricePerCupOfLemonade;
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
                    
                    // if pitcher is empty, make new pitcher if you can, 
                    // if not, set SoldOut = true;
                    if (CupsRemainingInPitcher == 0)
                    {
                        MakeAnotherPitcher();
                    }
                }
                // if we ran out, exit 
                if (resultOfDay.SoldOut)
                {
                    break;
                }
            }// foreach customer
            // End of day, the ice melts, set inventory of ice to 0
            inventory.items[2].quantity = 0;
            // add resultOfDay to list resultsOfDays
            resultsOfDays.Add(resultOfDay);
            return salesCount;
        }
        public void recordSale(ResultOfDay resultOfDay)//, Pitchers pitchers)
        {   
            resultOfDay.NumberOfCupsSold++;
            resultOfDay.SalesIncomeForDay +=  resultOfDay.PricePerCup;
            resultOfDay.MoneyOnHandAtEOD += resultOfDay.PricePerCup;
            moneyOnHand += resultOfDay.PricePerCup;
            // decrement inventory of cups by 1
            inventory.items[3].quantity--;
            // increase expenses by the cost of 1 physical cup
            //resultOfDay.ExpensesForDay += inventory.items[3].GetPriceEach();
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
                // decrease inventory by recipe amounts
                decreaseInventoryByOneRecipe();
                //// increase expenses in the ledger
                //resultOfDay.ExpensesForDay += getCostPerPitcher();
                // add # of servings to resultOfDay.servingsin pitcher
                resultOfDay.NumberOfCupsRemainingInPitcher = recipe.servings;
                // increment # pitchers made in 
                resultOfDay.NumberOfPitchersMade++;
                UserInterface.displayMessage("Made another pitcher.",false);
                return true;
            }
            else
            {
                resultOfDay.SoldOut = true;
                return false;
            }
        }
        public void decreaseInventoryByOneRecipe()
        {       // do not decrease cups until you sell a cup
            for (int i = 0; i < inventory.items.Count - 1; i++)
            {   
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
        public void PurchaseItem(int itemNumber, Store store, ResultOfDay resultOfDay)
        {
            // get the player's quantity, then check if he/she has enough money;
            // if so, change the inventory & reduce his moneyOnHand
            int quantityToPurchase = UserInterface.promptForIntegerInput(
                    $"Enter the quantity of {store.inventory.items[itemNumber].quantityDescription} to purchase for {store.inventory.items[itemNumber].PriceForQuantity.ToString("C")} each:",
                    0, 80);
            double saleAmount = (double)quantityToPurchase * store.inventory.items[itemNumber].PriceForQuantity;
            // check that the player has enough money
            if (moneyOnHand >= saleAmount)
            {
                // Add the quantityToPurchase * quantityInPrice to the inventory
                inventory.items[itemNumber].quantity =
                    inventory.items[itemNumber].quantity +
                    (quantityToPurchase * store.inventory.items[itemNumber].QuantityInPrice);
                // Deduct the amount from his moneyOnHand
                moneyOnHand = moneyOnHand - saleAmount;
                // add this purchase to expenses for the day
                resultOfDay.ExpensesForDay += saleAmount;
                Console.WriteLine("purchase complete");
            }
            else
            {
                UserInterface.displayMessage("Sorry, you don't have enought money to buy that many.", true);
            }
        }
    }
}
