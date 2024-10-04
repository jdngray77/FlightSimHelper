namespace MSFSHelper.Core.Services
{
    using FSUIPC;

    public class VariableService
    {
        private readonly FSUIPC ws;

        public VariableGroupManager VariableGroups { get; }

        public VariableService() : this(new FSUIPC())
        {
        }

        internal VariableService(FSUIPC ws)
        {
            this.ws = ws;
            this.VariableGroups = new VariableGroupManager(ws);
        }
    }
}
