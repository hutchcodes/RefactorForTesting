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





















        [Test]
        public void Should_get_weather_DI()
        {
            IRestRequest myRequest = null;
            var httpHelperMock = Mock.Create<IHttpHelper>();
            Mock.Arrange(() => httpHelperMock.Execute<Weather>(Arg.IsAny<IRestRequest>()))
                .DoInstead((IRestRequest request) => { myRequest = request; })
                .Returns(() => new Weather { ZipCode = "12345", TemperaturInFahrenheit = 68, WindSpeed = 8 })
                .OccursOnce();

            Mock.Arrange(() => httpHelperMock.GetRestRequest(Arg.AnyString, Arg.IsAny<Method>(), Arg.IsAny<DataFormat>()))
                .Returns((string resource, Method method, DataFormat dataFormat) =>
                {
                    var httpHelper = new HttpHelper("http://Foo/");
                    return httpHelper.GetRestRequest(resource, method, dataFormat);
                });

            var ws = new WeatherService(httpHelperMock);

            var weather = ws.GetWeatherForZip("04103");

            Assert.AreEqual("12345", weather.ZipCode);
            Assert.AreEqual(68, weather.TemperaturInFahrenheit);
            Assert.AreEqual(8, weather.WindSpeed);

            Assert.AreEqual("GET", myRequest.Method.ToString());
            Assert.AreEqual("CurrentWeather/04103", myRequest.Resource);
        }

        [Test]
        public void Should_throw_exception()
        {
            IRestRequest myRequest = null;
            var httpHelperMock = Mock.Create<IHttpHelper>();
            Mock.Arrange(() => httpHelperMock.Execute<Weather>(Arg.IsAny<IRestRequest>()))
                .OccursNever();

            var ws = new WeatherService(httpHelperMock);

            Assert.Throws<ArgumentException>(() => ws.GetWeatherForZip("00000"));

        }
    }
}
