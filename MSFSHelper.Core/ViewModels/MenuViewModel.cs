using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MSFSHelper.Core.ViewModels
{
    [ObservableObject]
    public partial class MenuViewModel
    {
        [ObservableProperty]
        private string name;

        public MenuViewModel(string name, params MenuItemViewModel[] menuItems)
        {
            this.name = name;
            MenuItems = new ObservableCollection<MenuItemViewModel>(menuItems);
        }

        public ObservableCollection<MenuItemViewModel> MenuItems { get; }
    }
}
