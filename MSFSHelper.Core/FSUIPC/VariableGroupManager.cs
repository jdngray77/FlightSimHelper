using FSUIPCWebSockets.JSONDataStructures;

namespace MSFSHelper.Core.FSUIPC
{
    public class VariableGroupManager
    {
        public Dictionary<string, VariableGroup> VariableGroups = new Dictionary<string, VariableGroup>();

        private FSUIPC ws;

        public VariableGroupManager(FSUIPC ws) 
        {
            this.ws = ws;
        }

        public async Task<VariableGroup> DeclareVariableGroup(string name, params string[] variables)
        {
            await ws.DeclareVariableGroup(name, variables).ConfigureAwait(false);

            var x = new VariableGroup(name, false, variables);
            VariableGroups.Add(name, x);
            return x;
        }

        public async Task<VariableGroup> DeclareOffsetGroup(string name, params (int address, int size, string name, string type)[] variables)
        {
            await ws.DeclareOffsetGroup(name, variables).ConfigureAwait(false);

            var x = new VariableGroup(name, true, variables.Select(it => it.name).ToArray());
            VariableGroups.Add(name, x);
            return x;
        }

        public async Task<VariableGroup> UpdateVariableGroup(string name)
        {
            return await UpdateVariableGroup(GetGroup(name)).ConfigureAwait(false);
        }

        public async Task<VariableGroup> UpdateVariableGroup(VariableGroup group)
        {
            if (group.IsAutoUpdating)
            {
                Console.WriteLine("[WARN] manually updating an auto-updatning variable group.");
            }


            if (group.IsOffset)
            {
                JSONOffsetsResponse response = await ws.ReadOffsetGroup(group.GroupName).ConfigureAwait(false);
                group.Update(response);
            } 
            else
            {
                JSONVarsResponse response = await ws.ReadVariableGroup(group.GroupName).ConfigureAwait(false);
                group.Update(response);
            }
 
            return group;
        }

        public async Task AutoUpdateAllGroups()
        {
            foreach (var item in VariableGroups)
            {
                await AutoUpdateVariableGroup(item.Value).ConfigureAwait(false);
            }
        }


        public async Task<VariableGroup> AutoUpdateVariableGroup(string name, int intervalMillis)
        {
            return await AutoUpdateVariableGroup(GetGroup(name), intervalMillis).ConfigureAwait(false);
        }

        public async Task<VariableGroup> AutoUpdateVariableGroup(VariableGroup group, int intervalMillis = 100)
        {
            if (group.IsAutoUpdating)
            {
                Console.WriteLine("Already auto-updating!");
                return group;
            }
            
            group.IsAutoUpdating = true;

            if (group.IsOffset)
            {
                JSONOffsetsResponse vars = await ws.StartOffsetGroupPolling(
                    group.GroupName,
                    update =>
                    {
                        group.Update(((JSONOffsetsResponse)update));
                    },
                    intervalMillis).ConfigureAwait(false);

                group.Update(vars);
            }
            else
            {
                JSONVarsResponse vars = await ws.StartVariableGroupPolling(
                    group.GroupName,
                    intervalMillis,
                    update =>
                    {
                        group.Update(((JSONVarsResponse)update));
                    }).ConfigureAwait(false);

                group.Update(vars);
            }

            return group;
        }

        public async Task<VariableGroup> StopUpdatingVariableGroup(string name)
        {
            return await StopUpdatingVariableGroup(GetGroup(name)).ConfigureAwait(false);
        }

        public async Task<VariableGroup> StopUpdatingVariableGroup(VariableGroup group)
        {
            await ws.StopVariableGroupPolling(group.GroupName).ConfigureAwait(false);
            return group;
        }

        public bool TryFindSimVariable(string name, out DoubleVar lvar)
        {
            foreach (VariableGroup group in VariableGroups.Values)
            {
                if (group.TryGet(name, out DoubleVar var))
                {
                    lvar = var;
                    return true;
                }
            }

            lvar = null;
            return false;
        }

        private VariableGroup GetGroup(string name)
        {
            return VariableGroups[name];
        }
    }
}
