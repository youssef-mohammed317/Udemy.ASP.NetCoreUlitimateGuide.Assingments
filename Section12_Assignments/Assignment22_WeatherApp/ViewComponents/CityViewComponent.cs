using Assignment22_WeatherApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment22_WeatherApp.ViewComponents;

public class CityViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(CityWeather city, string link, string linkText, bool needColor)
    {
        if (needColor)
        {

            if (city.TemperatureFahrenheit < 44)
            {
                ViewBag.Color = "blue-back";
            }
            else if (city.TemperatureFahrenheit < 74)
            {
                ViewBag.Color = "green-back";
            }
            else
            {
                ViewBag.Color = "orange-back";
            }
        }
        else
        {
            ViewBag.Color = "";
        }

        ViewBag.Link = link;
        ViewBag.LinkText = linkText;

        return View(city);
    }
}