namespace DataAccessLayer.StockRepository;

using DataAccessLayer.DapperContext;
using Entities.StockRequest;
using Entities.Stock;
using Dapper;
using DataAccessLayer.IStockRepository;

public class StockRepository : IStockRepository
{
    private readonly DapperContext _context;

    public StockRepository(DapperContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Stock>> FetchStocks(StockRequest stockParams)
    {
        try
        {
            using var connection = _context.CreateConnection();
            var query = "SELECT * FROM Stocks";

            var hasBudget = stockParams.maxBudget != null;
            var hasFuels = stockParams.fuels.ToArray().Length > 0;

            if (hasBudget)
            {
                query += " WHERE price BETWEEN @MinBudget AND @MaxBudget";
            }

            if (hasFuels)
            {
                query += hasBudget ? " AND" : " WHERE";
                query += " FuelType IN @FuelTypes";
            }

            var parameters = new
            {
                MinBudget = hasBudget ? stockParams.minBudget * 100000 : null,
                MaxBudget = hasBudget ? stockParams.maxBudget * 100000 : null,
                FuelTypes = stockParams.fuels?.Select(f => f.ToString())
            };
            var res = await connection.QueryAsync<Stock>(query, parameters);
            return res;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}