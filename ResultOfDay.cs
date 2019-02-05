using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class ResultOfDay
    {
        private int dayNumber;
        private double costPerPitcher = -384.0;
        private double pricePerCup = -384.0;
        private int numberOfCupsSold = -1;
        private int numberOfCupsThrownAway = -1;
        private double expensesForDay = -384.0;
        private double salesForDay = -384.0;
        private double profitForDay = -384.0;
        private int potentialCustomers = -1;
        private bool soldOut = false;
        private string soldOutOf = "";
        private double moneyOnHandAtBOD = 0.0;
        private double moneyOnHandAtEOD = 0.0;
        private int weatherForecastTemp = -384;
        private int weatherForecastConditionNumber = -1;
        private int weatherForecastChanceOfRainPercent = -1;
        private int weatherActualTemp = -384;
        private int weatherActualConditionNumber = -1;       
        private string customerComments = "";
        

        //==========================================================================================
        public ResultOfDay(int dayNumber)
        {
            this.dayNumber = dayNumber;

        }
        public double CostPerPitcher
        {
            get => default(int);
            set
            {
            }
        }

        public double PricePerCup
        {
            get => default(int);
            set
            {
            }
        }

        public int NumberOfCupsSold
        {
            get => default(int);
            set
            {
            }
        }

        public int NumberOfCupsThrownAway
        {
            get => default(int);
            set
            {
            }
        }

        public double ExpensesForDay
        {
            get => default(int);
            set
            {
            }
        }

        public double SalesForDay
        {
            get => default(int);
            set
            {
            }
        }

        public double ProfitForDay
        {
            get => default(int);
            set
            {
            }
        }

        public int PotentialCustomers
        {
            get => default(int);
            set
            {
            }
        }

        public bool SoldOut
        {
            get => default(int);
            set
            {
            }
        }

        public string SoldOutOf
        {
            get => default(int);
            set
            {
            }
        }

        public double MoneyOnHandAtBOD
        {
            get => default(int);
            set
            {
            }
        }

        public double MoneyOnHandAtEOD
        {
            get => default(int);
            set
            {
            }
        }

        public int WeatherForecastTemp
        {
            get => default(int);
            set
            {
            }
        }

        public int WeatherForecastConditionNumber
        {
            get => default(int);
            set
            {
            }
        }

        public int WeatherForecastChanceOfRainPercent
        {
            get => default(int);
            set
            {
            }
        }

        public int WeatherActualTemp
        {
            get => default(int);
            set
            {
            }
        }

        public int WeatherActualConditionNumber
        {
            get => default(int);
            set
            {
            }
        }

        public string CustomerComments
        {
            get => default(int);
            set
            {
            }
        }

        public int DayNumber
        {
            get => default(int);
            set
            {
            }
        }
    }
}