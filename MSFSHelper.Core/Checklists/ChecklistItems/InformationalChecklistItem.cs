namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    /// <summary>
    /// Non checkable.
    /// 
    /// Shows plain text of a non-actionable checklist item,
    /// i.e a subheader.
    /// </summary>
    public class InformationalChecklistItem : BaseChecklistItem
    {
        public InformationalChecklistItem(string name, string action) 
            : base(name, action)
        {
            State = ChecklistItemState.Uncheckable;
        }
    }
}
