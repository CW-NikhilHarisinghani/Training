using Grpc.Core;
using SERVERGRPC.grpc;

public class ComputeValueForMoneyServiceImpl
    : ComputeValueForMoneyService.ComputeValueForMoneyServiceBase
{
    private readonly IValueForMoney _businessLayer;

    public ComputeValueForMoneyServiceImpl(IValueForMoney businessLayer)
    {
        _businessLayer = businessLayer;
    }

    public override async Task<ValueForMoneyResponse> compute(
        IdList request,
        ServerCallContext context
    )
    {
        List<bool> flags = await _businessLayer.compute(request.Id.ToList());
        var response = new ValueForMoneyResponse();
        response.ValueForMoney.AddRange(flags);

        return response;
    }
}
