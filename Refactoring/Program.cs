using Refactoring.Models;
using Refactoring.Services;
using Refactoring.ViewModel;
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

            var weatherVM = new ViewWeatherVM();
            var weathers = weatherVM.GetWeathers(zipCodes);

            WriteWeathers(weathers);
        }

        private static void WriteWeathers(List<Weather> weathers)
        {
            foreach(var w in weathers)
            {
                Console.WriteLine($"ZipCode: {w.ZipCode}");
                Console.WriteLine($"\t {w.TemperaturInFahrenheit}F/{w.TemperaturInCelsius}C");
                Console.WriteLine($"\t {w.SkyConditions}");
                Console.WriteLine($"\t Winds {w.WindDirection} {w.WindSpeed} MPH");
                Console.WriteLine();
            }
        }

    }
}
