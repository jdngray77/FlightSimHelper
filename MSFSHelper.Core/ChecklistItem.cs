using MSFSHelper.Core.FSUIPC;

namespace MSFSHelper.Core
{
    public class ChecklistItem
    {
        private DoubleVar _lvar = null;

        public bool Check { get; set; } = false;

        public string name { get; init; }

        public string action { get; init; }

        public bool IsOffset { get; init; }

        public bool NoAutoUpdate { get => Condition == null || _lvar == null; }

        public string LVarName { get; init; }

        private bool mandatory = true;
        public bool Mandatory
        {
            get => !NoAutoUpdate && mandatory;
            init => mandatory = value;
        }

        public Predicate<double>? Condition { get; init; }

        public bool? ConditionMet { get; private set; } = null;

        public ChecklistItem(
            string name,
            string action,
            string lVarName,
            double condition,
            bool offset)
            : this(name, action, lVarName, it => it == condition, offset)
        {
        }

        public ChecklistItem(
            string name,
            string action,
            string lVarName,
            Predicate<double> condition,
            bool offset)
        {
            this.name = name;
            this.action = action;
            LVarName = lVarName;
            Condition = condition;
        }

        internal void Hook(DoubleVar lvar)
        {
            _lvar = lvar;
            lvar.ValueChanged += Lvar_ValueChanged;
            ConditionMet = Condition?.Invoke(lvar.Value);
        }

        internal void UnHook()
        {
            _lvar.ValueChanged -= Lvar_ValueChanged;
            _lvar = null;
        }

        private void Lvar_ValueChanged(object? sender, double e)
        {
            ConditionMet = Condition?.Invoke(e);
            Console.WriteLine($"{name} met : {ConditionMet}");
        }
    }
}
