using MSFSHelper.Core.Checklists.ChecklistItems;
using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Serialization;
using System.Xml.Serialization;

namespace MSFSHelper.Core.Checklists
{
    [Serializable]
    public class Checklist : IDisposable, IPostDeserialization, IUpdatable
    {
        public event EventHandler<ChecklistStateChangedEventArgs> Updated;

        [XmlAttribute]
        public string Name;

        [XmlArray]
        [XmlArrayItem("StateMonitorChecklistItem", typeof(StateMonitorChecklistItem))]
        [XmlArrayItem("InformationalChecklistItem", typeof(InformationalChecklistItem))]
        public List<ChecklistEntry> Items { get; [Obsolete] set; }

        [XmlIgnore]
        public bool IsComplete { get => Items.All(it => it.State == ChecklistItemState.Checked || it.State == ChecklistItemState.Uncheckable); }

        /// <summary>
        /// For serialization.
        /// 
        /// Not intended for code use.
        /// </summary>
        [Obsolete]
        public Checklist() { }

        public Checklist(string name, params ChecklistEntry[] items)
        {
            this.Name = name;
            this.Items = items.ToList();
            ForwardUpdates();
        }

        public ChecklistEntry? Next()
        {
            return Items.FirstOrDefault(it => it.State == ChecklistItemState.Unchecked);
        }

        public string[] GetLVarNames()
        {
            return Items
                .Where(it => it is StateMonitorChecklistItem smc && smc.DataType == ChecklistDataType.LVar)
                .Select(it => (it as StateMonitorChecklistItem)!.VariableName)
                .Distinct().ToArray();
        }

        public OffsetVar[] GetOffsets()
        {
            return Items
                .Where(it => it is StateMonitorChecklistItem smc && smc.DataType == ChecklistDataType.Offset)
                .Distinct()
                .Select(it => {
                    var item = (StateMonitorChecklistItem)it;

                    if (item!.DataOffset == null)
                    {
                        throw new Exception($"{item.Name} is declared as an offset variable but has no offset.");
                    }

                    return new OffsetVar(item.DataOffset.Value, item.VariableName);
                })
                .ToArray();
        }

        public void Hook(VariableGroupManager variableGroupManager)
        {
            foreach (StateMonitorChecklistItem item in Items.Where(it => it is StateMonitorChecklistItem))
            {
                if (variableGroupManager.TryFindSimVariable(item.VariableName, out DoubleVar simVar))
                {
                    item.AutoUpdate(simVar);
                } else
                {
                    Console.WriteLine($"No simvar found for Checklist Item {item.Name}");
                  /// <summary>
        /// Hooks the provided variable group to the state monitor checklist items and updates them accordingly.
        /// </summary>
        /// <param name="variableGroup">The variable group containing variables to be used for updating checklist items.</param>
      }
            }
        }

        public void Hook(VariableGroup variableGroup)
        {
            foreach (StateMonitorChecklistItem item in Items
                .Where(it => it is StateMonitorChecklistItem)
                .Where(it => ((it as StateMonitorChecklistItem).DataType == ChecklistDataType.Offset) == variableGroup.IsOffset))
            {
                if (variableGroup.TryGet(item.VariableName, out DoubleVar lvar))
                {
                    item.AutoUpdate(lvar);
                }
                else
                {
                    Console.WriteLine($"No LVar found for Checklist Item {item.Name}");
                  /// <summary>
        /// Releases all resources used by the current instance of the class.
        /// </summary>
      }
            }
        }

        public void Dispose() 
        {
            
        }

        public void PostDeserialize()
        {
            foreach (var item in Items)
            {
                (item as IPostDeserialization)?.PostDeserialize();
            }

            ForwardUpdates();
        }

        private void ForwardUpdates()
        {
            foreach (IUpdatable item in Items.Where(it => it is IUpdatable))
            {
                item.Updated += Item_Updated;
            }
        }

        private void Item_Updated(object? sender, ChecklistStateChangedEventArgs e)
        {
            if (!e.HasChanged)
            {
                return;   
            }

            Updated?.Invoke(sender, e);
        }
    }
}