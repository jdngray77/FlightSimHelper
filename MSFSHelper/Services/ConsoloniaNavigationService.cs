using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using MSFSHelper.Core.Services.Navigation;
using MainWindow = MSFSHelper.Views.Pages.MainWindow;

namespace MSFSHelper
{
    internal class ConsoloniaNavigationService : INavigationServices
    {
        private readonly ViewFactory viewFactory;
        private Control? currentView = null;
        
        
        public ConsoloniaNavigationService(ViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public async Task GotoAsync(ERoutes route, Dictionary<string, object>? data = null)
        {
            Control nextView = null;

            if (currentView != null && currentView is INavigateFrom from)
            {
                await from.NavigatedFrom().ConfigureAwait(false);
            }
            
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                nextView = viewFactory.GetView(route);

                var lifetime = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime);
                var MainWindow = (lifetime.MainWindow as MainWindow);

                MainWindow.MainContentPanel.Child = nextView;
            });

            if (nextView is INavigateTo && data != null)
            {
                await (nextView as INavigateTo).AfterNavigatingTo(data).ConfigureAwait(false);
            }
            
            currentView = nextView;
            
        }
    }
}
