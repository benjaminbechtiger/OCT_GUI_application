namespace OCT_GUI_Application
{
    internal class OCTProgram
    {
        public string Name { get; set; }
        public int Axis1 { get; set; }
        public int Axis2 { get; set; }

        public OCTProgram(string name, int axis1, int axis2)
        {
            Name = name;
            Axis1 = axis1;
            Axis2 = axis2;
        }

        public override string ToString()
        {
            return $"{Name},{Axis1},{Axis2}";
        }
    }
}