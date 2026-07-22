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

        public ConsoloniaNavigationService(ViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public async Task GotoAsync(ERoutes route, Dictionary<string, object>? data = null)
        {
            Control view = null;
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                view = viewFactory.GetView(route);

                var lifetime = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime);
                var MainWindow = (lifetime.MainWindow as MainWindow);

                MainWindow.MainContentPanel.Child = view;
            });

            if (view is IPostNavigate && data != null)
            {
                await (view as IPostNavigate).AfterNavigatingTo(data).ConfigureAwait(false);
            }
        }
    }
}
