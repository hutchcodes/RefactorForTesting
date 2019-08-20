using NUnit.Framework;
using Refactoring.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Tests.Converters
{
    class TemperatureConverterTests
    {
        [Test]
        public void Should_convert_to_Celsius()
        {
            var tempC = TemperatureConverter.ConvertToCelsius(68);

            Assert.AreEqual(20, tempC);
        }

        [Test]
        public void Should_convert_to_Fahrenheit()
        {
            var tempF = TemperatureConverter.ConvertToFahrenheit(20);

            Assert.AreEqual(68, tempF);
        }
    }
}
