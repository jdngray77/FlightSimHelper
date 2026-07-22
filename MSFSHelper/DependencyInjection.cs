using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Services;
using MSFSHelper.Core.Services.Checklists;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.Services.SimBrief;
using MSFSHelper.Core.Services.ViewMarkup;
using MSFSHelper.Core.Services.ViewMarkup.Model;
using MSFSHelper.Core.ViewModels;
using MSFSHelper.Core.ViewModels.Plan;
using MSFSHelper.Services;
using MSFSHelper.Views.Controls;
using MSFSHelper.Views.Controls.Checklist;

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
            services.AddSingleton<MSFSHMarkupControl>();
            services.AddTransient<ChecklistView>();
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
            services.AddSingleton<ChecklistLoadService>();
            services.AddSingleton<FSUIPC>();
            services.AddSingleton<StartupService>();
            services.AddSingleton<IAlertService, AlertService>();
        }

        private void ConfigureFactories()
        {
            services.AddSingleton<ViewFactory>();
        }
    }
}
