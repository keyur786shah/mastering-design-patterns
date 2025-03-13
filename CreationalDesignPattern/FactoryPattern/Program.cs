// Usage
Console.Write("Enter Payment Gateway (PayPal/Stripe): ");
string gatewayType = Console.ReadLine();

try
{
    IPaymentGateway paymentGateway = PaymentGatewayFactory.CreateGateway(type: gatewayType);
    paymentGateway.ProcessPayment();
   
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
Console.ReadLine();

public interface IPaymentGateway
{
    void ProcessPayment();
}

// Concrete Implementations
public class PayPalGateway : IPaymentGateway
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment through PayPal...");
    }
}

public class StripeGateway : IPaymentGateway
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment through Stripe...");
    }
}

// Factory Class
public class PaymentGatewayFactory
{
    public static IPaymentGateway CreateGateway(string type)
    {
        return type switch
        {
            "PayPal" => new PayPalGateway(),
            "Stripe" => new StripeGateway(),
            _ => throw new ArgumentException("Invalid payment gateway type")
        };
    }
}


