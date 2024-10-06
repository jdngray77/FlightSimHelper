using MSFSHelper.Core.Serialization;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MSFSHelper.Core.Checklists
{
    [Serializable]
    public class ChecklistGroup : IPostDeserialization
    {
        [XmlArray]
        public List<Checklist> Checklists { get; set; } = new List<Checklist>();

        public ChecklistGroup() { }

        public ChecklistGroup(params Checklist[] checklist)
        {
            Checklists = checklist.ToList();
        }

        public void PostDeserialize()
        {
            foreach (var item in Checklists)
            {
                item.PostDeserialize();
            }
        }
    }
}
