using MSFSHelper.Core.FSUIPC;
using MSFSHelper.Core.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MSFSHelper.Core.Checklists.ChecklistItems
{
    [Serializable]
    public class StateMonitorChecklistItem : BaseChecklistItem, IPostDeserialization, IUpdatable
    {
        public event EventHandler<ChecklistStateChangedEventArgs> Updated;

        [XmlIgnore]
        public DoubleVar? SimVariable { get; private set; }

        [XmlIgnore]
        public Predicate<double> Condition { get; private set; }

        private double _requiredValue;

        [XmlAttribute]
        public double RequiredValue
        {
            get => _requiredValue;
            set
            {
                _requiredValue = value;
                Condition = x => x == _requiredValue;
                Update();
            }
        }

        [XmlAttribute]
        public string VariableName { get; [Obsolete] init; }

        [XmlIgnore]
        public ChecklistDataType DataType { get; private set; }

        [XmlIgnore]
        public int? DataOffset { get; [Obsolete] set; }

        // This property will be serialized as hexadecimal
        [XmlAttribute("DataOffset")]
        public string? DataOffsetHex
        {
            get => DataOffset.HasValue ? $"0x{DataOffset.Value:X}" : null;
            set
            {
#pragma warning disable CS0612 // Obsolete. Intended use; serialization.

                if (string.IsNullOrWhiteSpace(value))
                {
                    DataOffset = null;
                }
                else
                {
                    DataOffset = Convert.ToInt32(value, 16);
                }
#pragma warning restore CS0612
            }
        }

        /// <summary>
        /// When true, When then State is set to checked,
        /// it cannot be unchecked.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool Latching { get; init; } = false;

        /// <summary>
        /// Not intended for code use; use full constructor.
        /// For serialization.
        /// </summary>
        [Obsolete]
        public StateMonitorChecklistItem() { }


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

        public bool ShouldSerializeDataOffset()
        {
            return DataOffset != null;
        }

        private void Lvar_ValueChanged(object? sender, double e)
        {
            Update();
        }

        public void Update()
        {
            var oldState = State;
            
            if (SimVariable == null || (Latching && State == ChecklistItemState.Checked))
            {
                return;
            }

            TrySetState((Condition?.Invoke(SimVariable.Value) == true));

            if (Latching && State == ChecklistItemState.Checked)
            {
                StopAutoUpdate();
            }

            Updated?.Invoke(this, new ChecklistStateChangedEventArgs(oldState, State));
        }

        public void PostDeserialize()
        {
            if (!string.IsNullOrWhiteSpace(VariableName))
            {
                if (DataOffset != null)
                {
                    DataType = ChecklistDataType.Offset;
                } else
                {
                    DataType = ChecklistDataType.LVar;
                }
            }
        }
    }
}
