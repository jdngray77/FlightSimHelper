namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    public class ChecklistStateChangedEventArgs
    {
        public ChecklistItemState OldState { get; private init; }
        public ChecklistItemState NewState { get; private init; }
        public bool HasChanged { get => OldState != NewState; }

        public ChecklistStateChangedEventArgs(ChecklistItemState oldState, ChecklistItemState newState)
        {
            OldState = oldState;
            NewState = newState;
        }
    }
}
