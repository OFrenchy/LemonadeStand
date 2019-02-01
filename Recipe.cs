using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Recipe
    {
        public int servings = 12;
        public string servingName = "cups";
        public List<Ingredient> ingredients;

        public Recipe(int numberOfLemons = 1, int cupsOfSugar = 1, int iceCubes = 1, int cups = 1)
        {
            ingredients.Add(new Ingredient("Lemons", numberOfLemons));
            ingredients.Add(new Ingredient("Cups of Sugar", cupsOfSugar));
            ingredients.Add(new Ingredient("Ice Cubes", iceCubes));
            ingredients.Add(new Ingredient("Cup(s)", cups));
        }


        //public Ingredients Ingredients
        //{
        //    get => default(Ingredients);
        //    set
        //    {
        //    }
        //}
    }
}