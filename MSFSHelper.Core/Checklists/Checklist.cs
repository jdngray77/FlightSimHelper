using MSFSHelper.Core.Checklists.ChecklistItems;
using MSFSHelper.Core.FSUIPC;

namespace MSFSHelper.Core.Checklists
{
    public class Checklist : IDisposable
    {
        public string Name;
        public List<IChecklistItem> Items;

        public bool IsComplete { get => Items.All(it => it.State == ChecklistItemState.Checked); }

        public Checklist(string name, params IChecklistItem[] items)
        {
            this.Name = name;
            this.Items = items.ToList();
        }

        public IChecklistItem? Next()
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

        public string[] GetOffsetNames()
        {
            return Items
                .Where(it => it is StateMonitorChecklistItem smc && smc.DataType == ChecklistDataType.Offset)
                .Select(it => (it as StateMonitorChecklistItem)!.VariableName)
                .Distinct().ToArray();
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
                }
            }
        }

        public void Hook(VariableGroup variableGroup)
        {
            foreach (StateMonitorChecklistItem item in Items.Where(it => it is StateMonitorChecklistItem))
            {
                if (variableGroup.TryGet(item.VariableName, out DoubleVar lvar))
                {
                    item.AutoUpdate(lvar);
                }
                else
                {
                    Console.WriteLine($"No LVar found for Checklist Item {item.Name}");
                }
            }
        }

        public void Dispose() 
        {
            
        }
    }
}
