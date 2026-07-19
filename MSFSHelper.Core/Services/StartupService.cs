using FSUIPCWebSockets.JSONDataStructures;
using MSFSHelper.Core.Services.Checklists;
using Spectre.Console;

namespace MSFSHelper.Core.Services;

public class StartupService
{
    private readonly ChecklistLoadService checklistLoadService;
    private readonly FSUIPC.FSUIPC ipc;

    public StartupService(FSUIPC.FSUIPC ipc, ChecklistLoadService checklistLoadService)
    {
        this.ipc = ipc;
        this.checklistLoadService = checklistLoadService;
    }

    public async Task Startup()
    {
        await AnsiConsole.Status()
            .Spinner(Spinner.Known.Flip)
            .StartAsync("Loading checklists", async ctx =>
            {
                checklistLoadService.LoadChecklists();
            }).ConfigureAwait(false);
        
        await AnsiConsole.Status()
            .Spinner(Spinner.Known.Flip)
            .StartAsync("Connecting to MSFS via FSUIPC7...", async ctx =>
            {
                ipc.Initialize();

                JSONAboutResponse s = await ipc.About().ConfigureAwait(false);
                if (s == null)
                {
                    AnsiConsole.Write("!! Failed to connect. Is FSUIPC Web Socket Server running? !!");
                    AnsiConsole.Write("Press any key to continue without a MSFS connection...");
                    Console.ReadLine();
                }

                Console.WriteLine($"Flight Sim : {s.data.flightSim}");
                Console.WriteLine($"Sim Version : {s.data.flightSimVersionText}");
                Console.WriteLine($"Sim Version Code : {s.data.flightSimVersionCode}");
                Console.WriteLine($"FSUIPC Server Version : {s.data.FSUIPCWebSocketServerVersion}");
                Console.WriteLine($"Wide Client : {s.data.isConnectedToWideClient}");
                Console.WriteLine($"Connection : {s.data.isConnectionOpen}");
            }).ConfigureAwait(false);
        


        
    }
}