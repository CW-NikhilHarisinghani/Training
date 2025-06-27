using System.Text.Json;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace Helper.DataHelper;

public enum FuelType
{
    Petrol,
    Diesel,
    CNG,
    LPG,
    Electric,
    Hybrid
}

public class Stock
{
    public string MakeName { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public int MakeYear { get; set; }
    public decimal Price { get; set; }
    public int Kilometers { get; set; }
    public FuelType FuelType { get; set; } = FuelType.Petrol;
    public string CityName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}

public class ApiResponse
{
    public List<ApiStock> Stocks { get; set; } = new();
    public string? NextPageUrl { get; set; }
}

public class ApiStock
{
    public string MakeName { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public int MakeYear { get; set; }
    public string PriceNumeric { get; set; } = "0";
    public string KmNumeric { get; set; } = "0";
    public string Fuel { get; set; } = "Petrol";
    public string CityName { get; set; } = "";
    public string ImageUrl { get; set; } = "";
}

public class Pp
{
    private const string BaseUrl = "https://stg.carwale.com";
    private const string FirstPage = "/api/stocks/";
    private const string ConnectionString = "Server=localhost;Database=local;User Id=root;Password=Root@123;";

    public static async Task Main()
    {
        var client = new HttpClient();
        var nextPage = FirstPage;
        var totalInserted = 0;
        var insertedHashes = new HashSet<string>();

        while (!string.IsNullOrWhiteSpace(nextPage))
        {
            try
            {
                Console.WriteLine($"Fetching: {nextPage}");
                var response = await client.GetStringAsync(BaseUrl + nextPage);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<ApiResponse>(response, options);

                if (result?.Stocks == null || result.Stocks.Count == 0)
                {
                    Console.WriteLine("No stocks found.");
                    break;
                }

                foreach (var apiStock in result.Stocks)
                {
                    try
                    {
                        if (totalInserted >= 250)
                        {
                            Console.WriteLine("✅ Limit reached: 250 stocks inserted.");
                            return;
                        }

                        var stock = MapToStock(apiStock);

                        if (stock.MakeYear < 1990 || stock.MakeYear > DateTime.UtcNow.Year + 1)
                        {
                            Console.WriteLine($"Skipping unrealistic year: {stock.MakeYear}");
                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(stock.ImageUrl))
                        {
                            Console.WriteLine("Skipping stock due to missing ImageUrl.");
                            continue;
                        }

                        var hashKey = $"{stock.MakeName}|{stock.ModelName}|{stock.MakeYear}|{stock.Price}|{stock.Kilometers}|{(int)stock.FuelType}|{stock.CityName}";
                        if (insertedHashes.Contains(hashKey))
                        {
                            Console.WriteLine("Duplicate stock found. Skipping.");
                            continue;
                        }

                        var stockId = await SaveStockAsync(stock);
                        insertedHashes.Add(hashKey);
                        totalInserted++;

                        Console.WriteLine($"Inserted: {stock.MakeName} {stock.ModelName} (ID: {stockId})");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inserting stock: {ex.Message}");
                    }
                }

                nextPage = result.NextPageUrl;
                await Task.Delay(300);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching page: {ex.Message}");
                break;
            }
        }

        Console.WriteLine($"Finished. Total inserted: {totalInserted}");
    }

    static Stock MapToStock(ApiStock e)
    {
        if (!System.Enum.TryParse<FuelType>(e.Fuel, true, out var fuel))
        {
            Console.WriteLine($"Unknown fuel type '{e.Fuel}', defaulting to Petrol.");
            fuel = FuelType.Petrol;
        }

        return new Stock
        {
            MakeName = e.MakeName,
            ModelName = e.ModelName,
            MakeYear = e.MakeYear,
            Price = decimal.TryParse(e.PriceNumeric, out var price) ? price : 0,
            Kilometers = int.TryParse(e.KmNumeric, out var kms) ? kms : 0,
            FuelType = fuel,
            CityName = string.IsNullOrWhiteSpace(e.CityName) ? "Unknown" : e.CityName,
            ImageUrl = e.ImageUrl
        };
    }

    static async Task<int> SaveStockAsync(Stock stock)
    {
        using var connection = new MySqlConnection(ConnectionString);
        await connection.OpenAsync();

        var sql = @"
INSERT INTO Stocks (
    MakeName, ModelName, MakeYear, Price, DrivenKms, FuelType, CityName, image_url
)
VALUES (
    @MakeName, @ModelName, @MakeYear, @Price, @Kilometers, @FuelType, @CityName, @ImageUrl
);
SELECT LAST_INSERT_ID();";

        var parameters = new
        {
            stock.MakeName,
            stock.ModelName,
            stock.MakeYear,
            stock.Price,
            Kilometers = stock.Kilometers,
            FuelType = stock.FuelType.ToString(),
            stock.CityName,
            stock.ImageUrl
        };

        return await connection.ExecuteScalarAsync<int>(sql, parameters);
    }
}
