using NUnit.Framework;
using Refactoring.Helpers;
using Refactoring.Models;
using Refactoring.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;

namespace Refactoring.Tests.Services
{
    class WeatherServiceTests
    {
        [Test]
        public void Should_get_weather()
        {
            var ws = new WeatherService();

            var weather = ws.GetWeatherForZip("04103");

            Assert.AreEqual("04103", weather.ZipCode);
            Assert.AreEqual(68, weather.TemperaturInFahrenheit);
            //Assert.AreEqual(13, weather.WindSpeed);

        }






















        public void Should_get_weather_DI()
        {
            IRestRequest myRequest = null;
            var httpHelperMock = Mock.Create<IHttpHelper>();
            Mock.Arrange(() => httpHelperMock.Execute<Weather>(Arg.IsAny<IRestRequest>()))
                .DoInstead((IRestRequest request) => { myRequest = request; })
                .Returns(() => new Weather { ZipCode = "12345", TemperaturInFahrenheit = 68, WindSpeed = 8 })
                .OccursOnce();

            //var ws = new WeatherService(httpHelperMock);

            //var weather = ws.GetWeatherForZip("04103");

            //Assert.AreEqual("12345", weather.ZipCode);
            //Assert.AreEqual(68, weather.TemperaturInFahrenheit);
            //Assert.AreEqual(8, weather.WindSpeed);
        }
    }
}
