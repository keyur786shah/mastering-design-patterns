using System;

public sealed class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    // Private constructor prevents instantiation from outside
    private Logger()
    {
        Console.WriteLine("Logger Instance Created");
    }

    // Public static method to get the single instance
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    // Logger method
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("This is the first log message.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("This is another log message.");

        // Checking if both instances are the same
        Console.WriteLine($"Are both instances same? {logger1 == logger2}");
    }
}
