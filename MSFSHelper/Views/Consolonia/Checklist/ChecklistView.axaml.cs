using Avalonia.Controls;
using Avalonia.Threading;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.ViewModels;

namespace MSFSHelper.Views.Consolonia
{
    public partial class ChecklistView : UserControl, IPostNavigate
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
            
            await vm.StartUpdates();
        }
    }
}