using Refactoring.Models;
using Refactoring.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.ViewModel
{
    public class ViewWeatherVM
    {
        private IWeatherService _iWeatherService;
        public ViewWeatherVM(IWeatherService weatherService = null)
        {
            _iWeatherService = weatherService ?? new WeatherService();
        }
        public List<Weather> GetWeathers(string[] zipCodes)
        {
            var weathers = new List<Weather>();

            foreach (var zipCode in zipCodes)
            {
                var weather = _iWeatherService.GetWeatherForZip(zipCode);
                weathers.Add(weather);
            }

            return weathers;
        }
    }
}
