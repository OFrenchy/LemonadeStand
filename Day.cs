using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {
        // TODO - change to be properties, 
        // TODO - change to be values obtained from the Weather object
        //private int forecastTemperature = 35;
        //private int rainChancePercent = 10;
        //private string forecastWeatherConditions = "Clear Skies";
        private int forecastTemperature = -384;
        private int actualTemperature = -384;
        private int actualConditionNumber = -384;
        private int rainChancePercent = -10;
        private string forecastWeatherConditions = "Clear Skies";
        private string actualWeatherConditions = "Clear Skies";
        private int numberOfPotentialCustomers = -100;
        public int dayNumber;

        //TODO - chg to be private?
        public List<Customer> masterListOfCustomersForDay;

        //forecastTemperature.ToString()} degrees and {day.forecastWeatherConditions

        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
        }

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
        public int ForecastTemperature
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
        public string ForecastWeatherConditions
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
        public int RainChancePercent
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
        public int ActualTemperature
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
        public string ActualWeatherConditions
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
        public int ActualConditionNumber
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
        public int NumberOfPotentialCustomers
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
        public void CreateCustomers()
        {
            //public List<Customer> masterListOfCustomersForDay;
            
            // we need NumberOfPotentialCustomers
            masterListOfCustomersForDay = new List<Customer>();
            // create each customer
            for (int i = 0; i < numberOfPotentialCustomers; i++)
            {
                masterListOfCustomersForDay.Add(new Customer());
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
            //public List<Customer> masterListOfCustomersForDay;
            //startingWeight 
            if (percentTightWads + percentGenerous > 100)
            {
                // set both to 0
                percentTightWads = 0;
                percentGenerous = 0;
            }

            // we need NumberOfPotentialCustomers
            //masterListOfCustomersForDay = new List<Customer>();
            int numberOfTightWads = Convert.ToInt32((Convert.ToDouble(percentTightWads) / 100) * Convert.ToDouble(numberOfPotentialCustomers));
            // create tightwads
            int i;
            for(i = 0; i < numberOfTightWads; i++)
            {
                //masterListOfCustomersForDay.Add(new Customer(true, false, weatherWeight));
                masterListOfCustomersForDay[i].isTightWad = true;
                masterListOfCustomersForDay[i].isGenerous = false;
                masterListOfCustomersForDay[i].weatherWeight = weatherWeight;
                masterListOfCustomersForDay[i].recipeWeight = recipeWeight;
                masterListOfCustomersForDay[i].priceWeight = priceWeight;

                masterListOfCustomersForDay[i].score = startingScore + weatherWeight +
                    recipeWeight + priceWeight - 1;
                Console.WriteLine($"isTightWad = true, isGenerous = false, score = {masterListOfCustomersForDay[i].score}");
            }
            int numberOfGenerous = Convert.ToInt32((Convert.ToDouble(percentGenerous) / 100) * Convert.ToDouble(numberOfPotentialCustomers));
            int i2;
            for (i2 = i; i2 <  numberOfTightWads + numberOfGenerous; i2++)
            {
                //masterListOfCustomersForDay.Add(new Customer(true, false, weatherWeight));
                masterListOfCustomersForDay[i2].isTightWad = false;
                masterListOfCustomersForDay[i2].isGenerous = true;
                masterListOfCustomersForDay[i2].weatherWeight = weatherWeight;
                masterListOfCustomersForDay[i2].recipeWeight = recipeWeight;
                masterListOfCustomersForDay[i2].priceWeight = priceWeight;

                masterListOfCustomersForDay[i2].score = startingScore + weatherWeight +
                    recipeWeight + priceWeight + 1;
                Console.WriteLine($"isTightWad = false, isGenerous = true, score = {masterListOfCustomersForDay[i2].score}");
            }
            // reset the rest in the middle
            int i3;
            for (i3 = i2; i3 < numberOfPotentialCustomers; i3++)
            {
                masterListOfCustomersForDay[i3].isTightWad = false;
                masterListOfCustomersForDay[i3].isGenerous = false;
                masterListOfCustomersForDay[i3].weatherWeight = weatherWeight;
                masterListOfCustomersForDay[i3].recipeWeight = recipeWeight;
                masterListOfCustomersForDay[i3].priceWeight = priceWeight;

                masterListOfCustomersForDay[i3].score = startingScore + weatherWeight +
                    recipeWeight + priceWeight;
                Console.WriteLine($"isTightWad = false, isGenerous = false, score = {masterListOfCustomersForDay[i3].score}");
            }
            Console.WriteLine(masterListOfCustomersForDay.Count);
        }
    }
}