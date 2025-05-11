
// Step 1: Command Interface
public interface ICommand
{
    void Execute();
}

// Step 2: Receiver
public class TV
{
    public void TurnOn() => Console.WriteLine("TV is ON");
    public void TurnOff() => Console.WriteLine("TV is OFF");
}

// Step 3: Concrete Commands
public class TurnOnCommand : ICommand
{
    private TV _tv;
    public TurnOnCommand(TV tv) { _tv = tv; }
    public void Execute() => _tv.TurnOn();
}

public class TurnOffCommand : ICommand
{
    private TV _tv;
    public TurnOffCommand(TV tv) { _tv = tv; }
    public void Execute() => _tv.TurnOff();
}

// Step 4: Invoker
public class RemoteControl
{
    private ICommand _command;
    public void SetCommand(ICommand command) => _command = command;
    public void PressButton() => _command.Execute();
}

// Step 5: Client
class Program
{
    static void Main()
    {
        TV tv = new TV();
        ICommand onCommand = new TurnOnCommand(tv);
        ICommand offCommand = new TurnOffCommand(tv);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(onCommand);
        remote.PressButton(); // TV is ON

        remote.SetCommand(offCommand);
        remote.PressButton(); // TV is OFF

        Console.ReadLine();
    }
}