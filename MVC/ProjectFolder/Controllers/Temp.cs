using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectFolder.Models;

namespace ProjectFolder.Controllers;
// [ApiController]
[Route("api/[controller]")]
public class TempController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
      return Ok(new { Id = id, Name = "Sample Product" });
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    internal string Description { get; set; } = "This is a laptop.";
    protected string Category { get; set; } = "Electronics";
}
/*
only the public members of the Product class are accessible outside the class.
The `Id` and `Name` properties are public, so they can be accessed from outside
*/