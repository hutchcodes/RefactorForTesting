using Refactoring.Models;
using Refactoring.Services;
using System;
using System.Collections.Generic;

namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var input = Console.ReadLine();

            var zipCodes = input.Split(' ');

            var weathers = GetWeathers(zipCodes);

            WriteWeathers(weathers);

        }

        static List<Weather> GetWeathers(string[] zipCodes)
        {
            var weatherService = new WeatherService();
            var weathers =  new List<Weather>();

            foreach(var zipCode in zipCodes)
            {
                var weather = weatherService.GetWeatherForZip(zipCode);
            }

            return weathers;
        }

        private static void WriteWeathers(List<Weather> weathers)
        {
            foreach(var w in weathers)
            {
                Console.WriteLine($"ZipCode: {w.ZipCode}");
                Console.WriteLine($"/t {w.TemperaturInFahrenheit}F/{w.TemperaturInCelsius}C");
                Console.WriteLine($"ZipCode: {w.SkyConditions}");
                Console.WriteLine();
            }
        }

    }
}
