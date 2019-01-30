using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScizzorsLizardSpock
{
    public static class UserInterface
    {
        public static string[] selectionNames = {"Rock", "Paper", "Scissors", "Lizard", "Spock"};

        public static int pickWholeNumberOneThrough(int upperBound, string message, bool isRandom)
        {
            // pick a whole number from 1 to upperBound;  if you want a random number, don't prompt
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
                return(randomGenerator.Next(upperBound) + 1);
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
                Console.Read();
            }
        }
        public static void clearScreen()
        {
            Console.Clear();
        }
    }
}
