using DTO.StockRequestDTO;
using DTO.StockResponseDTO;
using Entities.Stock;

namespace BuisnessAccessLayer.IStockBAL
{
    public interface IStockBAL
    {
        Task<IEnumerable<StockResponseDTO>> FindStock(StockRequestDTO stockRequestDTO);
    }
}
