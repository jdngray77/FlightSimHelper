using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spectre.Console;

namespace MSFSHelper.Core.ViewModels.MenuBar;

public partial class DebugMenuBarMenuViewModel : ObservableObject
{

    [RelayCommand]
    private async Task WatchSimVariable()
    {
        // AnsiConsole.Clear();
        // string varName = AnsiConsole.Ask<string>("Provide variable Name");
        //
        // bool isOffset = AnsiConsole.Ask<bool>("Is offset? (has memory address)");
   
    }
}