using Refactoring.Models;

namespace Refactoring.Services
{
    public interface IWeatherService
    {
        Weather GetWeatherForZip(string zipCode);
    }
}