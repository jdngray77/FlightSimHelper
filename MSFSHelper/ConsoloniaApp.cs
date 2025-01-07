using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Consolonia;
using Consolonia.Themes;
using Microsoft.Extensions.DependencyInjection;
using MSFSHelper.Core.ViewModels;
using MSFSHelper.Views.Consolonia;

namespace MSFSHelper
{
    internal class ConsoloniaApp : ConsoloniaApplication<MainWindow>
    {
        public static ConsoloniaApp? Current { get => Application.Current as ConsoloniaApp; }

        public MainWindow? MainWindow = null;

        public ServiceProvider DI { get; private set; }

        public override void OnFrameworkInitializationCompleted()
        {
            DI = new DependencyInjection().ConfigureDI();

            // Super important. Consolonia is basically useless without this initial theme.
            Styles.Add(new TurboVisionBlackTheme());

            base.OnFrameworkInitializationCompleted();

            // DI the primary view model.
            // Avalonia's di support is a bit crap.
            this.MainWindow = ((base.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow as MainWindow);
            MainViewModel vm = DI.GetRequiredService<MainViewModel>();

            vm.SelectedMenuItem = new MarkupMenuItemViewModel("./Data/Markups/Welcome.xml", null, "Welcome");

            this.MainWindow.DataContext = vm;
        }
    }
}
