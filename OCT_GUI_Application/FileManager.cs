using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OCT_GUI_Application
{
    class FileManager
    {
        private string csvPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Positioniersystem\programs.csv";
        string[] program = { "Lunker_Boden", "2000er_Impeller_innen", "2000er_Impeller_aussen", "600er_Pumpenkopf", "2000er_Pumpenkopf", "Wandstärke_4k_Impeller", "Wandstärke_4k_ZB", ""};

        List<OCTProgram> programs = new List<OCTProgram>();
        OCTProgram program_settings = new OCTProgram("settings",0,0,0);
        
        private readonly Action<string> _logger;

        // Konstruktor
        public FileManager(Action<string> logger)
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
                programs = new List<OCTProgram>();

                for (int i = 0; i < GetNumPrograms(); i++)
                {
                    programs.Add(new OCTProgram(program[i], 0, 0, 0));
                }

                SavePrograms(); // create file with defaults
                Log("CSV file not found. Created with default values.");
            }
            else
            {
                programs.Clear();
                foreach (var line in File.ReadAllLines(csvPath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == program_settings.NR_PARAMETERS &&
                        double.TryParse(parts[1], out double ax0) &&
                        double.TryParse(parts[2], out double ax1) && 
                        int.TryParse(parts[3], out int spdRt))
                    {
                        programs.Add(new OCTProgram(parts[0], ax0, ax1, spdRt));
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

        public int GetNumPrograms()
        {
            return program.Length - 1;
        }

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

        public int GetSpeedRot(int selectedProgram)
        {
            return programs[selectedProgram].SpeedRot;
        }

        public OCTProgram GetProgram(int selectedProgram)
        {
            return programs[selectedProgram];
        }
    }
}
