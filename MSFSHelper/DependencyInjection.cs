using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.Services.SimBrief;
using MSFSHelper.Core.Services.ViewMarkup;
using MSFSHelper.Core.Services.ViewMarkup.Model;
using MSFSHelper.Core.ViewModels;
using MSFSHelper.Core.ViewModels.Plan;

namespace MSFSHelper
{
    public class DependencyInjection
    {
        ServiceCollection services = new ServiceCollection();
        ServiceProvider? di = null;
            
        public ServiceProvider ConfigureDI()
        {
            ConfigureViews();
            ConfigureViewModels();
            ConfigureServices();
            ConfigureFactories();

            di = services.BuildServiceProvider();
            return di;
        }

        private void ConfigureViews()
        {
            services.AddSingleton<Views.Consolonia.MarkupView>();
        }

        private void ConfigureViewModels()
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<OFPViewModel>();
            services.AddSingleton<MarkupViewViewModel>();
        }

        private void ConfigureServices()
        {
            services.AddSingleton<IMessenger, WeakReferenceMessenger>();
            services.AddSingleton<SimBriefService>();
            services.AddSingleton<INavigationServices, ConsoloniaNavigationService>();
            services.AddSingleton<MarkupRenderer>();

        }

        private void ConfigureFactories()
        {
            services.AddSingleton<ViewFactory>();
        }
    }
}
