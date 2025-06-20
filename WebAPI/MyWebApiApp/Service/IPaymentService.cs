namespace Service.IPaymentService;

public interface IPaymentService
{
    int ProcessPayment(decimal amount);
}