using Assignment22_WeatherApp.Models;
using Assignment22_WeatherApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment22_WeatherApp.Controllers;

public class WeatherController(IWeatherService weatherService) : Controller
{
    private readonly IWeatherService _weatherService = weatherService;

    [Route("/")]
    [HttpGet]
    public IActionResult Index()
    {
        return View(_weatherService.GetWeatherDetails());
    }
    [Route("/weather/{cityCode}")]
    [HttpGet]
    public IActionResult CityWeather([FromRoute] string? cityCode)
    {
        if (cityCode == null)
        {
            return BadRequest();
        }

        var cityWeather = _weatherService.GetWeatherByCityCode(cityCode);

        if (cityWeather == null)
        {
            return BadRequest();
        }

        return View(cityWeather);
    }
}
