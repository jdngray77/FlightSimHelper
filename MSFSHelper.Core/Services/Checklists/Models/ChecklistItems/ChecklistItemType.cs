namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    public enum ChecklistItemType
    {
        // == Types that monitor sim data. ==

        // i.e turn it off and leave it off.
        //     If the condition is no-longer met, item unchecks.
        NonLatchingStateMonitor,

        // i.e press a momentary button
        //     Checks when condition is met, and stays checked.
        LatchingStateMonitor,


        // == Types that don't monitor sim data. ==

        // i.e Sub headers, or other non-actionable checklist items.
        //     Not checkable.
        InformationOnly, // implemented, not tested.

        // i.e Manual only items, like 'insert flight plan into MCDU'.
        //     Checked manually by user confirmation.
        Manual,

        // i.e Behaviourally similar to manual. Tasks that ideally should be Monitored
        //     but cannot be due to lack of data availability from the sim.
        LackDataManaual,

        // A group of items, not checkable.
        Aggregate,

        // A group of items that enables when a condition is met.
        ConditionalAggregate,

        // A group of items that is enabled manually, i.e when there is lack of API
        // required to check the condition automatically.
        ManualConditionalAggregate
    }

    public enum ChecklistItemState
    {
        Uncheckable,
        Skipped,
        Checked,
        Unchecked
    }

    public enum ChecklistDataType
    {
        None,
        LVar,
        Offset
    }
}
