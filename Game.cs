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

    // TODO - figure out an algorithm to determine the customer's likelihood of purchasing
    // TODO  - figure out an algorithm to produce a number of potential customers
    //          - maybe a table for a number based on weather, then a random number between
    //            0 & 20 added to that number?

    // TODO - update this below
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
    // As a developer, we want the forecast to affect the number of potential customers, 
    // As a developer, we want the actual weather to affect the customer's mood and thus the 
    //      number of sales
        
        // TODO - for future improvement, calculate if the user doesn't have enough money
    //      to buy whatever they need to make another pitcher, 
    //      and thus cannot continue in the game = bankrupt.

    public class Game
    {
        
        public void playGame()
        {
            int numberOfDays = 7;
            double initialInvestment = 20.00;
            int initialNumberOfPotentialCustomers = 60;    // 5 pitchers = 60 

            // create the Weather object
            Weather weather = new Weather(numberOfDays);

            // create the store
            Store store = new Store();

            // create the optimal recipe - according to AllRecipes.com; https://www.allrecipes.com/recipe/20487/old-fashioned-lemonade
            // 12 lemons & 2 cups of sugar
            Recipe optimalRecipe = new Recipe(12, 2, 10, 1);

            double optimalPrice = 0.60;

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
                            // change recipe or purchase ingredients - was series of if - else if blocks
                            switch (intOption)
                            {
                                case 1:
                                case 2:
                                case 3:
                                    // Change the recipe item quantity to the number the user enters
                                    thisPlayer.recipe.ingredients[intOption - 1].quantity = 
                                        UserInterface.promptForIntegerInput(
                                            $"Enter new quantity of {thisPlayer.recipe.ingredients[intOption - 1].name} for the recipe:", 
                                            1, 20);
                                    break;
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                    // purchase an item 
                                    thisPlayer.PurchaseItem(intOption - 4, store);
                                    break;
                                case 8:
                                    // Change the price per cup you will charge.  
                                    thisPlayer.pricePerCupOfLemonade = UserInterface.promptForNumberInput( 
                                        "Enter the new price to charge per cup of lemonade (use the format 0.5 for fifty cents): ", 0.0, 20.0);
                                    break;
                                case 9:
                                    // user wants to quit
                                    return;
                            } // switch
                        } // if intOption > 0
                    }
                    while (intOption != 0);
                } // thisPlayer in players

                // ONLY AFTER EACH player has set their choices in the ShowPreparationScreen method, 
                // determine the number of potential customers - (weather forecast affects turnout)
                //sets day.NumberOfPotentialCustomers
                weather.affectCustomerTurnout(initialNumberOfPotentialCustomers, day);
                // set the current day's actual weather from the weather object
                weather.SetActualWeatherForDay(day);
                Console.WriteLine();

                

                // Score potential customers on a scale from 1 - 6(?), 
                //      starting with a starting likelihoodScore of 4(?) (= slightly in favor)
                //      because people are generally willing to purchase  
                //      from a little kid selling lemonade
                // 1/4 of people are tightwads and are generally not willing to buy, 
                //      so deduct 1 from their score;
                // 1/4 are generous and are more than willing to buy, 
                //      add 1 to their score
                // Three things affect whether a customer will purchase:
                // 1) weather (affects mood)  ; //{"rain", "overcast", "mostly cloudy", "partly cloudy", "mostly sunny", "clear"}
                // 2) price
                // 3) quality of the product

                // if the weather is raining, overcast, or mostly cloudy, deduct 1 from everyone's score
                // if the weather is partly cloudy (3) or better, add 1 to everyone's score
                int weatherWeight;
                if ( day.ActualConditionNumber <= 2)
                {
                    weatherWeight = -1;
                }
                else { weatherWeight = 1; };


                day.CreateCustomers();

                // scoreLemonade method - returns integer +/-  to add to likelihoodScore
                // for the quality of the lemonade, 
                //      score it based on # of lemons & cups of sugar only;  ice is not a big deal
                //      if the # of lemons is optimum, add 2(?) to customer's score
                //      else if the # of lemons is < or > 1/2 the optimum, deduct 2, 
                //      else if the # of lemons is < or > 1/4 the optimum, deduct 1, 

                // Play today's round:
                // Generate:
                //      create the actual customers, 
                //      the number of actual customers, 
                //      today's results
                // Display the Daily results screen for each player
                foreach (Player thisPlayer in players)
                {
                    // Generate a weight for the quality of lemonade
                    int recipeWeight = ScoreLemonade(thisPlayer.recipe, optimalRecipe);

                    // Generate a weight for the price of lemonade
                    int priceWeight = ScorePrice(thisPlayer.pricePerCupOfLemonade, optimalPrice);

                    // reset master customer list
                    day.ScoreCustomers(
                    UserInterface.percentTightWads,
                    UserInterface.percentGenerous,
                    UserInterface.startingWeight,
                    weatherWeight,
                    recipeWeight,
                    priceWeight
                    );

                    // play round
                    //TODO
                    int quantitySold = sellLemonadeForDay(thisPlayer, day);
                    Console.WriteLine($"{quantitySold} sold!");
                    Console.ReadLine();

                    // si
                    UserInterface.showResultsScreen(thisPlayer, day, weather, optimalRecipe);
                    
                }
                
            }  // for each day 





            // throw new System.NotImplementedException();
        }

        public int sellLemonadeForDay(Player thisPlayer, Day day)
        {
            Random randomGenerator = new Random();
            int salesCount = 0;
            foreach (Customer thisCustomer in day.masterListOfCustomersForDay)
            {
                int dieRoll = randomGenerator.Next(1, 6);
                thisCustomer.dieRoll = dieRoll;
                if (dieRoll <= thisCustomer.score)
                {
                    thisCustomer.dieRoll = dieRoll;
                    // TODO - change this to more fool-proof method
                    thisCustomer.IsActualCustomer = true;
                    salesCount++;
                }
            }
            // TODO - change player object to hold whatever we need to save
            //      for the day's results screen & final wrap-up screen
            thisPlayer.holdThis = salesCount;
            return salesCount;
        }
        public int ScorePrice(double playerPrice, double optimalPrice)
        {
            // ScorePrice method - returns integer +/-  to add to likelihoodScore
            // for the price of the lemonade, 
            //      score it based on cost:
            //      if price is > 15 cents above optimal, return -1 
            //      else if price is equal to or greater than optimal, return 0, 
            //      else if price is 10 cents less than optimal or less, return + 1, 


            int weightForPrice=0;
            
            if (playerPrice > optimalPrice + 0.15)
            {
                weightForPrice = -1;
            }
            else if (playerPrice > optimalPrice)  
            {
                weightForPrice = 0;
            }
            else if (playerPrice <= optimalPrice)  
            {
                weightForPrice = 1;
            }
            return weightForPrice;
        }

        public int ScoreLemonade(Recipe playersRecipe, Recipe optimalRecipe)
        {
            // scoreLemonade method - returns integer +/-  to add to likelihoodScore
            // for the quality of the lemonade, 
            //      score it based on # of lemons & cups of sugar only;  ice is not a big deal
            //      if the # of lemons is optimum, add 2(?) to customer's score
            //      else if the # of lemons is   < or > 1/2 the optimum, deduct 2, 
            //      else if the # of lemons is < or > 1/4 the optimum, deduct 1, 
            // 1-6 lemons (-2), 6-9 (-1), 9-11 (0), 12 (+2)

            int weightForRecipe = 0;
            int optimalLemons = optimalRecipe.ingredients[0].quantity;

            if (playersRecipe.ingredients[0].quantity == optimalLemons)
            {
                weightForRecipe = 2;
            }
            else if (playersRecipe.ingredients[0].quantity <= (optimalLemons / 2) )  // 1-6
            {
                weightForRecipe = -2;
            }
            else if (playersRecipe.ingredients[0].quantity <= (optimalLemons - (optimalLemons / 4)))  // 7-9
            {
                weightForRecipe = -1;
            }
            else if (playersRecipe.ingredients[0].quantity >= optimalLemons + (optimalLemons / 2))  // 18 or more
            {
                weightForRecipe = -2;
            }
            else if (playersRecipe.ingredients[0].quantity >= (optimalLemons + (optimalLemons / 4))) // 15-17
            {
                weightForRecipe = -1;
            }
            return weightForRecipe;
        }


        //public Recipe Recipe
        //{
        //    get => default(Recipe);
        //    set
        //    {
        //    }
        //}





    }
}