using FSUIPCWebSockets.JSONDataStructures;
using MSFSHelper.Core.Checklists;
using MSFSHelper.Core.Checklists.ChecklistItems;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Serialization;
using MSFSHelper.NewViews;
using Spectre.Console;

//Checklist afterStartChecklist = new Checklist(
//    "AFTER START",
//    new StateMonitorChecklistItem("ANTIICE", "AS RQRD", "A32NX_PARK_BRAKE_LEVER_POS", 1), // needs variable
//    new InformationalChecklistItem("ECAM STATUS", "CHECK"), // check if ok
//    new StateMonitorChecklistItem("PITCH TRIM", "AS RQRD", "A32NX_PARK_BRAKE_LEVER_POS", 1), // check if ok
//    new StateMonitorChecklistItem("RUDDER TRIM", "ZERO", "XMLVAR_RUDDERTRIM", 0) // 0?
//    );




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

foreach (var checklist in checklists.Checklists)
{
    VariableGroup lvarGroup = await groupManager.DeclareVariableGroup(checklist.Name + "_lvars", checklist.GetLVarNames()).ConfigureAwait(false);
    VariableGroup offsetGroup = await groupManager.DeclareOffsetGroup(checklist.Name + "_offsets", checklist.GetOffsets()).ConfigureAwait(false);

    checklist.Hook(lvarGroup);
    checklist.Hook(offsetGroup);
}


// ======================================================
// Define UI.
// ======================================================

ChecklistMenu menu = new ChecklistMenu(checklists.Checklists);
ConsoleScreen screen = new ConsoleScreen(menu);
screen.Render();

while (true)
{
    Thread.Sleep(10000);
}