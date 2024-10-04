using MSFSHelper.Core.FSUIPC;

namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    public class StateMonitorChecklistItem : BaseChecklistItem
    {
        public DoubleVar? SimVariable { get; private set; }

        public Predicate<double> Condition { get; private init; }

        public string VariableName { get; private init; }

        public int? DataOffset { get; private init; }

        /// <summary>
        /// When true, When then State is set to checked,
        /// it cannot be unchecked.
        /// </summary>
        public bool Latching { get; init; } = false;


        public ChecklistDataType DataType { get; }

        /// <summary>
        /// LVar with expected value.
        /// </summary>
        public StateMonitorChecklistItem(
            string name, 
            string action,
            string variableName,
            double expectedValue) 
            : this(
                  name, 
                  action,
                  variableName,
                  d => d == expectedValue)
        {
        }

        /// <summary>
        /// LVar with custom conditon
        /// </summary>
        public StateMonitorChecklistItem(
            string name,
            string action,
            string variableName,
            Predicate<double> condition) 
            : base(name, action)
        {
            DataType = ChecklistDataType.LVar;
            Condition = condition;
            VariableName = variableName;
        }

        /// <summary>
        /// Offset with expected value.
        /// </summary>
        public StateMonitorChecklistItem(
            string name,
            string action,
            string variableName,
            int dataOffset,
            double expectedValue)
            : this(
                  name,
                  action,
                  variableName,
                  dataOffset,
                  d => d == expectedValue)
        {
        }

        /// <summary>
        /// Offset with custom conditon
        /// </summary>
        public StateMonitorChecklistItem(
            string name,
            string action,
            string variableName,
            int dataOffset,
            Predicate<double> condition)
            : base(name, action)
        {
            DataType = ChecklistDataType.Offset;
            Condition = condition;
            VariableName = variableName;
            DataOffset = dataOffset;
        }

        public void AutoUpdate(DoubleVar lvar)
        {
            if (SimVariable != null) 
            {
                StopAutoUpdate();
            }

            SimVariable = lvar;
            lvar.ValueChanged += Lvar_ValueChanged;
            Update();
        }

        public void StopAutoUpdate()
        {
            if (SimVariable == null)
            {
                return;
            }

            try
            {
                SimVariable.ValueChanged -= Lvar_ValueChanged;
            } catch { }

            SimVariable = null;
        }

        private void Lvar_ValueChanged(object? sender, double e)
        {
            Update();
        }

        private void Update()
        {
            if (SimVariable == null || (Latching && State == ChecklistItemState.Checked))
            {
                return;
            }

            TrySetState((Condition?.Invoke(SimVariable.Value) == true));

            if (Latching && State == ChecklistItemState.Checked)
            {
                StopAutoUpdate();
            }
        }
    }
}
