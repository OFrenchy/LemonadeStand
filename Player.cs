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
        
        public string name;
        public Recipe recipe;
        public Recipe inventory;


        public Player(string greeting = "")
        {
            this.moneyOnHand = 20.00;
            this.name = UserInterface.promptForStringInput($"{greeting}Enter this player's name:");
            recipe = new Recipe();
            inventory = new Recipe(0, 0, 0, 0);
            
        }

        public LemonadeStand.Days DaysRounds
        {
            get => default(LemonadeStand.Days);
            set
            {
            }
        }

        public int baseRecipe
        {
            get => default(int);
            set
            {
            }
        }

        public LemonadeStand.Recipe Recipe
        {
            get => default(LemonadeStand.Recipe);
            set
            {
            }
        }

        public double moneyOnHand
        {
            get => default(int);
            set
            {
            }
        }

        // member methods - … Can Do …
        public virtual int MakeSelection(int rangeZeroBased)
        {
            // prompt for selection
            string message = name + "'s turn: Please make a selection, enter 1 for Rock, 2 for Paper, " +
                "3 for Scissors, 4 for Lizard, or 5 for Spock: ";
            return Convert.ToInt32(UserInterface.pickWholeNumberOneThrough(5, message, false) - 1);
        }

        public double getCostPerPitcher()
        {
            throw new System.NotImplementedException();
        }

        public int getMaxNumberOfPitchers()
        {
            throw new System.NotImplementedException();
        }
    }
}
