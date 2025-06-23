using Microsoft.AspNetCore.Mvc;
using DTO.StockRequestDTO;
using Helper.StockHelper;
using BuisnessAccessLayer.StockBAL;
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    StockBAL stockBal;
    public StockController(StockBAL _stockBal)
    {
        stockBal = _stockBal;
    }
    [HttpGet]
    public IActionResult GetStocks([FromQuery] StockRequestDTO stockRequest)
    {
        Console.WriteLine(stockRequest.FuelType, " ", stockRequest.Budget);
        if (StockHelper.IsRequestValid(stockRequest) == false)
        {
            return BadRequest(new
            {
                message = "Invalid request format. Expected format: digits-digits.",
                example = "123-456"
            });
        }
        stockBal.FindStock(stockRequest);
        return Ok(new List<object>());
    }

}