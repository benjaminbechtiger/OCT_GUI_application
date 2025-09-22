namespace OCT_GUI_Application
{
    internal class OCTProgram
    {
        // Programmstruktur des OCT Programms
        public int NR_PARAMETERS = 4;

        public string Name { get; set; }
        public double Axis0 { get; set; }
        public double Axis1 { get; set; }
        public int SpeedRot { get; set; }

        public OCTProgram(string name, double axis0, double axis1, int speedRot)
        {
            Name = name;
            Axis0 = axis0;
            Axis1 = axis1;
            SpeedRot = speedRot;
        }

        public override string ToString()
        {
            return $"{Name},{Axis0},{Axis1},{SpeedRot}";
        }
    }
}