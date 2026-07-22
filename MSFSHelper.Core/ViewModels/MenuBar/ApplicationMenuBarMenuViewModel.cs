using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSFSHelper.Core.Services;

namespace MSFSHelper.Core.ViewModels.MenuBar;

public partial class ApplicationMenuBarMenuViewModel : ObservableObject
{
    private LifetimeService lifetimeService;

    public ApplicationMenuBarMenuViewModel(LifetimeService lifetimeService)
    {
        this.lifetimeService = lifetimeService;
    }

    [RelayCommand]
    private async Task Quit()
    {
        await lifetimeService.Shutdown().ConfigureAwait(false);
    }
}