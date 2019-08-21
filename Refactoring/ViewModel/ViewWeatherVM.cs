using Refactoring.Models;
using Refactoring.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.ViewModel
{
    public class ViewWeatherVM
    {
        public List<Weather> GetWeathers(string[] zipCodes)
        {
            var weatherService = new WeatherService();
            var weathers = new List<Weather>();

            foreach (var zipCode in zipCodes)
            {
                var weather = weatherService.GetWeatherForZip(zipCode);
                weathers.Add(weather);
            }

            return weathers;
        }
    }
}
