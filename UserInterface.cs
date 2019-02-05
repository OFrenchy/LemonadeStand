using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UserInterface
    {

        public static int percentTightWads = 25;
        public static int percentGenerous = 25;
        public static int startingWeight = 4;
        public static int customerMaxScore = 9;
        public static double initialPricePerCupOfLemonade = 0.25;
        public static int numberOfServingsPerPitcher = 12;


        public static int pickWholeNumberOneThrough(int upperBound, string message, bool isRandom)
         {
            // pick a whole number from 1 to & including upperBound;  if you want a random number, don't prompt
            if (!isRandom)
            {
                int intInput = promptForIntegerInput(message, 1, upperBound);
                return intInput;
            }
            else
            {
                //generate random number from 1 to upperBound 
                displayMessage(message, false);
                Random randomGenerator = new Random();
                return(randomGenerator.Next(1, upperBound + 1));
            }
        }
        public static string promptForStringInput(string message)
        {
            string input = "";
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().Trim();
            }
            while (input == "");
            return input;
        }
        public static char promptForYesNoInput(string message) 
        {
            string input = "";
            bool validInput = false;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().Trim().ToLower() ;
                if (input.Length > 0)
                {
                    input = input.ToLower();
                    input = input.Substring(0, 1);
                    if (input == "y" || input == "n")
                    {
                        validInput = true;
                    }
                }
            }
            while (validInput == false);
            return Convert.ToChar(input);
        }
        public static int promptForIntegerInput(string message, int lowerBound, int upperBound)
        {
            int inputInteger = 0;
            bool isInteger;
            string input;
            do
            {
                isInteger = false;
                clearScreen();
                Console.WriteLine(message);
                input = Console.ReadLine();
                //bool isInteger = int.TryParse(input, inputInteger); 
                // in order to use try/parse
                try
                {
                    inputInteger = int.Parse(input);
                    isInteger = true;
                    if (inputInteger < lowerBound || inputInteger > upperBound)
                    {
                        Console.WriteLine("That number is out of range.");
                        Console.ReadLine();
                    }
                }
                // Note:  thisException is not used, but left in for future use/debugging/improvement
                catch (Exception thisException)
                {
                    Console.WriteLine("That is not a number.");
                    //Console.WriteLine(thisException.ToString());
                }
            }
            while (isInteger == false || inputInteger < lowerBound || inputInteger > upperBound);
            return inputInteger;
        }
        public static double promptForNumberInput(string message, double lowerBound, double upperBound)
        {
            double inputNumber = 0;
            bool isNumber;
            string input;
            do
            {
                isNumber = false;
                clearScreen();
                Console.WriteLine(message);
                input = Console.ReadLine();
                try
                {
                    inputNumber = double.Parse(input);
                    isNumber = true;
                    if (inputNumber < lowerBound || inputNumber > upperBound)
                    {
                        Console.WriteLine("That number is out of range.");
                        Console.ReadLine();
                    }
                }
                // Note:  thisException is not used, but left in for future use/debugging/improvement
                catch (Exception thisException)
                {
                    Console.WriteLine("That is not a number.");
                    //Console.WriteLine(thisException.ToString());
                }
            }
            while (isNumber == false || inputNumber < lowerBound || inputNumber > upperBound);
            return inputNumber;
        }
        // Note:  this method not used in RPSLS game;  left here as stub for future improvement
        public static char promptForCharInput(string message)
        {
            Console.WriteLine(message);
            // TODO - validate input
            //string test = Console.ReadLine();
            return Convert.ToChar(Console.ReadLine().Substring(0, 1).ToLower());
        }
        public static void displayMessage(string message, bool pauseForReturnEnter)
        {
            Console.WriteLine(message);
            if (pauseForReturnEnter)
            {
                Console.ReadLine();
            }
        }
        public static void clearScreen()
        {
            Console.Clear();
        }

        public static void showWelcomeScreen(string playerName, double initialInvestment)
        {
            // Construct the display of all the information the player needs to start
            string welcomeScreen = "";
            welcomeScreen = "\nWelcome to your Lemonade Stand, " + playerName + "! \n\n" +
                "The goal is to make as much money as possible selling lemonade to passersby. \n" +
                "Factors in your success are the weather, which affects the public's mood \n" +
                "and the number of people passing by your stand - your potential customers, \n" +
                "the quality of your lemonade (which is determined by your recipe), \n" +
                "and the price per cup that you set at the beginning of each day.  \n";

            // TODO - change the number of servings & ounces to an extensible variable
            welcomeScreen = welcomeScreen + "\n" +
                "Each day you must decide what your recipe will be for the day - \n" +
                "how many lemons and cups of sugar for each pitcher, as well as \n" +
                "how many ice cubes in each cup that you sell. \n" +
                $"Each pitcher holds {numberOfServingsPerPitcher} servings of 10 ounces. \n";

            welcomeScreen = welcomeScreen + "\n" +
                "Before the day's sales begin, you have the opportunity to purchase whatever \n" +
                "you need.  You will want to consider the forecast when deciding how much \n" +
                "inventory (ingredients) to purchase, as well as the price that you set per cup. \n" +
                "Also remember that all of the ice that is not used will melt overnight, \n" +
                "and any lemonade remaining unsold in the pitcher must be discarded. \n";
            welcomeScreen = welcomeScreen + "\n" +
                "The game is played for 7 days (meaning 7 rounds). \n" +
                $"You will begin with {initialInvestment.ToString("C")}, an 'investment' from your grandparents \n" +
                "with their blessing and your promise of the occasional free glass of lemonade.  \n";

            welcomeScreen = welcomeScreen + "\n" + "Press enter/return to begin:";

            UserInterface.displayMessage(welcomeScreen, true); 

            // throw new System.NotImplementedException();
        }
        public static int ShowPreparationScreen(Player player, Day day, Store store, ResultOfDay resultOfDay) //, Weather weather)
        {
            // Construct the display of all the information the player needs to start
            string prepScreen ;
            prepScreen = "\n" +
                $"========== {player.name}'s Lemonade Stand - Day {day.dayNumber} ==========\n" +
                "\n" +
                $"Today's forecast is {day.ForecastTemperature.ToString()} degrees and " +
                    $"{day.ForecastWeatherConditions} with {day.RainChancePercent.ToString()}% chance of rain.\n" +
                $"You currently have {string.Format("{0:C}", player.moneyOnHand)} in the cash box. \n";

            prepScreen = prepScreen + "\n" +
                "Your current recipe for a pitcher of lemonade is below.  \n" +
                "(To change any item, enter the line number.): \n";
            // loop through ingredients (except the last one, cups, because there will always 1 cup) 
            // & append to prepScreen 
            for (int i = 0; i < player.recipe.ingredients.Count - 1; i++)
            {
                prepScreen = prepScreen +
                $"{i + 1})  {player.recipe.ingredients[i].quantity} {player.recipe.ingredients[i].name} \n";
            }
            
            prepScreen = prepScreen + "\n" +
                $"Based on your current recipe, cost of ingredients, and current inventory, \n" +
                $"your cost per pitcher is {player.getCostPerPitcher().ToString("C")} which is {(player.getCostPerPitcher()/12).ToString("C")} per cup, and \n" +
                $"you can make {player.pitchers.getMaxNumberOfPitchers().ToString()} pitchers;  each pitcher holds 12 servings (cups) of 10 ounces. \n"; 

            prepScreen = prepScreen + "\n" +
            "Your current inventory is shown below.  \n" +
            "(To purchase any item, enter the line number.): \n";
            // +
            // loop through inventory & append to prepScreen 
            for (int i = 0; i < player.recipe.ingredients.Count; i++)
            {
                string leftPart = $"{i + 4})  {player.inventory.ingredients[i].quantity} {player.inventory.ingredients[i].name} ";// - avail. from store for { string.Format("{0:C}", store.inventory.ingredients[i].PriceForQuantity)  } for {store.inventory.ingredients[i].QuantityInPrice} \n";
                string rightPart = $"- avail. from store for {store.inventory.ingredients[i].PriceForQuantity.ToString("C")} for {store.inventory.ingredients[i].QuantityInPrice.ToString()} \n";
                leftPart = padRightToColumn(24, leftPart);
                prepScreen = prepScreen +
                    leftPart + rightPart;
            }
            prepScreen = prepScreen + "\n" +
                $"8) You are charging {player.resultsOfDays[day.dayNumber].PricePerCup.ToString("C")} per cup of lemonade that you sell. \n";
            
            prepScreen = prepScreen + "\n" +
                "9) to quit \n" +
                "0) to play today's round.\n" +
                "Enter your selection:";

            clearScreen();
            return UserInterface.promptForIntegerInput(prepScreen, 0 , 9);
        }

        public static void showResultsScreen(Player player, Day day, Weather weather, Recipe optimalRecipe)
        {
            // Construct the display of the results of the day's sales
            string resultsScreen = $"The forecast was for {day.ForecastTemperature.ToString()} degrees & " +
                $"{day.ForecastWeatherConditions} with {day.RainChancePercent.ToString()}% chance of rain. \n" +
                $"The actual temperature was {day.ActualTemperature.ToString()} degrees & " + 
                $"{day.ActualWeatherConditions}. \n";

            //string recipeRecommendation = CompareRecipes(player.recipe, optimalRecipe);
            resultsScreen = resultsScreen + $"\n {CompareRecipes(player.recipe, optimalRecipe)}. \n";

            resultsScreen = resultsScreen + "\n" + "Press enter/return to continue:";
            clearScreen();
            UserInterface.displayMessage(resultsScreen, true);
        }
        private static string CompareRecipes(Recipe playerRecipe, Recipe optimalRecipe)
        {
            // we will help the user hone in on the correct # of lemons first, 
            // then work on the correct # of cups of sugar.
            if (playerRecipe.ingredients[0].quantity < optimalRecipe.ingredients[0].quantity)
            {
                return "Some people said the lemonade was too weak.";
            }
            else if (playerRecipe.ingredients[0].quantity > optimalRecipe.ingredients[0].quantity)
            {
                return "Some people said the lemonade was too strong.";
            }
            else if (playerRecipe.ingredients[1].quantity < optimalRecipe.ingredients[1].quantity)
            {
                return "Some people said the lemonade was too sour.";
            }
            else if (playerRecipe.ingredients[1].quantity > optimalRecipe.ingredients[1].quantity)
            {
                return "Some people said the lemonade was too sweet.";
            }
            else
            {
                return "Everybody said the lemonade was just right!";
            }
        }
        public static string padRightToColumn(int column, string stringToPad)
        {
            // pads the right side of the string up to column
            for (int i = stringToPad.Length; i < column; i++)
            {
                stringToPad = stringToPad + " ";
            }
            return stringToPad;
        }

    } // class
} // namespace
