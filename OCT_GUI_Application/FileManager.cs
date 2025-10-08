using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OCT_GUI_Application
{
    class FileManager
    {
        private string csvPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Positioniersystem\programs.csv";
        public string[] program_names = {"Lunker_Boden", "2000er_Impeller_innen", "2000er_Impeller_aussen", "600er_Pumpenkopf", "2000er_Pumpenkopf", "Wandstärke_4k_Impeller", "Wandstärke_4k_ZB", "LPI_30", "Varia_30_Bilder"};

        List<OCTProgram> programs = new List<OCTProgram>();
        OCTProgram program_settings = new OCTProgram("settings",0,0,0);
        
        private readonly Action<string, Color?> _logger;

        // Konstruktor
        public FileManager(Action<string, Color?> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Datenlogger
        private void Log(string message, Color? color = null)
        {
            Color c = color ?? Color.White;
            _logger?.Invoke(message, color);
        }

        // Programme aus .csv File laden
        public void LoadPrograms()
        {
            programs.Clear();

            if (!File.Exists(csvPath))
            {
                for (int i = 0; i < program_names.Length; i++)
                {
                    programs.Add(new OCTProgram(program_names[i], 0, 0, 0));
                }
                SavePrograms();
                Log("CSV file not found. Created with default values.");
                return;
            }

            var lines = File.ReadAllLines(csvPath).ToList();

            for (int i = 0; i < program_names.Length; i++)
            {
                OCTProgram prog;

                if (i < lines.Count)
                {
                    var parts = lines[i].Split(',');

                    double ax0 = 0, ax1 = 0;
                    int spdRt = 0;

                    bool validLine = parts.Length == program_settings.NR_PARAMETERS &&
                                     double.TryParse(parts[1], out ax0) &&
                                     double.TryParse(parts[2], out ax1) &&
                                     int.TryParse(parts[3], out spdRt);

                    if (!validLine || parts[0] != program_names[i])
                    {
                        prog = new OCTProgram(program_names[i], 0, 0, 0);
                        Log($"Program '{program_names[i]}' at index {i} corrected with default values.");
                    }
                    else
                    {
                        prog = new OCTProgram(parts[0], ax0, ax1, spdRt);
                    }
                }
                else
                {
                    prog = new OCTProgram(program_names[i], 0, 0, 0);
                    Log($"Program '{program_names[i]}' added with default values.");
                }

                programs.Add(prog);
            }

            // CSV aktualisieren (überschreibt falsche / fehlende Zeilen)
            SavePrograms();
            Log("Programs loaded successfully");
        }

        // Aktuelle Programmkonfiguration speichern
        public void SavePrograms()
        {
            File.WriteAllLines(csvPath, programs.Select(p => p.ToString()));
        }

        // Getter Funktionen

        public int GetNumPrograms()
        {
            return program_names.Length;
        }

        public string GetProgramName(int selectedProgram)
        {
            return program_names[selectedProgram];
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
