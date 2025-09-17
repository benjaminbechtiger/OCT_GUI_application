using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OCT_GUI_Application
{
    class FileManager
    {
        private string csvPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Positioniersystem\programs.csv";
        string[] program = { "600er_Impeller", "2000er_Impeller", "600er_Pumpenkopf", "2000er_Pumpenkopf", "" };

        List<OCTProgram> programs = new List<OCTProgram>();
        
        private readonly Action<string> _logger;

        // Konstruktor
        public FileManager(Action<string> logger = null)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Datenlogger
        private void Log(string message)
        {
            _logger?.Invoke(message);
        }

        // Programme aus .csv File laden
        public void LoadPrograms()
        {          
            if (!File.Exists(csvPath))
            {
                // Default values if file missing
                programs = new List<OCTProgram>()
                {
                    new OCTProgram(program[0], 0, 0),
                    new OCTProgram(program[1], 0, 0),
                    new OCTProgram(program[2], 0, 0),
                    new OCTProgram(program[3], 0, 0)
                };

                SavePrograms(); // create file with defaults
                Log("CSV file not found. Created with default values.");
            }
            else
            {
                programs.Clear();
                foreach (var line in File.ReadAllLines(csvPath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3 &&
                        double.TryParse(parts[1], out double ax0) &&
                        double.TryParse(parts[2], out double ax1))
                    {
                        programs.Add(new OCTProgram(parts[0], ax0, ax1));
                    }
                }
                Log("Programs loaded from CSV.");
            }
        }

        // Aktuelle Programmkonfiguration speichern
        public void SavePrograms()
        {
            File.WriteAllLines(csvPath, programs.Select(p => p.ToString()));
        }

        // Getter Funktionen
        public string GetProgramName(int selectedProgram)
        {
            return program[selectedProgram];
        }

        public double GetAxis0_Value(int selectedProgram)
        {
            return programs[selectedProgram].Axis0;
        }

        public double GetAxis1_Value(int selectedProgram)
        {
            return programs[selectedProgram].Axis1;
        }

        public OCTProgram GetProgram(int selectedProgram)
        {
            return programs[selectedProgram];
        }
    }
}
