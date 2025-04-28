
// Step 1: Strategy Interface
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

// Step 2: Concrete Strategies
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using Credit Card.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using PayPal.");
    }
}

public class UPIPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using UPI.");
    }
}

// Step 3: Context
public class ShoppingCart
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}

// Step 4: Client
class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();

        // Pay using Credit Card
        cart.SetPaymentStrategy(new CreditCardPayment());
        cart.Checkout(500);

        // Pay using PayPal
        cart.SetPaymentStrategy(new PayPalPayment());
        cart.Checkout(300);
    } 
}
