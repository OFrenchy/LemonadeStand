using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {
        private int temperatureForecast;
        private int temperatureActual;
        private int rainChancePercent;

        public int todaysRecipe
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

        public Customers Customers
        {
            get => default(Customers);
            set
            {
            }
        }

        public void numberPitchersToMake()
        {
            throw new System.NotImplementedException();
        }
    }
}