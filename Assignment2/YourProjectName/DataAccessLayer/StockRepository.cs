namespace DataAccessLayer.StockRepository;

using DataAccessLayer.DapperContext;
using Entities.StockRequest;

public class StockRepository
{
    private readonly DapperContext _context;

    public StockRepository(DapperContext context)
    {
        _context = context;
    }

    public async void FetchStocks(StockRequest stockParams)
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM Stocks";

        // [1,2,4,0]
    }
}