using Dapper;
using Entities.Stock;

public class Repository : IRepository
{
    public async Task<List<Stock>> FetchStocks(List<int> idList)
    {
        using var connection = DapperContext.CreateConnection();

        var query = "SELECT * FROM Stocks WHERE StockId IN @Ids";
        var stocks = await connection.QueryAsync<Stock>(query, new { Ids = idList });

        return stocks.ToList();
    }
}
