using CommunityToolkit.Mvvm.ComponentModel;
using MSFSHelper.Core.Services.Navigation;

namespace MSFSHelper.Core.ViewModels
{
    [ObservableObject]
    public partial class MenuItemViewModel
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ERoutes route;

        public MenuItemViewModel(string name, ERoutes route)
        {
            this.Name = name;
            this.Route = route;
        }
    }
}
