using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Consolonia;
using Consolonia.Themes;
using Microsoft.Extensions.DependencyInjection;
using MSFSHelper.Core.Services;
using MSFSHelper.Core.ViewModels;
using MainWindow = MSFSHelper.Views.Pages.MainWindow;

namespace MSFSHelper
{
    internal class ConsoloniaApp : ConsoloniaApplication<MainWindow>
    {
        public static ConsoloniaApp? Current { get => Application.Current as ConsoloniaApp; }

        public MainWindow? MainWindow = null;

        public ServiceProvider DI { get; private set; }

        public override void RegisterServices()
        {
            base.RegisterServices();
            DI = new DependencyInjection().ConfigureDI();
        }
        
        public override void OnFrameworkInitializationCompleted()
        {
            // Super important. Consolonia is basically useless without this initial theme.
            Styles.Add(new TurboVisionBlackTheme());

            base.OnFrameworkInitializationCompleted();

            Task.Run(async () =>
            {
                LifetimeService lifetimeService = DI.GetRequiredService<LifetimeService>();
                lifetimeService.Startup().Wait();
            
                // DI the primary view model.
                // Avalonia's di support is a bit crap.
                this.MainWindow = ((base.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow as MainWindow);
                MainWindowViewModel vm = DI.GetRequiredService<MainWindowViewModel>();

                vm.SelectedMenuItem = new MarkupMenuItemViewModel("./Data/Markups/Welcome.xml", null, "Welcome");

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    this.MainWindow.DataContext = vm;
                });
            });

        }

    }
}
