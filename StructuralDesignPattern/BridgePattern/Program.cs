
// Color Implementation
public interface IColor { string Fill(); }

public class Red : IColor { public string Fill() => "Red"; }
public class Blue : IColor { public string Fill() => "Blue"; }

// Shape Abstraction
public abstract class Shape
{
    protected IColor _color;
    protected Shape(IColor color) { _color = color; }
    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IColor color) : base(color) { }
    public override void Draw() => Console.WriteLine($"Drawing Circle in {_color.Fill()}");
}

public class Square : Shape
{
    public Square(IColor color) : base(color) { }
    public override void Draw() => Console.WriteLine($"Drawing Square in {_color.Fill()}");
}

// Client
class Program
{
    static void Main()
    {
        Shape redCircle = new Circle(new Red());
        Shape blueSquare = new Square(new Blue());

        redCircle.Draw();   // Drawing Circle in Red
        blueSquare.Draw();  // Drawing Square in Blue
    }
}


