using FSUIPCWebSockets.JSONDataStructures;
using MSFSHelper.Core.FSUIPC;


BEGINNING:
Console.WriteLine("Provide variable name:");
string? name = Console.ReadLine();

if (name == null)
{
    goto BEGINNING;
}

Console.WriteLine("Is offset? (y/N)");
bool isOffset = Console.ReadLine()?.ToLower() == "y";

string? offset = null;
if (isOffset)
{
    Console.WriteLine("Provide offset:");
    offset = Console.ReadLine();
}

if (offset == null)
{
    goto BEGINNING;
}


// ----------------------------

// Connect and list all variables

var ipc = new FSUIPC();
ipc.Initialize();

var vars = await ipc.SendAndAwait(new JSONRequest()
{
    command = "vars.list"
}).ConfigureAwait(false);

foreach (var dataLvar in (vars as JSONVarsListResponse).data.lvars)
{
    Console.WriteLine(dataLvar);
}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine("HVARS");
foreach (var dataLvar in (vars as JSONVarsListResponse).data.hvars)
{
    Console.WriteLine(dataLvar);
}


var about = await ipc.About();
Console.WriteLine(about.data.FSUIPCVersion);

// ----------------------------
// Declare variables we want to FSUIPC

var man = new VariableGroupManager(ipc);

Console.WriteLine("Declaring variable...");

const string groupname = "FSUIPC-POKE";

if (!isOffset)
{
    
    var LVars = await man.DeclareVariableGroup(
        groupname,
        name
    );
    
    SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    
    LVars.Updated += (sender, eventArgs) =>
    {
        Task.Run(() =>
        {
            semaphore.WaitAsync();
            Console.Clear();
            Console.WriteLine($"LVars updated: {LVars.GroupName} ({DateTime.Now})");
            foreach (var lVarsVariable in LVars.Variables)
            {
                Console.WriteLine($"{lVarsVariable.Key}: {lVarsVariable.Value.Value}");
            }

            semaphore.Release();
        });
    };
}
else
{
    var offsetGroup = await man.DeclareOffsetGroup("test",
        new OffsetVar(0x66CD, "CABIN SEATBELTS ALERT SWITCH")
    );
    
    SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
            
    offsetGroup.Updated += (sender, eventArgs) =>
    {
        Task.Run(() =>
        {
            semaphore.WaitAsync();
            Console.Clear();
            Console.WriteLine($"Offsets updated: {offsetGroup.GroupName} ({DateTime.Now})");
            foreach (var lVarsVariable in offsetGroup.Variables)
            {
                Console.WriteLine($"{lVarsVariable.Key}: {lVarsVariable.Value.Value}");
            }

            semaphore.Release();
        });
    };
}


// ----------------
// Read current state

Console.WriteLine("Retrieving initial values...");
var response = await ipc.ReadVariableGroup(groupname);

if (response == null)
{
    Console.WriteLine("Failed to get values!");
    return;
}

foreach (var keyValuePair in response.data)
{
        Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
}


Console.WriteLine("Registering auto-update..");
await man.AutoUpdateAllGroups();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Listening for updates...");
Console.WriteLine();
Console.WriteLine("No updates yet.");

while(true) 
    await Task.Delay(Int32.MaxValue);
