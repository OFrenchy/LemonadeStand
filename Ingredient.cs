using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Ingredient
    {
        private int pricePerUnit;

        public int name
        {
            get => default(int);
            set
            {
            }
        }

        public void canSpoil()
        {
            throw new System.NotImplementedException();
        }

        public void willSpoil()
        {
            throw new System.NotImplementedException();
        }
    }
}