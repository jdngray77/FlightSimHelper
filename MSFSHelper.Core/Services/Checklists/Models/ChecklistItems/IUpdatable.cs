namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    internal interface IUpdatable
    {
        event EventHandler<ChecklistStateChangedEventArgs> Updated;
    }
}
