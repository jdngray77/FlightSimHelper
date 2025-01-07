using Avalonia.Controls;
using Avalonia.Interactivity;
using MSFSHelper.Core.ViewModels;

namespace MSFSHelper.Views.Consolonia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   
            InitializeComponent();
        }

        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);
        }

        private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            // Ensure the sender is a ListBox
            if (sender is ListBox listBox && DataContext is MainViewModel viewModel)
            {
                // Get the selected item
                var selectedItem = listBox.SelectedItem as MenuItemViewModel;
                viewModel.SelectedMenuItem = selectedItem;
            }
        }
    }
}