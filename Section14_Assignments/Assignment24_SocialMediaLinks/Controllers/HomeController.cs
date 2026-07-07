using Assignment24_SocialMediaLinks.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assignment24_SocialMediaLinks.Controllers;

public class HomeController(IOptions<SocialMediaLinksOptions> options) : Controller
{
    [Route("/")]
    [HttpGet]
    public IActionResult Index()
    {
        return View(options.Value);
    }
}
