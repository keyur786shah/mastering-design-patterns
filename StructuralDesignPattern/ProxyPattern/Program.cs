// Step 1: Interface
public interface IAccount
{
    void Withdraw(double amount);
}

// Step 2: Real Subject
public class Account : IAccount
{
    private double _balance = 1000;

    public void Withdraw(double amount)
    {
        if (amount <= _balance)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrawal successful! New Balance: {_balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }
}

// Step 3: Proxy
public class AccountProxy : IAccount
{
    private Account _realAccount = new Account();
    private bool _isAuthenticated;

    public AccountProxy(string pin)
    {
        // Simulate authentication
        _isAuthenticated = (pin == "1234");
    }

    public void Withdraw(double amount)
    {
        if (_isAuthenticated)
        {
            _realAccount.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Authentication failed. Access denied.");
        }
    }
}

// Step 4: Client
class Program
{
    static void Main()
    {
        IAccount myAccount = new AccountProxy("1234");
        myAccount.Withdraw(100);

        IAccount wrongAccount = new AccountProxy("0000");
        wrongAccount.Withdraw(100);
    }
}