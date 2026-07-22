using CommunityToolkit.Mvvm.ComponentModel;

namespace MSFSHelper.Core.ViewModels.MenuBar;

public partial class MenuBarViewModel : ObservableObject
{
    public MenuBarViewModel(
        ApplicationMenuBarMenuViewModel applicationMenuBarMenuViewModel,
        SimBriefMenuBarMenuViewModel simBriefMenuBarMenuViewModel,
        DebugMenuBarMenuViewModel debugMenuBarMenuViewModel,
        AboutMenuBarMenuViewModel aboutMenuBarMenuViewModel)
    {
        this.applicationMenuBarMenuViewModel = applicationMenuBarMenuViewModel;
        this.simBriefMenuBarMenuViewModel = simBriefMenuBarMenuViewModel;
        this.debugMenuBarMenuViewModel = debugMenuBarMenuViewModel;
        this.aboutMenuBarMenuViewModel = aboutMenuBarMenuViewModel;
    }
    
    [ObservableProperty]
    private ApplicationMenuBarMenuViewModel applicationMenuBarMenuViewModel;
    
    [ObservableProperty]
    private SimBriefMenuBarMenuViewModel simBriefMenuBarMenuViewModel;
    
    [ObservableProperty]
    private DebugMenuBarMenuViewModel debugMenuBarMenuViewModel;
    
    [ObservableProperty]
    private AboutMenuBarMenuViewModel aboutMenuBarMenuViewModel;
}