using System.Xml.Serialization;

namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    /// <summary>
    /// Base for all items that may be in a checklist.
    /// Could be a single item or a collective.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(StateMonitorChecklistItem))]
    [XmlInclude(typeof(InformationalChecklistItem))]
    public abstract class ChecklistEntry
    {
        [XmlAttribute]
        public virtual string Name { get; init; }

        [XmlAttribute]
        public virtual string Action { get; init; }

        [XmlIgnore]
        public virtual ChecklistItemState State { get; protected set; }

    }
}
