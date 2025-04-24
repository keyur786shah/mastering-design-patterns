// Step 1: Subsystems
public class Kettle
{
    public void BoilWater() => Console.WriteLine("Boiling water...");
}

public class Cup
{
    public void AddTeaBag() => Console.WriteLine("Adding tea bag to the cup...");
    public void PourWater() => Console.WriteLine("Pouring water into the cup...");
    public void Stir() => Console.WriteLine("Stirring the tea...");
}

public class Sugar
{
    public void AddSugar() => Console.WriteLine("Adding sugar...");
}

// Step 2: Facade
public class TeaMaker
{
    private Kettle _kettle = new Kettle();
    private Cup _cup = new Cup();
    private Sugar _sugar = new Sugar();

    public void MakeTea()
    {
        _kettle.BoilWater();
        _cup.AddTeaBag();
        _cup.PourWater();
        _sugar.AddSugar();
        _cup.Stir();
        Console.WriteLine("Your tea is ready! ☕");
    }
}

// Step 3: Client
class Program
{
    static void Main()
    {
        TeaMaker teaMaker = new TeaMaker();
        teaMaker.MakeTea(); // Only ONE method call!
    }
}
