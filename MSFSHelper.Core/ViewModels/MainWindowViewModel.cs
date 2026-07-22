using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MSFSHelper.Core.Messages;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.Services.SimBrief;
using System.Collections.ObjectModel;
using System.Timers;
using MSFSHelper.Core.Services;
using MSFSHelper.Core.Services.Checklists;
using MSFSHelper.Core.ViewModels.MenuBar;

namespace MSFSHelper.Core.ViewModels
{
    [ObservableObject]
    public partial class MainWindowViewModel : IRecipient<AppStatusMessage>
    {
        private readonly INavigationServices navigation;
        private readonly SimBriefService simBrief;
        private readonly IMessenger messenger;
        private readonly FSUIPC.FSUIPC ipc;

        public ObservableCollection<MenuViewModel> Menus { get; }


        private System.Timers.Timer statusMessageClearTimer = new System.Timers.Timer()
        {
            Interval = 10000,
            AutoReset = false
        };

        public MainWindowViewModel(
            INavigationServices navigation, 
            SimBriefService simBrief, 
            IMessenger messenger,
            ChecklistLoadService checklistLoadService, 
            FSUIPC.FSUIPC ipc,
            IAlertService alertService, MenuBarViewModel menuBar)
        {
            this.navigation = navigation;
            this.simBrief = simBrief;
            this.messenger = messenger;
            this.ipc = ipc;
            this.menuBar = menuBar;

            messenger.Register<AppStatusMessage>(this);
            statusMessageClearTimer.Elapsed += Timer_Elapsed;

            Menus = new ObservableCollection<MenuViewModel>([
            new MenuViewModel(
                "Plan",
                new MarkupMenuItemViewModel(
                    "./Data/Markups/Plan/Overview.xml",
                    FlightPlanData,
                    "Overview"),
                
                new MenuItemViewModel("Origin", ERoutes.MarkupView),
                new MenuItemViewModel("Destination", ERoutes.MarkupView),
                new MenuItemViewModel("Navigation", ERoutes.MarkupView),
                new MenuItemViewModel("NOTAMs", ERoutes.MarkupView),
                new MarkupMenuItemViewModel(
                    "./Data/Markups/Plan/TOLR.xml",
                    FlightPlanData,
                    "Take-Off & Land Report"),
                new MenuItemViewModel("Radio", ERoutes.MarkupView),
                new MenuItemViewModel("Crew", ERoutes.MarkupView),
                new MenuItemViewModel("PAX, Cargo & Weight", ERoutes.MarkupView)
            ),

            // TODO this should be data driven.
            new MenuViewModel("Checklists",
                checklistLoadService.ChecklistGroups.SelectMany(
                group => group.Checklists.Select(
                    checklist => new ChecklistViewModel(
                        $"({group.Name}) - {checklist.Name}",
                        checklist,
                        ipc,
                        navigation,
                        alertService)
                    )
                ).ToArray<MenuItemViewModel>()
            ),

            new MenuViewModel("Settings",
                new MenuItemViewModel("General", ERoutes.SettingsGeneral),
                new MenuItemViewModel("FSUIPC", ERoutes.SettingsFsuipc),
                new MenuItemViewModel("SimBrief", ERoutes.SettingsSimbrief)
            )
        ]);
        }
        
        [ObservableProperty]
        private MenuBarViewModel menuBar;

        private Task<string> FlightPlanData()
        {
            return simBrief.GetFlightPlanXml("Shinkson47");
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            StatusMessage = null;
        }

        [ObservableProperty]
        private string statusMessage;

        partial void OnStatusMessageChanged(string? oldValue, string newValue)
        {
            if (newValue == null)
            {
                return;
            }

            lock (statusMessageClearTimer)
            {
                if (statusMessageClearTimer.Enabled)
                {
                    statusMessageClearTimer.Stop();
                }

                statusMessageClearTimer.Start();
            }
        }

        [ObservableProperty]
        private MenuItemViewModel selectedMenuItem;

        partial void OnSelectedMenuItemChanged(MenuItemViewModel? oldValue, MenuItemViewModel newValue)
        {
            Task.Run(async() =>
            {
                try
                {
                    await navigation.GotoAsync(newValue.Route,
                        new Dictionary<string, object>
                        {
                            { "viewmodel", newValue }
                        }).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    StatusMessage = e.Message;
                }
            });
        }


        [RelayCommand]
        private void ImportFlightPlan()
        {
            // TODO Loose coupled messages to update views when this gets updated.
            // TODO Can't do dialogs from here.
            // TODO Configuration

            StatusMessage = "Fetching Flight Plan";
            simBrief.GetFlightPlan("Shinkson47", true);
        }

        [RelayCommand]
        private void Quit()
        {
            Environment.Exit(0); 
        }

        void IRecipient<AppStatusMessage>.Receive(AppStatusMessage message)
        {
            StatusMessage = message.Value;
        }
    }
}
