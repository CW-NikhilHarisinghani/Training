namespace Entities.Stock;

public class Stock
{
    public int StockId { get; set; }
    public string MakeName { get; set; }
    public string ModelName { get; set; }
    public int MakeYear { get; set; }
    public decimal Price { get; set; }
    public int DrivenKms { get; set; }
    public string FuelType { get; set; }
    public string CityName { get; set; }
    public bool IsValueForMoney { get; set; }
    public string image_url{ get; set; }
}
