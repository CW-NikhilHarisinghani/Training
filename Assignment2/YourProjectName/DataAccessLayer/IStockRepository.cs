namespace DataAccessLayer.IStockRepository;

using Entities.Stock;
using Entities.StockRequest;

public interface IStockRepository
{
    Task<IEnumerable<Stock>> FetchStocks(StockRequest stockParams);
}