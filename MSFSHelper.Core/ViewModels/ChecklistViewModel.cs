using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MSFSHelper.Core.Checklists;
using MSFSHelper.Core.Checklists.ChecklistItems;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.ViewModels.Checklist;

namespace MSFSHelper.Core.ViewModels;

public partial class ChecklistViewModel : MenuItemViewModel
{
    private readonly global::MSFSHelper.Core.Checklists.Checklist _checklist;
    private readonly FSUIPC.FSUIPC _ipc;

    public ObservableCollection<ChecklistEntryViewModel> Items { get; }

    [ObservableProperty] 
    private ChecklistEntryViewModel? selectedItem = null;

    [ObservableProperty]
    private bool isComplete;

    public ChecklistViewModel(
        string name,
        global::MSFSHelper.Core.Checklists.Checklist checklist,
        FSUIPC.FSUIPC ipc)
        : base(name, ERoutes.Checklist)
    {
        _checklist = checklist;
        _ipc = ipc;
        Items = new ObservableCollection<ChecklistEntryViewModel>(
            checklist.Items.Select(ChecklistEntryViewModel.Create));
        isComplete = checklist.IsComplete;
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
    }

    private void OnChecklistUpdated(object? sender, ChecklistStateChangedEventArgs e)
    {
        if (e.HasChanged)
            IsComplete = _checklist.IsComplete;

        Task.Run(async () =>
        {
            await Task.Delay(100).ConfigureAwait(false);
            SelectedItem = Items.First(it => it.State == ChecklistItemState.Unchecked);
        });
    }
}