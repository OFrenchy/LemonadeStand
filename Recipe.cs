using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Recipe : Inventory
    {

        public int servings = 0;
        public string servingName = "";
        //public List<Item> items;

        //public Recipe(int numberOfLemons = 1, int cupsOfSugar = 1, 
        //    int iceCubes = 1, int servings = 12)
        //{
        //    items = new List<Item>();
        //    items.Add(new Lemon("Lemon(s)", numberOfLemons));
        //    items.Add(new Sugar("Cup(s) of Sugar", cupsOfSugar));
        //    items.Add(new Ice("Ice Cube(s)", iceCubes));
        //    //items.Add(new Item("Cup(s)", cups));
        //    this.servings = servings;
        //}
        
    }
}