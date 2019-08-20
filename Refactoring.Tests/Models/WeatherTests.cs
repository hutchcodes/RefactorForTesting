using NUnit.Framework;
using Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Tests.Models
{
    class WeatherTests
    {
        [Test]
        public void Should_Convert_Temperature_To_Celsius()
        {
            var weather = new Weather
            {
                TemperaturInFahrenheit = 68
            };

            Assert.AreEqual(20, weather.TemperaturInCelsius);
        }

        [Test]
        public void Should_Convert_Temperature_To_Fahrenheit()
        {
            var weather = new Weather
            {
                TemperaturInCelsius = 20
            };

            Assert.AreEqual(68, weather.TemperaturInFahrenheit);
        }

        [TestCase(20)]
        [TestCase(25)]
        public void Should_Set_And_Get_Celsius(int tempC)
        {
            var weather = new Weather
            {
                TemperaturInCelsius = tempC
            };

            Assert.AreEqual(tempC, weather.TemperaturInCelsius);
        }
    }
}
