using Entities.Stock;

public class ValueForMoney : IValueForMoney
{
    private readonly IRepository _repository;

    public ValueForMoney(IRepository repository)
    {
        _repository = repository;
    }

    public bool rules(Stock stock)
    {
        int currentYear = DateTime.Now.Year;
        int stockMakeYear = stock.MakeYear;
        int counter = 0;
        if (currentYear - stockMakeYear <= 5) counter++;
        if (stock.DrivenKms <= 100000) counter++;
        if (stock.Price <= 2000000) counter++;
        if (stock.FuelType == "Hybrid" || stock.FuelType == "Electric" || stock.FuelType == "CNG") counter++;
        return counter >= 3;
    }
    public async Task<List<bool>> compute(List<int> IdList)
    {
        var response = await _repository.FetchStocks(IdList);
        List<bool> dto_response = new List<bool>();
        foreach (var stock in response)
        {
            dto_response.Add(rules(stock));
        }
        return dto_response;
    }
}