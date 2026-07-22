using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSFSHelper.Core.Checklists.ChecklistItems;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Services;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.ViewModels.Checklist;

namespace MSFSHelper.Core.ViewModels;

public partial class ChecklistViewModel : MenuItemViewModel
{
    private VariableGroupManager varman;
    private VariableGroup lvarGroup;
    private VariableGroup offsetGroup;

    private readonly global::MSFSHelper.Core.Checklists.Checklist checklist;
    private readonly FSUIPC.FSUIPC ipc;
    private readonly INavigationServices navigationServices;
    private readonly IAlertService alertService;

    public ObservableCollection<ChecklistEntryViewModel> Items { get; }

    [ObservableProperty] 
    private ChecklistEntryViewModel? selectedItem = null;
    
    [ObservableProperty]
    private int selectedIndex = 0;

    [ObservableProperty]
    private bool isComplete;

    public ChecklistViewModel(
        string name,
        global::MSFSHelper.Core.Checklists.Checklist checklist,
        FSUIPC.FSUIPC ipc, INavigationServices navigationServices, IAlertService alertService)
        : base(name, ERoutes.Checklist)
    {
        this.checklist = checklist;
        this.ipc = ipc;
        varman = VariableGroupManager.PrimaryManager ?? new VariableGroupManager(this.ipc);
        
        this.navigationServices = navigationServices;
        this.alertService = alertService;
        Items = new ObservableCollection<ChecklistEntryViewModel>(
            checklist.Items.Select(ChecklistEntryViewModel.Create));
        Items.Add(new InformationalChecklistItemViewModel(new InformationalChecklistItem("---- CHECKLIST COMPLETE ----", "---- CHECKLIST COMPLETE ----")));
        isComplete = checklist.IsComplete;

    }

    [RelayCommand]
    private async Task ManualMarkCurrentComplete()
    {
        if (SelectedItem is StateMonitorChecklistItemViewModel item)
        {
            var confirm = await alertService.ShowAlertAsync(
                "The sim data seems to suggest that the current item is not done!",
                "ARE YOU SURE?",
                "I'M SURE",
                "NO").ConfigureAwait(false);

            if (!confirm)
            {
                return;
            }
        }
        
        SelectedItem.State = ChecklistItemState.Checked;
        HightlightNextItem();
    }
    
    [RelayCommand]
    private async Task ResetChecklist()
    {
        // From the top!
        foreach (var item in Items)
        {
            item.Reset();
        }

        HightlightNextItem();
    }

    public async Task StartUpdates()
    {
        lvarGroup   = await varman.DeclareVariableGroup(checklist.Name + "_lvars", checklist.GetLVarNames()).ConfigureAwait(false);
        offsetGroup = await varman.DeclareOffsetGroup(checklist.Name + "_offsets", checklist.GetOffsets()).ConfigureAwait(false);

        checklist.Hook(lvarGroup);
        checklist.Hook(offsetGroup);

        await varman.AutoUpdateVariableGroup(lvarGroup).ConfigureAwait(false);
        await varman.AutoUpdateVariableGroup(offsetGroup).ConfigureAwait(false);

        checklist.Updated += OnChecklistUpdated;
        HightlightNextItem();
    }

    public async Task StopUpdates()
    {
        checklist.Updated -= OnChecklistUpdated;
        checklist.UnhookAll();
        
        await varman.DeleteVariableGroup(lvarGroup).ConfigureAwait(false);
        await varman.DeleteVariableGroup(offsetGroup).ConfigureAwait(false);
    }

    private void OnChecklistUpdated(object? sender, ChecklistStateChangedEventArgs e)
    {
        if (e.HasChanged)
            IsComplete = checklist.IsComplete;

        Task.Run(async () =>
        {
            await Task.Delay(100).ConfigureAwait(false);
            HightlightNextItem();
        });
    }

    private void HightlightNextItem()
    {
        if (selectedIndex == Items.Count - 1)
        {
            navigationServices.GotoAsync(ERoutes.MarkupView);
        }
        
        SelectedItem = Items.FirstOrDefault(it => it.State == ChecklistItemState.Unchecked || it.State == ChecklistItemState.Uncheckable,
                                            Items.Last(it => it.State == ChecklistItemState.Checked));
        
        
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedIndex))
        {
            for (int i = 0; i < SelectedIndex; i++)
            {
                if (Items[i].State != ChecklistItemState.Checked)
                {
                    SelectedIndex = i;
                    return;
                }
            }
            return;
        }

        if (e.PropertyName == nameof(SelectedItem))
        {
            SelectedItem?.Selected = true;
        }
    }

    protected override void OnPropertyChanging(PropertyChangingEventArgs e)
    {
        base.OnPropertyChanging(e);
        if (e.PropertyName == nameof(SelectedItem))
        {
            SelectedItem?.Selected = false;
        }
    }
}