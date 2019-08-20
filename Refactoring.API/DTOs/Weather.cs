using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refactoring.API.DTOs
{
    public class Weather
    {
        public string ZipCode { get; set; }
        public int TemperaturInFahrenheit { get; set; }
        public int PrecipitationChance { get; set; }
        public string SkyConditions { get; set; }
        public int WindSpeed { get; set; }
        public string WindDirection { get; set; }
    }
}
