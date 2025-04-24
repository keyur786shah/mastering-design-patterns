
using System;

// Step 1: Component Interface
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Step 2: Concrete Component
public class BasicCoffee : ICoffee
{
    public string GetDescription() => "Basic Coffee";
    public double GetCost() => 2.0;
}

// Step 3: Abstract Decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double GetCost() => _coffee.GetCost();
}

// Step 4: Concrete Decorators
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Milk";
    public override double GetCost() => _coffee.GetCost() + 0.5;
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Sugar";
    public override double GetCost() => _coffee.GetCost() + 0.25;
}

// Step 5: Client Code
class Program
{
    static void Main()
    {
        ICoffee myCoffee = new BasicCoffee();
        Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");

        myCoffee = new MilkDecorator(myCoffee);
        myCoffee = new SugarDecorator(myCoffee);

        Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");
    }
}
