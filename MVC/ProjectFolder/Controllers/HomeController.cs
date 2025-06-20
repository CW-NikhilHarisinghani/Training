using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectFolder.Models;
using ProjectFolder.Models;

namespace ProjectFolder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var grah = new DataSharing
        {
            Name = "John Doe",
            Email = "@gamil.com",
            Message = "Hello, this is a test message.",
            IsChecked = true
        };
        // pass a paramter to the view
        
        return View(grah);
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
