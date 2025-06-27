namespace DTO.StockResponseDTO;

public class StockResponseDTO
{
    public string MakeName { get; set; }
    public string ModelName { get; set; }
    public int MakeYear { get; set; }
    public decimal Price { get; set; }
    public int DrivenKms { get; set; }
    public string FuelType { get; set; }
    public string CityName { get; set; }
    public string CarName { get; set; }
    public string FormattedPrice { get; set; }
    public bool isValueForMoney { get; set; }
    public string imageUrl { get; set; }
}

