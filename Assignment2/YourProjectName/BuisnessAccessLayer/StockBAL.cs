using AutoMapper;
using DTO.StockRequestDTO;
using Entities.StockRequest;

namespace BuisnessAccessLayer.StockBAL;

public class StockBAL
{
    private readonly IMapper mapper;
    public StockBAL(IMapper _mapper)
    {
        mapper = _mapper;
    }

    StockRequest MapDtoToEntity(StockRequestDTO dto)
    {
        return mapper.Map<StockRequest>(dto);
    }

    public void FindStock(StockRequestDTO stockRequestDTO)
    {
        StockRequest stockParams = MapDtoToEntity(stockRequestDTO);
    }
}