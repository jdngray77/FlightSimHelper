using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Consolonia;
using Consolonia.Themes;
using Microsoft.Extensions.DependencyInjection;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Services;
using MSFSHelper.Core.ViewModels;
using MSFSHelper.Views.Consolonia;

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
                StartupService startupService = DI.GetRequiredService<StartupService>();
                startupService.Startup().Wait();
            
                // DI the primary view model.
                // Avalonia's di support is a bit crap.
                this.MainWindow = ((base.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow as MainWindow);
                MainViewModel vm = DI.GetRequiredService<MainViewModel>();

                vm.SelectedMenuItem = new MarkupMenuItemViewModel("./Data/Markups/Welcome.xml", null, "Welcome");

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    this.MainWindow.DataContext = vm;
                });
            });

        }

    }
}
