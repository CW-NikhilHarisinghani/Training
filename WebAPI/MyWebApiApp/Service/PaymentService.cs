using Service.IPaymentService;

namespace Service.PaymentService;

public class PaymentService : IPaymentService.IPaymentService
{
    public int ProcessPayment(decimal amount)
    {
        // Simulate payment processing logic
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        Console.WriteLine($"Processing payment of {amount:C}...");
        // Here you would integrate with a payment gateway or service
        return 0; // Assume payment is successful
    }
}