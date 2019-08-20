using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Converters
{
    public class TemperatureConverter
    {
        public static int ConvertToCelsius(int tempF)
        {
            var tempC = (5d / 9d) * (tempF - 32); 
            return (int)tempC;
        }

        public static int ConvertToFahrenheit(int tempC)
        {
            var tempF = (9d / 5d) * tempC + 32;
            return (int)tempF;
        }
    }
}
