using Entities.Stock;
public interface IRepository
{
    public Task<List<Stock>> FetchStocks(List<int> IdList);
}