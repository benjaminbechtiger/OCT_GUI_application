namespace OCT_GUI_Application
{
    internal class OCTProgram
    {
        public string Name { get; set; }
        public double Axis0 { get; set; }
        public double Axis1 { get; set; }

        public OCTProgram(string name, int axis0, int axis1)
        {
            Name = name;
            Axis0 = axis0;
            Axis1 = axis1;
        }

        public override string ToString()
        {
            return $"{Name},{Axis0},{Axis1}";
        }
    }
}