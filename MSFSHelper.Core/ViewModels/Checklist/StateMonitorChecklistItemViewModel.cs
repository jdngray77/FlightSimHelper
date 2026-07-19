using MSFSHelper.Core.Checklists.ChecklistItems;

namespace MSFSHelper.Core.ViewModels.Checklist;

public partial class StateMonitorChecklistItemViewModel : ChecklistEntryViewModel
{
    private readonly StateMonitorChecklistItem _item;

    public string VariableName => _item.VariableName;
    public ChecklistDataType DataType => _item.DataType;
    public bool Latching => _item.Latching;

    public StateMonitorChecklistItemViewModel(StateMonitorChecklistItem item) : base(item)
    {
        _item = item;
        _item.Updated += OnUpdated;
    }

    private void OnUpdated(object? sender, ChecklistStateChangedEventArgs e)
    {
        if (e.HasChanged)
            State = e.NewState;
    }
}
