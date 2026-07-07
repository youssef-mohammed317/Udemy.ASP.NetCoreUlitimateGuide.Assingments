using Assignment22_WeatherApp.Models;

namespace Assignment22_WeatherApp.Services.Interfaces;

public interface IWeatherService
{
    List<CityWeather> GetWeatherDetails();

    CityWeather? GetWeatherByCityCode(string CityCode);
}
