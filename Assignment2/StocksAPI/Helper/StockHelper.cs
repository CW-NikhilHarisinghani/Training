namespace Helper.StockHelper;

using System.Text.RegularExpressions;
using DTO.StockRequestDTO;

public class StockHelper
{
    public static bool IsValidBudget(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true;

        var pattern = @"^(\d+)-(\d+)$";
        var match = Regex.Match(input, pattern);

        if (!match.Success)
            return false;

        int left = int.Parse(match.Groups[1].Value);
        int right = int.Parse(match.Groups[2].Value);

        return left < right;
    }

    public static bool IsValidFuelType(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true;

        var pattern = @"^([0-5](\+[0-5])*)$";
        return Regex.IsMatch(input, pattern);
    }

    public static bool IsRequestValid(StockRequestDTO stockRequest)
    {
        return IsValidFuelType(stockRequest.FuelType) && IsValidBudget(stockRequest.Budget);
    }
}
