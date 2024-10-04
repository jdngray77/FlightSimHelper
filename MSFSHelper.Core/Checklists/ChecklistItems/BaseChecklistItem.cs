namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    public abstract class BaseChecklistItem : IChecklistItem, IDisposable
    {
        #region User representation
        public string Name { get; init; }

        public string Action { get; init; }

        #endregion User representation

        public ChecklistItemState State { get; protected set; } = ChecklistItemState.Unchecked;

        protected bool TrySetState(bool checkedState)
        {
            return TrySetState(checkedState ? ChecklistItemState.Checked : ChecklistItemState.Unchecked);
        }

        protected bool TrySetState(ChecklistItemState state)
        {
            if (State == ChecklistItemState.Uncheckable)
            {
                return false;
            }

            State = state;
            return true;
        }

        protected BaseChecklistItem(string name, string action)
        {
            Name = name;
            Action = action;
        }

        public virtual void Dispose()
        {

        }
    }
}
