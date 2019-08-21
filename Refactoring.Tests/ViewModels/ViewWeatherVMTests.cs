using NUnit.Framework;
using Refactoring.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Tests.ViewModels
{
    class ViewWeatherVMTests
    {
        [Test]
        public void Should_get_weather()
        {
            var vm = new ViewWeatherVM();

            var weathers = vm.GetWeathers(new string[] { "04103" });

            Assert.AreEqual(1, weathers.Count);
            Assert.AreEqual("04103", weathers[0].ZipCode);
            Assert.AreEqual(68, weathers[0].TemperaturInFahrenheit);
            //Assert.AreEqual(13, weathers[0].WindSpeed);
        }
    }
}
