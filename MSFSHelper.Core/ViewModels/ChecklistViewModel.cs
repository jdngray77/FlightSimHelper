using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MSFSHelper.Core.Checklists;
using MSFSHelper.Core.Checklists.ChecklistItems;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Services;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.ViewModels.Checklist;

namespace MSFSHelper.Core.ViewModels;

public partial class ChecklistViewModel : MenuItemViewModel
{
    private readonly global::MSFSHelper.Core.Checklists.Checklist _checklist;
    private readonly FSUIPC.FSUIPC _ipc;
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
        _checklist = checklist;
        _ipc = ipc;
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
        var varman = VariableGroupManager.PrimaryManager ?? new VariableGroupManager(_ipc);

        var lvarGroup = await varman.DeclareVariableGroup(_checklist.Name + "_lvars", _checklist.GetLVarNames()).ConfigureAwait(false);
        var offsetGroup = await varman.DeclareOffsetGroup(_checklist.Name + "_offsets", _checklist.GetOffsets()).ConfigureAwait(false);

        _checklist.Hook(lvarGroup);
        _checklist.Hook(offsetGroup);

        await varman.AutoUpdateVariableGroup(lvarGroup).ConfigureAwait(false);
        await varman.AutoUpdateVariableGroup(offsetGroup).ConfigureAwait(false);

        _checklist.Updated += OnChecklistUpdated;
        HightlightNextItem();
    }

    private void OnChecklistUpdated(object? sender, ChecklistStateChangedEventArgs e)
    {
        if (e.HasChanged)
            IsComplete = _checklist.IsComplete;

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