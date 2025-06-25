namespace BuisnessAccessLayer.StockBAL;

using AutoMapper;
using DTO.StockRequestDTO;
using Entities.StockRequest;
using DataAccessLayer.IStockRepository;
using System.Threading.Tasks;
using BuisnessAccessLayer.IStockBAL;
using DTO.StockResponseDTO;
using SERVERGRPC.grpc;
using Grpc.Net.Client;
using Dapper;

public class StockBAL : IStockBAL
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

    async Task<List<bool>> fetchResponseFromServer(List<int> request)
    {
        var channel = GrpcChannel.ForAddress("http://localhost:5230");
        var client = new ComputeValueForMoneyService.ComputeValueForMoneyServiceClient(channel);
        var grpcRequest = new IdList
        {
            Id = { request } // Adds all ints from List<int> to the repeated field
        };

        var response = await client.computeAsync(grpcRequest);
        return response.ValueForMoney.ToList();
    }
    public bool IsValueForMoney(int DrivenKms, decimal price)
    {
        return DrivenKms < 10000 && price < 200000;
    }

    public async Task<IEnumerable<StockResponseDTO>> FindStock(StockRequestDTO stockRequestDTO)
    {
        try
        {
            StockRequest stockParams = MapDtoToEntity(stockRequestDTO);
            var response = await repository.FetchStocks(stockParams);
            List<int> request = new List<int>();
            foreach (var stock in response)
            {
                request.Add(stock.StockId);
            }
            var serverResponse = await fetchResponseFromServer(request);
            int currIdx = 0;
            foreach (var stock in response)
            {
                stock.IsValueForMoney = serverResponse[currIdx++];
            }
            return mapper.Map<IEnumerable<StockResponseDTO>>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}