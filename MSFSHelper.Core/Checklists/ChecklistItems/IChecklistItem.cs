namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    public interface IChecklistItem
    {
        public string Name { get; }

        public string Action { get; }

        public ChecklistItemState State { get; }

    }
}
