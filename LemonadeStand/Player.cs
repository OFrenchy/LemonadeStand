using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScizzorsLizardSpock
{
    class Player
    {
        // class - … Is A …
        // member variables - … Has A …
        public bool isHuman;
        public string name;
        // TODO - how do I make this private, & still work?
        protected int score;
        // TODO - find out if private variables are accessible in child classes
        // private doesn't work when trying to set it in the Human & AI classes...???
        //private int currentSelection;
        protected int currentSelection;

        public Player(string name, bool isHuman)
        {
            this.score = 0;
            // works b4 huyman/ai class implementsation
            //this.name = UserInterface.promptForStringInput("Enter this player's name:");
            //this.isHuman = (UserInterface.promptForYesNoInput("Is this player human?  Enter y or n:") 
            //    == Convert.ToChar("y"));
            this.name = name;
            this.isHuman = isHuman;
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

        // member methods - … Can Do …
        public virtual int MakeSelection(int rangeZeroBased)
        {
            // prompt for selection
            string message = name + "'s turn: Please make a selection, enter 1 for Rock, 2 for Paper, " +
                "3 for Scissors, 4 for Lizard, or 5 for Spock: ";
            currentSelection = Convert.ToInt32(UserInterface.pickWholeNumberOneThrough(5, message, !isHuman) - 1);
            // if this player is not human, write its selection to the window
            if (!isHuman)
            {
                Console.WriteLine(currentSelection + 1);
            }
            return currentSelection;
        }
        public int GetCurrentSelection()
        {
            return currentSelection;
        }
        public int incrementScore()
        {
            score++;
            return score;
        }
        public void resetScore() 
        {
            score = 0;
        }
        public int getCurrentScore()
        {
            return score;
        }
    }
}
