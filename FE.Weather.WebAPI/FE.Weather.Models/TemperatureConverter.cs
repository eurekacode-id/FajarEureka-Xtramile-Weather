using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Models
{
    public static class TemperatureConverter
    {
        public static double CelciusToFahrenheit(double temperatureCelcius)
        {
            double fahrenheit = (temperatureCelcius * 9 / 5) + 32;
            return fahrenheit;
        }

        public static double FahrenheitToCelcius(double temperatureFahrenheit)
        {
            double celcius = (temperatureFahrenheit - 32) * 5 / 9;
            return celcius;
        }

        public static double KelvinToCelcius(double temperatureKelvin)
        {
            double celcius = temperatureKelvin - 273.15;
            return celcius;
        }
    }
}
