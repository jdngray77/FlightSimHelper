using Avalonia;
using Consolonia;

namespace MSFSHelper;

// ReSharper disable once ClassNeverInstantiated.Global ; it's main! of course it's not instantiated!
public class Program : Application
{
    public static void Main(string[] args)
    {
        BuildAvaloniaApp().StartWithConsoleLifetime(args);
    }
    
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<ConsoloniaApp>()
            .UseConsolonia()
            .UseAutoDetectedConsole()
            .LogToException();
    }
}