﻿using System;
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
    //
    
    public class Game
    {
        
        public void playGame()
        {
            // Create list of players
            List<Player> players = new List<Player>();
            do
            {
                // Create player, add to players
                Player thisPlayer = new Player("Welcome to the game 'Lemonade Stand!'\n");
                players.Add(thisPlayer);
                UserInterface.clearScreen();
            }
            while (UserInterface.promptForYesNoInput("Do you want to add another player? Enter y or n:").ToString() == "y");
            UserInterface.clearScreen();

            // Display welcome / instruction screen to each player (?)
            foreach (Player thisPlayer in players)
            {
                UserInterface.showWelcomeScreen(thisPlayer.name);
            }
            




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

        public Players Players
        {
            get => default(Players);
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

        public Players getPlayers()
        {
            throw new System.NotImplementedException();
        }

        
    }
}