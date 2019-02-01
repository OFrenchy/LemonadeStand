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
        public double moneyOnHand;

        public Player(string greeting = "")
        {
            moneyOnHand = 20.00;
            name = UserInterface.promptForStringInput($"{greeting}Enter this player's name:");
            recipe = new Recipe();
            inventory = new Recipe(0, 0, 0, 0);
            
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

        public int getMaxNumberOfPitchers()
        {
            // TODO - calculate actual cost per pitcher
            return -1;
            //throw new System.NotImplementedException();
        }
    }
}
