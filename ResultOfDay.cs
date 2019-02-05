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
        private int numberOfCupsRemainingInPitcher = -1;
        private int numberOfPitchersMade = 0;
        private double expensesForDay = -384.0;
        private double salesIncomeForDay = -384.0;
        //private double profitForDay = -384.0;
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
        public ResultOfDay(int dayNumber, double moneyOnHand)
        {
            this.dayNumber = dayNumber;
            this.moneyOnHandAtBOD = moneyOnHand;
            this.pricePerCup = UserInterface.initialPricePerCupOfLemonade;
        }

        public double CostPerPitcher
        {
            get => costPerPitcher;
            set => costPerPitcher = value;
        }

        public double PricePerCup
        {
            get => pricePerCup;
            set => pricePerCup = value;
        }

        public int NumberOfCupsSold
        {
            get => numberOfCupsSold;
            set => numberOfCupsSold = value;
        }

        public int NumberOfCupsRemainingInPitcher
        {
            get => numberOfCupsRemainingInPitcher;
            set => numberOfCupsRemainingInPitcher = value;
        }

        public int NumberOfPitchersMade
        {
            get => numberOfPitchersMade;
            set => numberOfPitchersMade = value;
        }
        public double ExpensesForDay
        {
            get => expensesForDay;
            set => expensesForDay = value;
        }

        public double SalesIncomeForDay
        {
            get => salesIncomeForDay;
            set => salesIncomeForDay = value;
        }

        public double ProfitForDay
        {
            get => salesIncomeForDay - expensesForDay;
            //set
        }

        public int PotentialCustomers
        {
            get => potentialCustomers;
            set => potentialCustomers = value;
        }

        public bool SoldOut
        {
            get => soldOut;
            set => soldOut = value;
        }

        public string SoldOutOf
        {
            get => soldOutOf;
            set => soldOutOf = value;
        }

        public double MoneyOnHandAtBOD
        {
            get => moneyOnHandAtBOD;
            set => moneyOnHandAtBOD = value;
        }

        public double MoneyOnHandAtEOD
        {
            get => moneyOnHandAtEOD;
            set => moneyOnHandAtEOD = value;
        }

        public int WeatherForecastTemp
        {
            get => weatherForecastTemp;
            set => weatherForecastTemp = value;
        }

        public int WeatherForecastConditionNumber
        {
            get => weatherForecastConditionNumber;
            set => weatherForecastConditionNumber = value;
        }

        public int WeatherForecastChanceOfRainPercent
        {
            get => weatherForecastChanceOfRainPercent;
            set => weatherForecastChanceOfRainPercent = value;
        }

        public int WeatherActualTemp
        {
            get => weatherActualTemp;
            set => weatherActualTemp = value;
        }

        public int WeatherActualConditionNumber
        {
            get => weatherActualConditionNumber;
            set => weatherActualConditionNumber = value;
        }

        public string CustomerComments
        {
            get => customerComments;
            set => customerComments = value;
        }

        public int DayNumber
        {
            get => dayNumber;
            set => dayNumber = value;
        }
    }
}