
// Observer Interface
public interface IInvestor
{
    void Update(string stockName, decimal price);
}

// Concrete Observer
public class Investor : IInvestor
{
    private string _name;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(string stockName, decimal price)
    {
        Console.WriteLine($"{_name} notified: {stockName} is now {price:C}");
    }
}

// Subject Interface
public interface IStock
{
    void Attach(IInvestor investor);
    void Detach(IInvestor investor);
    void Notify();
}

// Concrete Subject
public class Stock : IStock
{
    private List<IInvestor> _investors = new List<IInvestor>();
    private decimal _price;
    private string _name;

    public Stock(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public void Attach(IInvestor investor) => _investors.Add(investor);

    public void Detach(IInvestor investor) => _investors.Remove(investor);

    public void Notify()
    {
        foreach (var investor in _investors)
        {
            investor.Update(_name, _price);
        }
    }

    public void SetPrice(decimal price)
    {
        _price = price;
        Notify();
    }
}

// Client
class Program
{
    static void Main()
    {
        Stock google = new Stock("GOOG", 1200);

        Investor alice = new Investor("Alice");
        Investor bob = new Investor("Bob");

        google.Attach(alice);
        google.Attach(bob);

        google.SetPrice(1250);
        google.SetPrice(1300);
    }
}
