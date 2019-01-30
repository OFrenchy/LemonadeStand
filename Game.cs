using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Game
    {
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

        public void playGame()
        {
            throw new System.NotImplementedException();
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