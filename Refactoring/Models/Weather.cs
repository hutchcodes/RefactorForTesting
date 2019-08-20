using Refactoring.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refactoring.Models
{
    public class Weather
    {
        private int _temperaturInFahrenheit;
        public string ZipCode { get; set; }
        public int TemperaturInFahrenheit
        {
            get
            {
                return _temperaturInFahrenheit;
            }
            set
            {
                _temperaturInFahrenheit = value;
            }
        }
        public int TemperaturInCelsius
        {
            get
            {
                return (int)TemperatureConverter.ConvertToCelsius(_temperaturInFahrenheit);
            }
            set
            {
                _temperaturInFahrenheit = TemperatureConverter.ConvertToFahrenheit(value);
            }
        }
        public int PrecipitationChance { get; set; }
        public string SkyConditions { get; set; }
        public int WindSpeed { get; set; }
        public string WindDirection { get; set; }
    }
}
