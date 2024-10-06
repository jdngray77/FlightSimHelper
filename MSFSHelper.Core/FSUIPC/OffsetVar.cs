namespace MSFSHelper.Core.FSUIPC
{
    public class OffsetVar : DoubleVar
    {
        public int Address { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }

        public OffsetVar(int address, int size, string name, string type)
        {
            Address = address;
            Size = size;
            Name = name;
            Type = type;
        }

        public OffsetVar(int address, string name)
        {
            Address = address;
            Name = name;
            Size = 1;
            Type = "uint";
        }
    }
}
