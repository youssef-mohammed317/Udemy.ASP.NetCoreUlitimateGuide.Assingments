using Assignment22_WeatherApp.Models;
using Assignment22_WeatherApp.Services.Interfaces;

namespace Assignment22_WeatherApp.Services.Implementations;

public class WeatherService : IWeatherService
{
    private readonly List<CityWeather> _cityWeathers;
    public WeatherService()
    {
        _cityWeathers = new List<CityWeather>
        {
            new CityWeather
            {
                CityUniqueCode = "LDN",
                CityName = "London",
                DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),
                TemperatureFahrenheit = 33
            },
            new CityWeather
            {
                CityUniqueCode = "NYC",
                CityName = "London",
                DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),
                TemperatureFahrenheit = 60
            },
            new CityWeather
            {
                CityUniqueCode = "PAR",
                CityName = "Paris",
                DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),
                TemperatureFahrenheit = 82
            }
        };
    }
    public CityWeather? GetWeatherByCityCode(string CityCode)
    {
        return _cityWeathers.FirstOrDefault(city => city.CityUniqueCode?.ToLower() == CityCode.ToLower());
    }

    public List<CityWeather> GetWeatherDetails()
    {
        return _cityWeathers;
    }
}
