using Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Services
{
    class WeatherService : WebServiceBase 
    {
        public WeatherService() : base("https://localhost:44359/") { }

        public Weather GetWeatherForZip(string zipCode)
        {
            var request = this.GetRestRequest($"CurrentWeather//{zipCode}", RestSharp.Method.GET);

            var weather = Execute<Weather>(request);

            return weather;
        }
    }

}
