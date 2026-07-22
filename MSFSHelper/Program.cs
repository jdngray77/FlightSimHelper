using Avalonia;
using Consolonia;

// ======================================================
// Configure View
// ======================================================

namespace MSFSHelper;

public class Program : Application
{
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<ConsoloniaApp>()
            .UseConsolonia()
            .UseAutoDetectedConsole()
            .LogToException();
    }


    public static async Task Main(string[] args)
    {
        //var testView = File.ReadAllText("./TestView.xml");
        //var testData = File.ReadAllText("./data.xml");
        //var renderer = new MarkupRenderer();
        //var dataSource = new XmlDataSource(testData);
        //Console.WriteLine(renderer.Render(testView, dataSource));
        //return;

        ApplicationStartup.StartWithConsoleLifetime(BuildAvaloniaApp(), args);
    }
}