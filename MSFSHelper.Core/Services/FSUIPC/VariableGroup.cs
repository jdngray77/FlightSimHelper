using FSUIPCWebSockets.JSONDataStructures;

namespace MSFSHelper.Core.FSUIPC
{
    public class VariableGroup
    {
        public bool IsOffset { get; private set; } = false;

        public bool IsAutoUpdating { get; internal set; } = false;

        public string GroupName { get; init; }

        private Dictionary<string, DoubleVar> Variables { get; }

        public event EventHandler Updated;
        
        internal VariableGroup(
            string groupName, 
            bool isOffset,
            params string[] variables) : this(groupName)
        {
            Variables = variables.Select(it => (it, new DoubleVar())).ToDictionary();
            IsOffset = isOffset;
        }

        internal VariableGroup(string groupName)
        {
            GroupName = groupName;
        }

        internal VariableGroup()
        {
        }

        public DoubleVar Get(string name)
        {
            return Variables[name];
        }

        public bool TryGet(string name, out DoubleVar lvar)
        {
            return Variables.TryGetValue(name, out lvar);
        }

        internal void Update(JSONOffsetsResponse response)
        {
            // TODO code dupe.
            if (response?.data == null)
            {
                return;
            }

            if (response.data.Keys.Any(it => !Variables.ContainsKey(it)))
            {
                throw new InvalidOperationException("Updating variable in group which does not contain said variable");
            }

            lock (Variables)
            {
                foreach (var item in response.data)
                {
                    Variables[item.Key].Value = (double)item.Value;// TODO super dodgy.
                }
            }

            Updated?.Invoke(this, null);
        }

        internal void Update(JSONVarsResponse response)
        {
            if (response?.data == null) 
            {
                return;
            }

            if (response.data.Keys.Any(it => !Variables.ContainsKey(it)))
            {
                throw new InvalidOperationException("Updating variable in group which does not contain said variable");   
            }

            lock(Variables)
            {
                foreach (var item in response.data)
                {
                    Variables[item.Key].Value = item.Value;
                }
            }

            Updated?.Invoke(this, null);
        }
    }
}
