using Enum.FuelTypesEnum;

namespace Entities.StockRequest;

public class StockRequest
{
    public int? minBudget { get; set; }
    public int? maxBudget { get; set; }

    public List<FuelTypesEnum> fuels;
}