using Microsoft.AspNetCore.Mvc;
using DTO.StockRequestDTO;
using Helper.StockHelper;
using BuisnessAccessLayer.IStockBAL;
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly IStockBAL stockBal;
    public StockController(IStockBAL _stockBal)
    {
        stockBal = _stockBal;
    }
    [HttpGet]
    public async Task<IActionResult> GetStocks([FromQuery] StockRequestDTO stockRequest)
    {
        try
        {
            if (StockHelper.IsRequestValid(stockRequest) == false)
            {
                return BadRequest(new
                {
                    message = "Invalid request format."
                });
            }
            var res = await stockBal.FindStock(stockRequest);
            return Ok(res);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}