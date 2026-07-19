using MSFSHelper.Core.Checklists.ChecklistItems;

namespace MSFSHelper.Core.ViewModels.Checklist;

public partial class InformationalChecklistItemViewModel : ChecklistEntryViewModel
{
    public override void Reset()
    {
        base.Reset();
        State = ChecklistItemState.Uncheckable;
    }

    public InformationalChecklistItemViewModel(InformationalChecklistItem item) : base(item)
    {
    }
}
