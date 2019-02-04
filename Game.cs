using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    // ========================= USER STORIES =========================================
    // 105 points total
    // User stories:
    // As a developer, if I don’t know what Lemonade Stand game is, I will play the game online 
    //      for a bit to get familiar with the gameplay.
    // ( 5 points): As a developer, I want to make good, consistent commits.
    // (25 points): As a player, I want the basic Lemonade Stand gameplay to be present.
    // (10 points): As a player, I want a weather system that includes a forecast and actual 
    //      weather, so that I can get a predicted forecast for a day or week and then what 
    //      the actual weather is on the given day.
    // (10 points): As a player, the price of product as well as weather/temperature should 
    //      affect demand, so that if the price is too high, sales will decrease, or if the 
    //      price is too low, sales will increase, etc. 
    // (10 points): As a player, I want each customer to be a separate object with its own 
    //      chance of buying a glass of lemonade, so that how much lemonade is purchased and 
    //      how much a customer is willing to pay will vary from customer to customer.
    // (5 points): As a player, I want the ability to make a recipe for my lemonade, so that 
    //      I can include x-amount of lemons, x-amount of sugar, and x-amount of ice.
    // (10 points): As a player, I want my game to be playable for at least seven days.
    // (10 points): As a player, I want my daily profit or loss displayed at the end of each day, 
    //      so that I know how much money my lemonade stand has made.I also want my total profit 
    //      or loss to be a running total that is displayed at the end of each day, so that I 
    //      know how much money my lemonade stand has made.
    // (10 points): As a developer, I want to implement the SOLID design principles as well 
    //      as C# best practices in my project, so that project is as well-designed as possible.
    // (10 points (5 points each)): As a developer, I want to pinpoint at least two places where 
    //      I used one of the SOLID design principles and discuss my reasoning, so that I can 
    //      properly understand good code design.Minimum of two SOLID design principles must be used.
    // Bonus Points:
    // (5 points): As a player, I want the game to be playable for more than one player, so that I can have multiple humans play each other or a human play a computer.
    // (5 points) As a developer, I want to integrate a Weather API, so that my game has real-time weather based on a current temperature and forecast.

    // As a developer, I will assume the store has unlimited quantities
    // As a developer, I will weight the weather opportunity to better weather

    // As a developer, I will use the following algorithm to determine # of potential customers 
    //based on
    //  a) forecast temp
    //    actual temp is dice roll
    //	1 = forecast = actual
    //	2 = actual 5 degrees lower
    //	3 = actual 10 degrees lower
    //	4 = actual 5 degrees higher
    //	5 = actual 10 degrees higher
    //	6 = actual 15 degrees higher
    //      - forecast conditions rain/overcast/mostly cloudy party/cloudy/ sunny
    //  b) 3-sided coin toss to see if 
    //	   1 = conditions as forecast
    //	   2 = conditions one level worse than forecast
    //	   3 - conditions one level better than forecast
    // As a developer, I will give the user a default recipe
    // As a developer, there will be an optimum recipe which will result in more sales 
    //      than less tasty recipes
    // As a developer, we will assume that the store has unlimited quantities and will therefore 
    //      not keep track of its inventory;  
    // As a developer, we will not concern ourselves with the money the store accumulates
    // As a player, I want the game to calculate what my cost per pitcher and cost per cup of lemonade is

    public class Game
    {
        
        public void playGame()
        {
            int numberOfDays = 7;
            double initialInvestment = 20.00;

            // create the Weather object
            Weather weather = new Weather(numberOfDays);

            // create the store
            Store store = new Store();
            
            // Create list of players
            List<Player> players = new List<Player>();
            do
            {
                // Create player, add to players
                Player thisPlayer = new Player(store, "Welcome to the game 'Lemonade Stand!'\n",  initialInvestment);
                UserInterface.showWelcomeScreen(thisPlayer.name, initialInvestment);
                players.Add(thisPlayer);
                UserInterface.clearScreen();
            }
            while (UserInterface.promptForYesNoInput("Do you want to add another player? Enter y or n:").ToString() == "y");
            UserInterface.clearScreen();

            //// Display welcome / instruction screen to each player (?)
            //foreach (Player thisPlayer in players)
            //{
            //    UserInterface.showWelcomeScreen(thisPlayer.name, initialInvestment);
            //}
            
            // Create a list of days
            List<Day> days = new List<Day>();
            for (int i = 0; i < numberOfDays; i++)
            {
                // create day, add to days
                Day day = new Day(i + 1);
                days.Add(day);

                // Have the weather object set the day's forecast
                weather.GetForecast(day);

                // Display the Daily prep screen for each player
                foreach (Player thisPlayer in players)
                {
                    int intOption;
                    do
                    {
                        intOption = UserInterface.ShowPreparationScreen(thisPlayer,
                            day, store);
                        if (intOption > 0)
                        {
                            // change recipe or purchase ingredients
                            if (intOption >= 1 && intOption <= 3)
                            {
                                // Change the recipe item quantity to the number the user enters
                                thisPlayer.recipe.ingredients[intOption - 1].quantity = 
                                    UserInterface.promptForIntegerInput(
                                        $"Enter new quantity of {thisPlayer.recipe.ingredients[intOption - 1].name} for the recipe:", 
                                        1, 20);
                            }
                            else if (intOption >= 4 && intOption <= 7)
                            {
                                // get the player's quantity, then check if he/she has enough money;
                                // if so, change the inventory & reduce his moneyOnHand
                                int quantityToPurchase = UserInterface.promptForIntegerInput(
                                        $"Enter the quantity of {store.inventory.ingredients[intOption - 4].quantityDescription} to purchase for {store.inventory.ingredients[intOption - 4].PriceForQuantity.ToString("C")} each:",
                                        1, 80);
                                // check that the player has enough money
                                if (thisPlayer.moneyOnHand >= ((double)quantityToPurchase * store.inventory.ingredients[intOption - 4].PriceForQuantity)) 
                                {
                                    // Add the quantityToPurchase * quantityInPrice to the inventory
                                    thisPlayer.inventory.ingredients[intOption - 4].quantity =
                                        thisPlayer.inventory.ingredients[intOption - 4].quantity +
                                        (quantityToPurchase * store.inventory.ingredients[intOption - 4].QuantityInPrice);
                                    // Deduct the amount from his moneyOnHand
                                    thisPlayer.moneyOnHand = thisPlayer.moneyOnHand -
                                        ((double)quantityToPurchase * store.inventory.ingredients[intOption - 4].PriceForQuantity);
                                    Console.WriteLine("purchase complete");
                                }
                                else
                                {
                                    UserInterface.displayMessage("Sorry, you don't have enought money to buy that many.", true);
                                }
                            }
                            else if (intOption == 8)
                            {
                                // Change the price per cup you will charge.  
                                thisPlayer.pricePerCupOfLemonade = UserInterface.promptForNumberInput( 
                                    "Enter the new price to charge per cup of lemonade: ", 0.0, 20.0);
                            }
                            else if (intOption == 9)
                            {
                                // user wants to quit
                                return;
                            }
                        } // if
                    }
                    while (intOption != 0);
                } // thisPlayer in players

                // ONLY AFTER EACH player has set their choices in the ShowPreparationScreen method, 
                // set the current day's actual weather from the weather object
                weather.SetActualWeatherForDay(day);
                Console.WriteLine();

                // Play today's round:
                // Generate:
                //      the number of potential customers, 
                //      the number of actual customers, 
                //      today's results
                // Display the Daily results screen for each player
                // Display welcome / instruction screen to each player (?)
                foreach (Player thisPlayer in players)
                {
                    UserInterface.showResultsScreen(thisPlayer);
                }
                
            }  // for each day 





            // throw new System.NotImplementedException();
        }
        public int optimalRecipe
        {
            get => default(int);
            set
            {
            }
        }

        public int defaultRecipe
        {
            get => default(int);
            set
            {
            }
        }

        public Recipe Recipe
        {
            get => default(Recipe);
            set
            {
            }
        }


        
        public void setNumberOfPotentialCustomersForDay()
        {
            throw new System.NotImplementedException();
        }

        public void setOptimalPricePerCupForDay()
        {
            throw new System.NotImplementedException();
        }

      

        
    }
}