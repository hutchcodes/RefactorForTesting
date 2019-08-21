using Microsoft.AspNetCore.Mvc;
using Refactoring.API.DTOs;
using System;
using System.Collections.Generic;

namespace Refactoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentWeatherController : ControllerBase
    {
        private static Dictionary<string, Weather> _currentWeathers;

        public CurrentWeatherController()
        {
            if (_currentWeathers == null)
            {
                _currentWeathers = GetDummyWeather();
            }
        }

        // GET api/values/90210
        [HttpGet("{zipCode}")]
        public ActionResult<Weather> GetWeatherForZip(string zipCode)
        {
            if (!int.TryParse(zipCode, out int intZipCode) || intZipCode.ToString().PadLeft(5, '0') != zipCode)
            {
                throw new ArgumentException("ZipCode provided was not valid");
            }

            if (_currentWeathers.ContainsKey(zipCode))
            {
                return _currentWeathers[zipCode];
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private Dictionary<string, Weather> GetDummyWeather()
        {
            var weathers = new Dictionary<string, Weather>
            {
                {
                    "90210",
                    new Weather
                    {
                        ZipCode = "90210",
                        TemperaturInFahrenheit = 72,
                        PrecipitationChance = 20,
                        SkyConditions = "Partly Sunny",
                        WindDirection = "NW",
                        WindSpeed = new Random().Next(0, 25)
                    }
                },
                {
                    "04103",
                    new Weather
                    {
                        ZipCode = "04103",
                        TemperaturInFahrenheit = 68,
                        PrecipitationChance = 40,
                        SkyConditions = "Partly Cloudy",
                        WindDirection = "SE",
                        WindSpeed = new Random(DateTime.Now.Millisecond).Next(0, 25)
                    }
                },
                {
                    "04050",
                    new Weather
                    {
                        ZipCode = "04050",
                        TemperaturInFahrenheit = 68,
                        PrecipitationChance = 45,
                        SkyConditions = "Foggy",
                        WindDirection = "SE",
                        WindSpeed = new Random().Next(0, 25)
                    }
                }
            };

            return weathers;
        }
    }
}
