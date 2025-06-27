using AutoMapper;
using DTO.StockRequestDTO;
using DTO.StockResponseDTO;
using Entities.Stock;
using Entities.StockRequest;
using Enum.FuelTypesEnum;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<StockRequestDTO, StockRequest>()
            .ForMember(dest => dest.minBudget,
            opt => opt.MapFrom(src => GetMin(src.Budget)))

            .ForMember(dest => dest.maxBudget,
            opt => opt.MapFrom(src => GetMax(src.Budget)))

            .ForMember(dest => dest.fuels,
            opt => opt.MapFrom(src => CombineFuel(src.FuelTypes)));


        CreateMap<Stock, StockResponseDTO>()

            .ForMember(dest => dest.FormattedPrice,
            opt => opt.MapFrom(src => FormatPrice(src.Price)))

            .ForMember(dest => dest.CarName,
            opt => opt.MapFrom(src => FormatName(src.MakeName, src.ModelName, src.MakeYear)))

            .ForMember(dest => dest.imageUrl,
            opt =>opt.MapFrom(src => src.image_url));
    }

    public static int? GetMin(string budget)
    {
        if (string.IsNullOrEmpty(budget))
        { return null; }
        var budgetParts = budget.Split('-');
        
        return Convert.ToInt32(budgetParts[0]);
    }

    public static int? GetMax(string budget)
    {
        if (string.IsNullOrEmpty(budget))
        { return null; }
        var budgetParts = budget.Split('-');
        return Convert.ToInt32(budgetParts[1]);
    }

    public static List<FuelTypesEnum> CombineFuel(string fuel)
    {
        if (string.IsNullOrEmpty(fuel))
            return null;

        var fuels = new List<FuelTypesEnum>();
        var selectedFuels = fuel.Split('+');

        foreach (var en in selectedFuels)
        {
            if (int.TryParse(en, out int val) && System.Enum.IsDefined(typeof(FuelTypesEnum), val))
            {
                fuels.Add((FuelTypesEnum)val);
            }
        }

        return fuels;
    }

    public static string FormatPrice(decimal price)
    {
        if (price >= 10000000)
        {
            return (price / 10000000).ToString("0.0") + " Cr";
        }
        else if (price >= 100000)
        {
            return (price / 100000).ToString("0.0") + " Lakh";
        }
        else
        {
            return price.ToString("#,##0");
        }
    }

    public static string FormatName(string MakeName, string ModelName, int year)
    {
        return $"{year} {MakeName} {ModelName}";
    }
}
