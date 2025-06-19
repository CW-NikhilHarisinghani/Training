using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectFolder.Models;

namespace ProjectFolder.Controllers;

public class GharController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public GharController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ViewResult Index()
    {
        _logger.LogInformation("Index action called");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
