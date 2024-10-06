using System.Xml.Serialization;

namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    [Serializable]
    public abstract class BaseChecklistItem : ChecklistEntry, IDisposable
    {
        #region User representation

        [XmlAttribute]
        public override string Name { get; init; }

        [XmlAttribute]
        public override string Action { get; init; }

        #endregion User representation

        [XmlIgnore]
        public override ChecklistItemState State { get; protected set; } = ChecklistItemState.Unchecked;

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

        /// <summary>
        /// Not intended for code use; use full constructor.
        /// For serialization.
        /// </summary>
        [Obsolete]
        public BaseChecklistItem() { }

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
