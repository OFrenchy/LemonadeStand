using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class LemonadeRecipe : Recipe
    {
        public LemonadeRecipe(int lemons = 1, int cupsOfSugar = 1, int iceCubes = 1, 
            int servings = 12, string servingName = "cup")
        {
            addItem(new Lemon("Lemon(s)", lemons));
            addItem(new Sugar("Cup(s) of Sugar", cupsOfSugar));
            addItem(new Ice("Ice Cube(s)", iceCubes));
            this.servings = servings;
            this.servingName = servingName;
        }
    }
}