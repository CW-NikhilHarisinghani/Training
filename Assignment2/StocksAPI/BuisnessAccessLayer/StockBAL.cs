namespace BuisnessAccessLayer.StockBAL;
using AutoMapper;
using DTO.StockRequestDTO;
using Entities.StockRequest;
using DataAccessLayer.IStockRepository;
using System.Threading.Tasks;
using BuisnessAccessLayer.IStockBAL;
using DTO.StockResponseDTO;

public class StockBAL:IStockBAL
{
    private readonly IMapper mapper;
    private readonly IStockRepository repository;
    public StockBAL(IMapper _mapper, IStockRepository _repository)
    {
        mapper = _mapper;
        repository = _repository;
    }

    StockRequest MapDtoToEntity(StockRequestDTO dto)
    {
        return mapper.Map<StockRequest>(dto);
    }

    public async Task<IEnumerable<StockResponseDTO>> FindStock(StockRequestDTO stockRequestDTO)
    {
        try
        {
            StockRequest stockParams = MapDtoToEntity(stockRequestDTO);
            var response = await repository.FetchStocks(stockParams); ;
            return mapper.Map<IEnumerable<StockResponseDTO>>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}