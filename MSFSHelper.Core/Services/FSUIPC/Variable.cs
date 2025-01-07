namespace MSFSHelper.Core.FSUIPC
{
    public class Variable<T>
    {
        private T _value;

        public string Name { get; set; }
        
        public T Value
        {
            get => _value;
            set
            {
                T old = _value;
                _value = value;

                if (!(value?.Equals(old) == true))
                {
                    ValueChanged?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<T> ValueChanged;
    }
}
