using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        private bool isActualCustomer = false;
        //private int cupsPurchased;
        //private int mood1To5;

        // TODO - change to properties?  Protected?  
        //public bool isTightWad = false;
        //public bool isGenerous = false;
        public int weatherWeight = 0;
        public int recipeWeight = 0;
        public int priceWeight = 0;

        public int score = 0;

        public int dieRoll = 0;

        
        public bool IsActualCustomer
        {
            get => isActualCustomer;
            set => isActualCustomer = value;
        }
    }
}