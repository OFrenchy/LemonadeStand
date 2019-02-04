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
        private int rainChancePercent = -10;
        private string forecastWeatherConditions = "Clear Skies";
        private string actualWeatherConditions = "Clear Skies";
        private int numberOfPotentialCustomers = -100;
        public int dayNumber;

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
    }
}