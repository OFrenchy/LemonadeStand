using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {
        private int forecastTemperature = -384;
        private int forecastConditionNumber = -384;
        private int actualTemperature = -384;
        private int actualConditionNumber = -384;
        private int rainChancePercent = -10;
        private string forecastWeatherConditions = "Clear Skies";
        private string actualWeatherConditions = "Clear Skies";
        private int numberOfPotentialCustomers = -100;
        public int dayNumber;

        //TODO - chg to be private?
        public List<CustomerTightwadOrGenerous> masterListOfCustomersForDay;
        
        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
        }

        //public Recipe Recipe
        //{
        //    get => default(Recipe);
        //    set
        //    {
        //    }
        //}
        public int ForecastTemperature  // only allows it to be set once
        {
            get => forecastTemperature;
            set
            {
                if (forecastTemperature == -384)
                {
                    forecastTemperature = value;
                }
            }
        }
        public int ForecastConditionNumber  // only allows it to be set once
        {
            get => forecastConditionNumber;
            set
            {
                if (forecastConditionNumber == -384)
                {
                    forecastConditionNumber = value;
                }
            }
        }
        public string ForecastWeatherConditions     // only allows it to be set once
        {
            get => forecastWeatherConditions;
            set
            {
                if (forecastWeatherConditions != "")
                {
                    forecastWeatherConditions = value;
                }
            }
        }
        public int RainChancePercent    // only allows it to be set once
        {
            get => rainChancePercent;
            set
            {
                if (rainChancePercent == -10)
                {
                    rainChancePercent = value;
                }
            }
        }
        public int ActualTemperature    // only allows it to be set once
        {
            get => actualTemperature;
            set
            {
                if (actualTemperature == -384)
                {
                    actualTemperature = value;
                }
            }
        }
        public string ActualWeatherConditions   // only allows it to be set once
        {
            get => actualWeatherConditions;
            set
            {
                if (actualWeatherConditions != "")
                {
                    actualWeatherConditions = value;
                }
            }
        }
        public int ActualConditionNumber    // only allows it to be set once
        {
            get => actualConditionNumber;
            set
            {
                if (actualConditionNumber == -384)
                {
                    actualConditionNumber = value;
                }
            }
        }
        public int NumberOfPotentialCustomers   // only allows it to be set once
        {
            get => numberOfPotentialCustomers;
            set
            {
                if (numberOfPotentialCustomers == -100)
                {
                    numberOfPotentialCustomers = value;
                }
            }
        }
        public void CreateCustomers(int percentTightWads,
                    int percentGenerous)
        {
            // we need NumberOfPotentialCustomers
            masterListOfCustomersForDay = new List<CustomerTightwadOrGenerous>();
            // create each customer
            int numberOfTightWads = Convert.ToInt32((Convert.ToDouble(percentTightWads) / 100) * Convert.ToDouble(numberOfPotentialCustomers));
            // create tightwads
            int i;
            for (i = 0; i < numberOfTightWads; i++)
            {
                masterListOfCustomersForDay.Add(new CustomerTightwadOrGenerous(true, false));
            }
            int numberOfGenerous = Convert.ToInt32((Convert.ToDouble(percentGenerous) / 100) * Convert.ToDouble(numberOfPotentialCustomers));
            int i2;
            for (i2 = i; i2 < numberOfTightWads + numberOfGenerous; i2++)
            {
                masterListOfCustomersForDay.Add(new CustomerTightwadOrGenerous(false, true));
            }
            // Create the rest in the middle
            int i3;
            for (i3 = i2; i3 < numberOfPotentialCustomers; i3++)
            {
                masterListOfCustomersForDay.Add(new CustomerTightwadOrGenerous(false, false));
            }
            //Console.WriteLine(masterListOfCustomersForDay.Count);
        }

        public void ScoreCustomers(
                    int percentTightWads,
                    int percentGenerous,
                    int startingScore,
                    int weatherWeight,
                    int recipeWeight,
                    int priceWeight
                    )
        {
            for (int i = 0; i < masterListOfCustomersForDay.Count; i++)
            {
                masterListOfCustomersForDay[i].weatherWeight = weatherWeight;
                masterListOfCustomersForDay[i].recipeWeight = recipeWeight;
                masterListOfCustomersForDay[i].priceWeight = priceWeight;
                masterListOfCustomersForDay[i].score = startingScore + weatherWeight +
                    recipeWeight + priceWeight + masterListOfCustomersForDay[i].predispositionToBuy;
                Console.WriteLine($"{masterListOfCustomersForDay[i].isTightWad} {masterListOfCustomersForDay[i].isGenerous}, score = {masterListOfCustomersForDay[i].score}");
            }
            Console.WriteLine(masterListOfCustomersForDay.Count);
        }
    }
}