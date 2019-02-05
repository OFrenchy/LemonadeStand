using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LemonadeStand
{
    public class Weather
    {
        public string[] conditionsList = {"rain", "overcast", "mostly cloudy",
            "partly cloudy", "mostly sunny", "clear"};
        // TODO - change conditions & temperatures to be properties
        private List<int> conditions;
        private List<int> temperatures;
        private List<int> chancesOfRainPercent;

        private List<int> actualConditions;
        private List<int> actualTemperatures;


        // the base temperature for mid-July, from which we deviate + or -
        private int baseTemperature = 85;

        public Weather(int numberOfDays)
        {
            //Thread.Sleep(20);
            Random randomGenerator = new Random(); // needs to be outside of loop so numbers can be random
            // generate forecast temperatures & weather conditions, & % chance of rain
            // for the next numberOfDays
            // generate actual temperatures & weather conditions for the same period
            conditions = new List<int>();
            temperatures = new List<int>();
            chancesOfRainPercent = new List<int>();
            actualConditions = new List<int>();
            actualTemperatures = new List<int>();
            for (int i = 0; i < numberOfDays; i++)
            {
                // For the overall weather conditions, 
                // generate a random number between 0 & 5 
                // which corresponds to the list of conditions (strings) above, 
                // then add that number to as day's condition 
                conditions.Add(randomGenerator.Next(5));
                // For the temperatures, 
                // generate a random number between 0 & 10, then
                // generate a coin flip to decide whether to add or subtract that 
                // number from the baseTemperature

                // TODO - figure out which is better
                //temperatures.Add(generateTemperatureGuess(baseTemperature));
                temperatures.Add(randomGenerator.Next(75, 95));

                // chance of rain is from 0% to 100% in 10% increments
                chancesOfRainPercent.Add(randomGenerator.Next(10) * 10);

                // Moved to SetActualWeatherForDay
                //// TODO - move to method called after each player has gone through prep screen
                //// for the actual weather (temp & conditions), 
                //// repeat the above algorithms - why not, the forecast vs. actual 
                //// weather can vary that much
                //actualConditions.Add(randomGenerator.Next(5));
                //// TODO - figure out which is better
                ////actualTemperatures.Add(generateTemperatureGuess(baseTemperature));
                //actualTemperatures.Add(randomGenerator.Next(75, 95));

            } // i = each day
        } // weather instantiated

        private int generateTemperatureGuess(int baseTemperature)
        {
            // generate a random number between 0 & 10, then
            // generate a coin flip to decide whether to add or subtract that 
            // number from the baseTemperature (typically baseTemperature is 85 degrees)
            Random randomGenerator = new Random();
            int addSubtract = randomGenerator.Next(1);
            if (addSubtract == 0)
            {
                // TODO - ask a professional how to do an "inline if" - 
                return baseTemperature + randomGenerator.Next(10);
            }
            else
            {
                return baseTemperature - randomGenerator.Next(10);
            }
        }

        public void affectCustomersMoods()
        {
            throw new System.NotImplementedException();
        }

        public void GetForecast(Day day)
        {
            // set forecast values of temperature, conditions, 
            // and percent chance of rain for the requested day
            day.ForecastTemperature = temperatures[day.dayNumber];
            day.ForecastWeatherConditions = conditionsList[conditions[day.dayNumber]];
            day.RainChancePercent = chancesOfRainPercent[day.dayNumber];
        }
        public void SetActualWeatherForDay(Day day)
        {
            // for the actual weather (temp & conditions), we can use a random number; 
            // the forecast vs. actual weather can vary that much
            Random randomGenerator = new Random();
            actualConditions.Add(randomGenerator.Next(5));
            // TODO - figure out which is better
            //actualTemperatures.Add(generateTemperatureGuess(baseTemperature));
            actualTemperatures.Add(randomGenerator.Next(75, 95));

            
            // set actual temperature & conditions for the requested day
            day.ActualTemperature = actualTemperatures[day.dayNumber - 1];
            day.ActualConditionNumber = actualConditions[day.dayNumber - 1];
            day.ActualWeatherConditions = conditionsList[actualConditions[day.dayNumber - 1]];
        }

        public void affectCustomerTurnout(int initialNumberOfPotentialCustomers, Day day)
        {
            // Depending on the forecast, change the turnout as follows:
            // 0 rain reduce turnout by 12
            // 1 overcast reduce by 6
            // 2 mostly cloudy, don't change the number of customers 
            // 3 partly cloudy, increase by 6;
            // 4 mostly sunny, increase by 12, 
            // 5 clear increase by 18

            //{"rain", "overcast", "mostly cloudy", "partly cloudy", "mostly sunny", "clear"}
            
            int[] weatherAffects = {-12, -6, 0, 6, 12, 18};
            day.NumberOfPotentialCustomers = initialNumberOfPotentialCustomers + 
                weatherAffects[conditions[day.dayNumber]];
        }
    }




    
}