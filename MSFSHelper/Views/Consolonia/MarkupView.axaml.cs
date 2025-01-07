using Avalonia.Controls;
using Avalonia.Interactivity;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.Services.ViewMarkup;
using MSFSHelper.Core.ViewModels;

namespace MSFSHelper.Views.Consolonia
{
    public partial class MarkupView : UserControl, IPostNavigate
    {
        MarkupViewViewModel vm;

        public MarkupView(MarkupViewViewModel vm)
        {
            DataContext = vm;
            this.vm = vm;
            InitializeComponent();
        }

        public async Task AfterNavigatingTo(Dictionary<string, object> navigationData)
        {
            var menuItemResponsible = (navigationData["viewmodel"] as MarkupMenuItemViewModel);

            if (menuItemResponsible == null)
            {
                await vm.Render("./Data/Markups/Welcome.xml", null);
                return;
            }

            await vm.Render(
                menuItemResponsible.MarkupViewPath, 
                menuItemResponsible.MarkupDataSource)
                .ConfigureAwait(false);
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