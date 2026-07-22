using Avalonia.Controls;
using Avalonia.Threading;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.ViewModels;

namespace MSFSHelper.Views.Controls.Checklist
{
    public partial class ChecklistView : UserControl, INavigateTo, INavigateFrom
    {
        private ChecklistViewModel? vm;

        public ChecklistView()
        {   
            InitializeComponent();
        }

        public async Task AfterNavigatingTo(Dictionary<string, object> data)
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                this.vm = data["viewmodel"] as ChecklistViewModel;
                this.DataContext = vm;
            });
            
            await vm!.StartUpdates();
        }

        public async Task NavigatedFrom()
        {
            await vm!.StopUpdates().ConfigureAwait(false);
        }
    }
}