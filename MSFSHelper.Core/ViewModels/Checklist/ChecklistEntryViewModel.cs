using CommunityToolkit.Mvvm.ComponentModel;
using MSFSHelper.Core.Checklists.ChecklistItems;

namespace MSFSHelper.Core.ViewModels.Checklist;

[ObservableObject]
public partial class ChecklistEntryViewModel
{
    private readonly ChecklistEntry _entry;

    [ObservableProperty]
    private ChecklistItemState state;

    [ObservableProperty] 
    private bool selected = false;

    public string Name => _entry.Name;
    public string Action => _entry.Action;
    public string? Notes => _entry.Notes;

    protected ChecklistEntryViewModel(ChecklistEntry entry)
    {
        _entry = entry;
        state = entry.State;
    }

    public virtual void Reset()
    {
        
    }

    /// <summary>
    /// Creates the appropriate view model subtype for the given checklist entry.
    /// </summary>
    public static ChecklistEntryViewModel Create(ChecklistEntry entry) => entry switch
    {
        StateMonitorChecklistItem smc => new StateMonitorChecklistItemViewModel(smc),
        InformationalChecklistItem info => new InformationalChecklistItemViewModel(info),
        _ => new ChecklistEntryViewModel(entry)
    };
}
