using Assignment14_WeatherApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment14_WeatherApp.Controllers;

public class WeatherController : Controller
{
    private readonly List<CityWeather> _cityWeathers;
    public WeatherController()
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

    [Route("/")]
    [HttpGet]
    public IActionResult Index()
    {
        return View(_cityWeathers);
    }
    [Route("/weather/{cityCode}")]
    [HttpGet]
    public IActionResult CityWeather([FromRoute] string? cityCode)
    {
        if (cityCode == null)
        {
            return BadRequest();
        }

        var cityWeather = _cityWeathers.FirstOrDefault(city => city.CityUniqueCode?.ToLower() == cityCode?.ToLower());

        if (cityWeather == null)
        {
            return BadRequest();
        }

        return View(cityWeather);
    }
}
