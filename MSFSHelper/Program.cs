// See https://aka.ms/new-console-template for more information


using FSUIPCWebSockets.Client;
using FSUIPCWebSockets.JSONDataStructures;
using MSFSHelper;
using MSFSHelper.Core;
using MSFSHelper.Core.Checklists;
using MSFSHelper.Core.Checklists.ChecklistItems;
using MSFSHelper.Core.FSUIPC;
using System.Diagnostics;

FSUIPC ipc = new FSUIPC();
ipc.Initialize();

JSONAboutResponse s = await ipc.About().ConfigureAwait(false);
Console.WriteLine($"Flight Sim : {s.data.flightSim}");
Console.WriteLine($"Sim Version : {s.data.flightSimVersionText}");
Console.WriteLine($"Sim Version Code : {s.data.flightSimVersionCode}");
Console.WriteLine($"FSUIPC Server Version : {s.data.FSUIPCWebSocketServerVersion}");
Console.WriteLine($"Wide Client : {s.data.isConnectedToWideClient}");
Console.WriteLine($"Connection : {s.data.isConnectionOpen}");



// ======================================================

Checklist prelimChecklist = new Checklist(
    "PRELIMINARY COCKPIT PREP",
    //new ChecklistItem("ENG MASTER 1", "OFF", "FUELSYSTEM VALVE SWITCH:1", 0, true),
    //new ChecklistItem("ENG MASTER 2", "OFF", "FUELSYSTEM VALVE SWITCH:2", 0, true),
    //new ChecklistItem("ENG MODE SEL", "NORM", "TURB ENG IGNITION SWITCH EX1:1", 1, true),
    //new ChecklistItem("Weather Radar", "OFF", "XMLVAR_A320_WEATHERRADAR_SYS", null, false) { Check = true },
    //new ChecklistItem("L/G LVR", "DOWN", "GEAR HANDLE POSITION", 0, false),
    //new ChecklistItem("WIPERS L", "OFF", "CIRCUIT SWITCH ON:77", 0, true),
    //new ChecklistItem("WIPERS R", "OFF", "CIRCUIT SWITCH ON:80", 0, true),
    //new ChecklistItem("Battery 1", "SET AUTO", "A32NX_OVHD_ELEC_BAT_1_PB_IS_AUTO", 1, false),
    //new ChecklistItem("Battery 2", "SET AUTO", "A32NX_OVHD_ELEC_BAT_2_PB_IS_AUTO", 1, false),
    //
    //new ChecklistItem("IF EXT PWR AVAIL", string.Empty, string.Empty, 1, true) { Mandatory = false, Check = true },
    //new ChecklistItem("EXT PWR", "ON", string.Empty, 1, false) { Mandatory = false, Check = true },
    //
    ////new ChecklistItem("APU FIRE", "CHCK/TEST", "A32NX_FIRE_TEST_APU", 1, true), 
    //new ChecklistItem("APU", "ON", "A32NX_OVHD_APU_START_PB_IS_AVAILABLE", 1, true),
    //new ChecklistItem("PACK 1", "ON", "A32NX_OVHD_COND_PACK_1_PB_IS_ON", 1, true),
    //new ChecklistItem("PACK 2", "ON", "A32NX_OVHD_COND_PACK_2_PB_IS_ON", 1, true),
    //new ChecklistItem("INT LIGHTS", "AS RQRD", string.Empty, null, true) { Check = true },
    ////new ChecklistItem("ECAM RCL", "PRESS", "A32NX_BTN_RCL", 1, true),
    //new ChecklistItem("OIL QTY", "CHECK", string.Empty, null, true) { Check = true },
    //new ChecklistItem("FLAPS", "CHECK", "A32NX_FLAPS_HANDLE_INDEX", 0, true),
    //new ChecklistItem("SPD BRK", "CHECK RET", "A32NX_SPOILERS_HANDLE_POSITION", 0, true) { Check = true },
    //new ChecklistItem("PRK BRK", "ON", "A32NX_PARK_BRAKE_LEVER_POS", 1, true),
    //new ChecklistItem("ACCU BRK PRESSURE", "CHECK", string.Empty, null, true) { Check = true },
    //new ChecklistItem("ACCU BRK PRESSURE", "CHECK", string.Empty, null, true) { Check = true },
    //new ChecklistItem("RAIN REPEL L", "OFF", "A32NX_RAIN_REPELLENT_LEFT_ON", 0, true),
    //new ChecklistItem("RAIN REPEL R", "OFF", "A32NX_RAIN_REPELLENT_RIGHT_ON", 0, true)


    new StateMonitorChecklistItem("ENG MASTER 1", "OFF", "FUELSYSTEM VALVE SWITCH:1", 0x66CB, 0),
    new StateMonitorChecklistItem("ENG MASTER 2", "OFF", "FUELSYSTEM VALVE SWITCH:2", 0x66CC, 0),
    new StateMonitorChecklistItem("ENG MODE SEL", "NORM", "TURB ENG IGNITION SWITCH EX1:1", 0x66CA, 1),
    //new StateMonitorChecklistItem("Weather Radar", "OFF", "XMLVAR_A320_WEATHERRADAR_SYS", null),
    new StateMonitorChecklistItem("L/G LVR", "DOWN", "GEAR HANDLE POSITION", 0),
    new StateMonitorChecklistItem("WIPERS L", "OFF", "CIRCUIT SWITCH ON:77", 0x66D2, 0),
    new StateMonitorChecklistItem("WIPERS R", "OFF", "CIRCUIT SWITCH ON:80", 0x66D4, 0),
    new StateMonitorChecklistItem("Battery 1", "SET AUTO", "A32NX_OVHD_ELEC_BAT_1_PB_IS_AUTO", 1),
    new StateMonitorChecklistItem("Battery 2", "SET AUTO", "A32NX_OVHD_ELEC_BAT_2_PB_IS_AUTO", 1),

    //new StateMonitorChecklistItem("IF EXT PWR AVAIL", string.Empty, string.Empty, 1),
    //new StateMonitorChecklistItem("EXT PWR", "ON", string.Empty, 1),

    new StateMonitorChecklistItem("APU FIRE TEST", "PERFORM", "A32NX_FIRE_TEST_APU", 1) { Latching = true },
    new StateMonitorChecklistItem("APU", "START", "A32NX_OVHD_APU_START_PB_IS_AVAILABLE", 1),
    new StateMonitorChecklistItem("PACK 1", "ON", "A32NX_OVHD_COND_PACK_1_PB_IS_ON", 1),
    new StateMonitorChecklistItem("PACK 2", "ON", "A32NX_OVHD_COND_PACK_2_PB_IS_ON", 1),
    new InformationalChecklistItem("INT LIGHTS", "AS RQRD"),
    new StateMonitorChecklistItem("ECAM RCL", "PRESS", "A32NX_BTN_RCL", 1) { Latching = true },
    new InformationalChecklistItem("OIL QTY", "CHECK"), // Manual ACK
    new StateMonitorChecklistItem("FLAPS", "CHECK RET", "A32NX_FLAPS_HANDLE_INDEX", 0),
    new StateMonitorChecklistItem("SPD BRK", "CHECK RET", "A32NX_SPOILERS_HANDLE_POSITION", 0),
    new StateMonitorChecklistItem("PRK BRK", "ON", "A32NX_PARK_BRAKE_LEVER_POS", 1),
    new InformationalChecklistItem("ACCU BRK PRESSURE", "CHECK"), // Manual ACK
    new StateMonitorChecklistItem("RAIN REPEL L", "PRESS", "A32NX_RAIN_REPELLENT_LEFT_ON", 1) { Latching = true },
    new StateMonitorChecklistItem("RAIN REPEL R", "PRESS", "A32NX_RAIN_REPELLENT_RIGHT_ON", 1) { Latching = true }

    );

// ======================================================

// TODO only re-render if something in the checklist actually changed.

VariableGroupManager groupManager = new VariableGroupManager(ipc);

VariableGroup lvarGroup = await groupManager.DeclareVariableGroup(prelimChecklist.Name, prelimChecklist.GetLVarNames()).ConfigureAwait(false);

// TODO offset knowledge from file.
// TODO offset def from checklist.
VariableGroup offsetGroup = await groupManager.DeclareOffsetGroup(
    "offsets",
    (0x66CB, 1, "FUELSYSTEM VALVE SWITCH:1", "uint"),
    (0x66CC, 1, "FUELSYSTEM VALVE SWITCH:2", "uint"),
    (0x66D2, 1, "CIRCUIT SWITCH ON:77", "uint"),
    (0x66D4, 1, "CIRCUIT SWITCH ON:80", "uint"),
    (0x66CA, 1, "TURB ENG IGNITION SWITCH EX1:1", "uint")
    ).ConfigureAwait(false);

prelimChecklist.Hook(lvarGroup);
prelimChecklist.Hook(offsetGroup);
lvarGroup.Updated += Group_Updated;
offsetGroup.Updated += Group_Updated;

ChecklistView.RenderChecklist(prelimChecklist);

void Group_Updated(object? sender, EventArgs e)
{
    ChecklistView.RenderChecklist(prelimChecklist);
}

//await groupManager.AutoUpdateVariableGroup(lvarGroup, 1000).ConfigureAwait(false);
await groupManager.AutoUpdateAllGroups().ConfigureAwait(false);

while (true)
{
    Thread.Sleep(1000);
}

Console.WriteLine("Checklist complete!");

await groupManager.StopUpdatingVariableGroup(prelimChecklist.Name).ConfigureAwait(false);
