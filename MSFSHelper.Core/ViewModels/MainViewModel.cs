using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MSFSHelper.Core.Messages;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.Services.SimBrief;
using System.Collections.ObjectModel;
using System.Timers;

namespace MSFSHelper.Core.ViewModels
{
    [ObservableObject]
    public partial class MainViewModel : IRecipient<AppStatusMessage>
    {
        private readonly INavigationServices navigation;
        private readonly SimBriefService simBrief;
        private readonly IMessenger messenger;

        public ObservableCollection<MenuViewModel> Menus { get; }


        private System.Timers.Timer statusMessageClearTimer = new System.Timers.Timer()
        {
            Interval = 10000,
            AutoReset = false
        };

        public MainViewModel(
            INavigationServices navigation, 
            SimBriefService simBrief, 
            IMessenger messenger)
        {
            this.navigation = navigation;
            this.simBrief = simBrief;
            this.messenger = messenger;

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
                new MenuItemViewModel("Pre-Start", ERoutes.Checklist),
                new MenuItemViewModel("Pushback", ERoutes.Checklist),
                new MenuItemViewModel("Start-up", ERoutes.Checklist),
                new MenuItemViewModel("Taxi", ERoutes.Checklist),
                new MenuItemViewModel("Before Take-Off", ERoutes.Checklist),
                new MenuItemViewModel("After Take-Off", ERoutes.Checklist),
                new MenuItemViewModel("Climb", ERoutes.Checklist),
                new MenuItemViewModel("Cruze", ERoutes.Checklist),
                new MenuItemViewModel("Descent", ERoutes.Checklist),
                new MenuItemViewModel("Approach", ERoutes.Checklist),
                new MenuItemViewModel("After Touch-Down", ERoutes.Checklist),
                new MenuItemViewModel("Shutdown", ERoutes.Checklist)
            ),

            new MenuViewModel("Settings",
                new MenuItemViewModel("General", ERoutes.SettingsGeneral),
                new MenuItemViewModel("FSUIPC", ERoutes.SettingsFsuipc),
                new MenuItemViewModel("SimBrief", ERoutes.SettingsSimbrief)
            )
        ]);
        }

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
