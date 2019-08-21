using NUnit.Framework;
using Refactoring.Models;
using Refactoring.Services;
using Refactoring.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;

namespace Refactoring.Tests.ViewModels
{
    class ViewWeatherVMTests
    {
        [Test]
        public void Should_get_weather()
        {
            var weatherServiceMock = Mock.Create<IWeatherService>();
            Mock.Arrange(() => weatherServiceMock.GetWeatherForZip(Arg.AnyString))
                .Returns(() => new Weather { ZipCode = "12345", TemperaturInFahrenheit = 68, WindSpeed = 8 });

            var vm = new ViewWeatherVM(weatherServiceMock);

            var weathers = vm.GetWeathers(new string[] { "04103" });

            Assert.AreEqual(1, weathers.Count);
            Assert.AreEqual("12345", weathers[0].ZipCode);
            Assert.AreEqual(68, weathers[0].TemperaturInFahrenheit);
            Assert.AreEqual(8, weathers[0].WindSpeed);
        }

        [Test]
        public void Should_get_multiple_weathers()
        {
            var weatherServiceMock = Mock.Create<IWeatherService>();
            Mock.Arrange(() => weatherServiceMock.GetWeatherForZip("12345"))
                .Returns(() => new Weather { ZipCode = "12345", TemperaturInFahrenheit = 68, WindSpeed = 8 });

            Mock.Arrange(() => weatherServiceMock.GetWeatherForZip("04103"))
                .Returns(() => new Weather { ZipCode = "04103", TemperaturInFahrenheit = 68, WindSpeed = 8 });

            var vm = new ViewWeatherVM(weatherServiceMock);

            var weathers = vm.GetWeathers(new string[] { "12345", "04103" });

            Assert.AreEqual(2, weathers.Count);
            Assert.AreEqual("12345", weathers[0].ZipCode);
            Assert.AreEqual(68, weathers[0].TemperaturInFahrenheit);
            Assert.AreEqual(8, weathers[0].WindSpeed);

            Assert.AreEqual("04103", weathers[1].ZipCode);
        }
    }
}
