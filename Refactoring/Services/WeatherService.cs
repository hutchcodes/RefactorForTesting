using Refactoring.Helpers;
using Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Services
{
    internal class WeatherService : IWeatherService
    {
        IHttpHelper _httpHelper;
        public WeatherService(IHttpHelper httpHelper = null)
        {
            _httpHelper = httpHelper ?? new HttpHelper("https://localhost:44359/api");
        }

        public Weather GetWeatherForZip(string zipCode)
        {
            if (zipCode == "00000")
            {
                throw new ArgumentException("Foo");
            }
            var request = _httpHelper.GetRestRequest($"CurrentWeather/{zipCode}", RestSharp.Method.GET);

            var weather = _httpHelper.Execute<Weather>(request);

            return weather;
        }
    }

}
