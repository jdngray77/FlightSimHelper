using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using MSFSHelper.Core.ViewModels;
using MSFSHelper.Core.ViewModels.MenuBar;

namespace MSFSHelper.Views.Pages
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   
            // Main window cannot consume DI, vm is set via consoloniaapp.cs.
            InitializeComponent();
        }

        private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            // Ensure the sender is a ListBox
            if (sender is ListBox listBox && DataContext is MainWindowViewModel viewModel)
            {
                // Get the selected item
                var selectedItem = listBox.SelectedItem as MenuItemViewModel;
                viewModel.SelectedMenuItem = selectedItem;
            }
        }
    }
}