using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Weather
    {
        //private int forecastTemperature = -384;
        //private int actualTemperature = -384;
        //private int rainChancePercent = -10;
        //private string forecastWeatherConditions = "Clear Skies";
        //private string actualWeatherConditions = "Clear Skies";

        public string[] conditionsList = { "rain", "overcast", "mostly cloudy",
            "partly cloudy", "mostly sunny", "clear" };
        // TODO - change conditions & temperatures to be properties
        public List<int> conditions;
        public List<int> temperatures;
        public List<int> chancesOfRainPercent;

        private int baseTemperature = 85;

        public Weather(int numberOfDays)
        {
            // generate forecast temperatures & weather conditions for the next numberOfDays
            // generate forecast weather conditions for the next numberOfDays
            conditions = new List<int>();
            temperatures = new List<int>();
            chancesOfRainPercent = new List<int>();
            for (int i = 0; i < numberOfDays; i++)
            {
                Random randomGenerator = new Random();
                
                // For the overall weather conditions, 
                // generate a random number between 0 & 5 
                // which corresponds to the list of conditions (strings) above, 
                // then add that number to as day's condition 
                int condition = randomGenerator.Next(5);
                conditions.Add(condition);

                chancesOfRainPercent.Add(randomGenerator.Next(10) * 10);

                // For the temperatures, 
                // generate a random number between 0 & 15, then
                // generate a coin flip to decide whether to add or subtract that 
                // number from the baseTemperature
                int addlTemp = randomGenerator.Next(15);
                int addSubtract = randomGenerator.Next(1);
                if (addSubtract == 0)
                {
                    temperatures.Add(baseTemperature + addlTemp);
                }
                else
                {
                    temperatures.Add(baseTemperature - addlTemp);
                }
                //Console.WriteLine(baseTemperature.ToString(), addSubtract, addlTemp);
            }
            //Console.WriteLine(conditions.ToString(), temperatures);
        }

            public void affectCustomersMoods()
        {
            throw new System.NotImplementedException();
        }

        public void GetForecast()
        {
            // Set up a forecast for the next 7 or more days
            // consisting of temperature, conditions
            // Conditions will have a range from 
            // 0 rain, 1 overcast, 2 mostly cloudy, 3 partly cloudy, 4sunny
            // 

            // throw new System.NotImplementedException();
        }

        public void SetActualWeatherForDay()
        {
            throw new System.NotImplementedException();
        }
    }
}