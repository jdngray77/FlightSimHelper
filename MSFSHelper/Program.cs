using FSUIPCWebSockets.JSONDataStructures;
using MSFSHelper.Core.Checklists;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Serialization;
using MSFSHelper.NewViews;
using Spectre.Console;
using MSFSHelper;
using Avalonia;
using Consolonia;
using MSFSHelper.Core.Services.ViewMarkup;

//Checklist afterStartChecklist = new Checklist(
//    "AFTER START",
//    new StateMonitorChecklistItem("ANTIICE", "AS RQRD", "A32NX_PARK_BRAKE_LEVER_POS", 1), // needs variable
//    new InformationalChecklistItem("ECAM STATUS", "CHECK"), // check if ok
//    new StateMonitorChecklistItem("PITCH TRIM", "AS RQRD", "A32NX_PARK_BRAKE_LEVER_POS", 1), // check if ok
//    new StateMonitorChecklistItem("RUDDER TRIM", "ZERO", "XMLVAR_RUDDERTRIM", 0) // 0?
//    );

// ======================================================
// Configure View
// ======================================================

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

    public static async Task LegacyMain()
    {
        // ======================================================
        // Load checklists.
        // ======================================================

        ChecklistGroup checklists = Serialization.ChecklistsFromDataDir();
        Console.WriteLine($"Read {checklists.Checklists.Count} checklists from data directory.");

        // ======================================================
        // Connect to sim
        // ======================================================

        FSUIPC ipc = new FSUIPC();

        await AnsiConsole.Status()
            .Spinner(ConsoleScreen.GetSpinner())
            .StartAsync("Connecting to sim...", async ctx =>
            {
                ipc.Initialize();

                JSONAboutResponse s = await ipc.About().ConfigureAwait(false);
                if (s == null)
                {
                    AnsiConsole.Write("!! Failed to connect. Is FSUIPC Web Socket Server running? !!");
                    Environment.Exit(1);
                }

                Console.WriteLine($"Flight Sim : {s.data.flightSim}");
                Console.WriteLine($"Sim Version : {s.data.flightSimVersionText}");
                Console.WriteLine($"Sim Version Code : {s.data.flightSimVersionCode}");
                Console.WriteLine($"FSUIPC Server Version : {s.data.FSUIPCWebSocketServerVersion}");
                Console.WriteLine($"Wide Client : {s.data.isConnectedToWideClient}");
                Console.WriteLine($"Connection : {s.data.isConnectionOpen}");
            }).ConfigureAwait(false);


        // ======================================================
        // Define data.
        // ======================================================

        VariableGroupManager groupManager = new VariableGroupManager(ipc);

        // ======================================================
        // Define UI.
        // ======================================================

        ChecklistMenu menu = new ChecklistMenu(checklists.Checklists);
        ConsoleScreen screen = new ConsoleScreen(menu);
        await screen.Render();
    }
}
