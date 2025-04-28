using System;

// Step 1: Define the Product (Car)
public class Car
{
    public string Engine { get; set; }
    public int Seats { get; set; }
    public bool Sunroof { get; set; }
    public bool GPS { get; set; }

    public void ShowSpecifications()
    {
        Console.WriteLine($"Car Specifications: Engine={Engine}, Seats={Seats}, Sunroof={Sunroof}, GPS={GPS}");
    }
}

// Step 2: Define the Builder Interface
public interface ICarBuilder
{
    ICarBuilder SetEngine(string engine);
    ICarBuilder SetSeats(int seats);
    ICarBuilder AddSunroof(bool sunroof);
    ICarBuilder AddGPS(bool gps);
    Car Build();
}

// Step 3: Create a Concrete Builder
public class CarBuilder : ICarBuilder
{
    private Car _car = new Car(); 

    public ICarBuilder SetEngine(string engine)
    {
        _car.Engine = engine;
        return this;
    }

    public ICarBuilder SetSeats(int seats)
    {
        _car.Seats = seats;
        return this;
    }

    public ICarBuilder AddSunroof(bool sunroof)
    {
        _car.Sunroof = sunroof;
        return this;
    }

    public ICarBuilder AddGPS(bool gps)
    {
        _car.GPS = gps;
        return this;
    }

    public Car Build()
    {
        return _car;
    }
}

// Step 4: Director Class (Optional)
public class CarDirector
{
    public Car ConstructSportsCar(ICarBuilder builder)
    {
        return builder.SetEngine("V8")
                      .SetSeats(2)
                      .AddSunroof(true)
                      .AddGPS(true)
                      .Build();
    }
}

// Step 5: Usage
class Program
{
    static void Main()
    {
        ICarBuilder builder = new CarBuilder();
        CarDirector director = new CarDirector();

        // Building a sports car using the Director
        Car sportsCar = director.ConstructSportsCar(builder);
        sportsCar.ShowSpecifications();

        // Manually building a custom car
        Car customCar = builder.SetEngine("V6").SetSeats(4).AddSunroof(false).AddGPS(true).Build();
        customCar.ShowSpecifications();
    }
}