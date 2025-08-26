using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;

namespace OCT_GUI_Application
{
    public partial class OCT_Window : Form
    {
        int pos_ax0;
        int pos_ax1;

        string playerPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\00_MacroRecorder\MacroRecorder.exe";
        string macroFile = "";
        string[] program = {"600er_Impeller", "2000er_Impeller", "600er_Pumpenkopf", "2000er_Pumpenkopf", ""};
        int selectedProgram;

        string csvPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Positioniersystem\programs.csv";
        List<OCTProgram> programs = new List<OCTProgram>();

        private Timer mainTimer;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        SerialPort spTMCM3110 = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);

        public OCT_Window()
        {
            InitializeComponent();

            try
            {      
                spTMCM3110.Open();
                if (spTMCM3110.IsOpen)
                {
                    Console.WriteLine("Serial port opened successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to open serial port: " + ex.Message);
            }

            LoadPrograms();
            groupBoxAchsensteuerung.Visible = false;
            groupBoxFile.Visible = false;
            buttonDevMode.Visible = false;

            this.Load += OCT_Window_Load;
            this.FormClosing += OCT_Window_FormClosing;

            this.KeyPreview = true;
            this.KeyDown += OCT_Window_KeyDown;
        }

        private void LoadPrograms()
        {
            if (!File.Exists(csvPath))
            {
                // Default values if file missing
                programs = new List<OCTProgram>()
                {
                    new OCTProgram(program[1], 0, 0),
                    new OCTProgram(program[2], 0, 0),
                    new OCTProgram(program[3], 0, 0),
                    new OCTProgram(program[4], 0, 0)
                };

                SavePrograms(); // create file with defaults
                LogToConsole("CSV file not found. Created with default values.");
            }
            else
            {
                programs.Clear();
                foreach (var line in File.ReadAllLines(csvPath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3 &&
                        int.TryParse(parts[1], out int ax1) &&
                        int.TryParse(parts[2], out int ax2))
                    {
                        programs.Add(new OCTProgram(parts[0], ax1, ax2));
                    }
                }
                LogToConsole("Programs loaded from CSV.");
            }
        }

        private void SavePrograms()
        {
            File.WriteAllLines(csvPath, programs.Select(p => p.ToString()));
        }


        /// <remarks>
        /// Builds and sends a TMCL (Trinamic Motion Control Language) command frame 
        /// to the TMCM-3110 controller via the serial port.
        /// 
        /// The TMCL frame has the following structure (9 bytes total):
        ///   [0] = Slave address (module address)
        ///   [1] = Command number
        ///   [2] = Type number (often 0)
        ///   [3] = Axis or bank number
        ///   [4..7] = 32-bit value (big-endian, MSB first)
        ///   [8] = Checksum (8-bit sum of bytes [0..7])
        ///
        /// This method calculates the checksum, assembles the frame, and transmits it.
        /// </remarks>
        /// <param name="slave">The module address (target TMCL device).</param>
        /// <param name="command">The TMCL command number to send.</param>
        /// <param name="type">The command type (typically 0 if unused).</param>
        /// <param name="axis">The target axis or motor number (0–2 for TMCM-3110).</param>
        /// <param name="value">A 32-bit parameter value associated with the command.</param>
        private bool SendTMCLCommand(byte slave, byte command, byte type, byte axis, uint value, out int replyValue, int timeoutMs = 50)
        {
            replyValue = 0;
            byte[] frame = new byte[9];

            frame[0] = slave;     // Module address
            frame[1] = command;   // Command number
            frame[2] = type;      // Type number (often 0)
            frame[3] = axis;      // Motor / Bank number
            frame[4] = (byte)((value >> 24) & 0xFF);
            frame[5] = (byte)((value >> 16) & 0xFF);
            frame[6] = (byte)((value >> 8) & 0xFF);
            frame[7] = (byte)(value & 0xFF);

            // Checksum = sum of bytes 0..7
            byte checksum = frame[0];
            for (int i = 1; i < 8; i++)
                checksum += frame[i];
            frame[8] = checksum;

            // Send the frame
            spTMCM3110.Write(frame, 0, frame.Length);
            spTMCM3110.BaseStream.Flush(); // ensure it's sent immediately

            // Wait for reply
            DateTime start = DateTime.Now;
            while (spTMCM3110.BytesToRead < 9)
            {
                if ((DateTime.Now - start).TotalMilliseconds > timeoutMs)
                {
                    return false; // timeout
                }
                System.Threading.Thread.Sleep(1);
            }

            // Read the 9-byte reply
            byte[] response = new byte[9];
            int read = spTMCM3110.Read(response, 0, 9);
            if (read < 9) return false;

            // Verify checksum
            byte sum = response[0];
            for (int i = 1; i < 8; i++)
                sum += response[i];
            if (sum != response[8]) return false;

            // Check TMCL status
            if (response[2] != 100) return false;

            // Extract signed 32-bit value from bytes [4..7]
            replyValue = (response[4] << 24) |
                         (response[5] << 16) |
                         (response[6] << 8) |
                          response[7];

            return true;
        }

        private bool TMCM_3110_write(byte command, byte type, byte axis, uint w_value)
        {
            bool TMCL_reply_status = SendTMCLCommand(2, command, type, axis, w_value, out int reply);
            return TMCL_reply_status;
        }

        private bool TMCM_3110_read(byte command, byte type, byte axis, out int r_value)
        {
            bool TMCL_reply_status = SendTMCLCommand(2, command, type, axis, 0, out r_value);
            return TMCL_reply_status;
        }

        // Event-Handler for key Pressed
        // -> for communication with autoclicker and commands
        private void OCT_Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Makro sendet Ctrl + E wenn beendet
            if (e.Control && e.KeyCode == Keys.E)
            {
                LogToConsole("Messung beendet, setze Anwendung zurück...");
                System.Threading.Thread.Sleep(3000);
                ResetMeasurement();
                LogToConsole("Bereit für die nächste Messung");
            }

            if (e.Control && e.KeyCode == Keys.D)
            {
                buttonDevMode.Visible = !buttonDevMode.Visible;

                if (!buttonDevMode.Visible)
                {
                    groupBoxAchsensteuerung.Visible = false;
                    groupBoxFile.Visible = false;
                    buttonDevMode.BackColor = SystemColors.ButtonFace;
                }
            }
        }

        // Log to console with Timestamp
        private void LogToConsole(string text)
        {
            textBoxConsole.AppendText($"{DateTime.Now:HH:mm:ss}: {text}{Environment.NewLine}");
        }

        // Reset GUI for next measurement
        private void ResetMeasurement()
        {
            pictureBoxDisplay.Visible = false;
            buttonMessStart.Enabled = true;
            buttonMessStart.BackColor = Color.GreenYellow;
            buttonMessStart.Text = "Messung Starten";
            comboBoxGroesse.Enabled = true;
            comboBoxGroesse.SelectedIndex = -1;
            comboBoxMessobjekt.Enabled = true;
            comboBoxMessobjekt.SelectedIndex = -1;
        }

        /// <summary>
        /// Action when Application is first started. Gets executed once
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OCT_Window_Load(object sender, EventArgs e)
        {
            // Timer initialisieren
            mainTimer = new Timer();
            mainTimer.Interval = 100; // 100 ms
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        /// <summary>
        /// Main Tick for continuous read/write actions and GUI update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (comboBoxGroesse.SelectedIndex >= 0 && comboBoxMessobjekt.SelectedIndex >= 0)
            {
                buttonMessStart.Visible = true;
            }
            else
            {
                buttonMessStart.Visible = false;
            }

            TMCM_3110_read(6, 1, 0, out pos_ax0);
            TMCM_3110_read(6, 1, 1, out pos_ax1);
            labelPosAx0.Text = pos_ax0.ToString();
            labelPosAx1.Text = pos_ax1.ToString();

            // Makro-Pfad auswählen
            if (comboBoxMessobjekt.SelectedIndex == 0)
            {
                macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_Impeller_Turbo.mrf";
                if (comboBoxGroesse.SelectedIndex == 0)
                {
                    selectedProgram = 0;
                }
                else if (comboBoxGroesse.SelectedIndex == 1)
                {
                    selectedProgram = 1;
                }
            }
            else if (comboBoxMessobjekt.SelectedIndex == 1)
            {
                if (comboBoxGroesse.SelectedIndex == 0)
                {
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_LPP_600_Turbo.mrf";
                    selectedProgram = 2;
                }
                else if (comboBoxGroesse.SelectedIndex == 1)
                {
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_LPP_2000_Turbo.mrf";
                    selectedProgram = 3;
                }
            }
            else
            {
                selectedProgram = 4;
            }
            labelSelProgDisp.Text = program[selectedProgram];
        }

        private void buttonMessStart_Click(object sender, EventArgs e)
        {
            // Button während Messung deaktivieren
            buttonMessStart.Enabled = false;
            buttonMessStart.BackColor = Color.Orange;
            buttonMessStart.Text = "Messung läuft…";
            comboBoxGroesse.Enabled = false;
            comboBoxMessobjekt.Enabled = false;
            this.Refresh();

            LogToConsole("Starte Makro: " + macroFile);

            TMCM_3110_write(4, 0, 0, unchecked((uint)programs[selectedProgram].Axis1));
            TMCM_3110_write(4, 0, 1, unchecked((uint)programs[selectedProgram].Axis2));

            // Makro Rekorder starten
            try
            {
                var process = System.Diagnostics.Process.Start(playerPath, "\"" + macroFile + "\"");
                process.WaitForInputIdle();

                IntPtr hWnd = IntPtr.Zero;
                int retries = 10;

                while (hWnd == IntPtr.Zero && retries-- > 0)
                {
                    System.Threading.Thread.Sleep(300); // kurz warten
                    process.Refresh();
                    hWnd = process.MainWindowHandle;
                }

                if (hWnd != IntPtr.Zero)
                {
                    SetForegroundWindow(hWnd);
                    SendKeys.SendWait("%{RIGHT}");
                }
                else
                {
                    LogToConsole("Fensterhandle nicht gefunden");
                }

            }
            catch (Exception ex)
            {
                LogToConsole("Fehler beim Starten oder Steuern:\n" + ex.Message);
            }
        }

        private void OCT_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            spTMCM3110.Close();
        }

        private void comboBoxMessobjekt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMessobjekt.SelectedIndex == 0)
            {
                pictureBoxDisplay.Image = Image.FromFile(@"C:\Users\benjamin.bechtiger\source\repos\OCT_GUI_Application\OCT_GUI_Application\Grafiken\impeller.gif");
            }
            else if (comboBoxMessobjekt.SelectedIndex == 1)
            {
                pictureBoxDisplay.Image = Image.FromFile(@"C:\Users\benjamin.bechtiger\source\repos\OCT_GUI_Application\OCT_GUI_Application\Grafiken\pumphead.gif");
            }
            else if (comboBoxMessobjekt.SelectedIndex == -1)
            {
                pictureBoxDisplay.Image = null;
            }
        }

        private void buttonTMCMsend_Click(object sender, EventArgs e)
        {
            byte TMCM_command = (byte)(comboBoxTMCMcmd.SelectedIndex + 1);
            byte TMCM_axis = (byte)(comboBoxTMCMaxs.SelectedIndex);

            // Parse the value as signed int
            if (!int.TryParse(textBoxTMCMval.Text, out int signedValue))
            {
                LogToConsole("Please enter a valid signed integer!");
                return;
            }

            // Convert signed int -> uint (bitwise cast)
            uint TMCM_value = unchecked((uint)signedValue);

            // Send the command
            TMCM_3110_write(TMCM_command, 0, TMCM_axis, TMCM_value);

            LogToConsole($"Sent Command={TMCM_command}, Axis={TMCM_axis}, Value={signedValue} (raw=0x{TMCM_value:X8})");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (selectedProgram < 4)
            {
                var selectedProg = programs[selectedProgram];

                // Overwrite axis values with the *current live values*
                selectedProg.Axis1 = pos_ax0;
                selectedProg.Axis2 = pos_ax1;

                // Save back to CSV
                SavePrograms();

                // UI feedback
                buttonSave.BackColor = Color.Gray;
                LogToConsole($"CSV gespeichert! {selectedProg.Name} -> Ax1={selectedProg.Axis1}, Ax2={selectedProg.Axis2}");
                buttonSave.BackColor = SystemColors.ButtonFace;
            }
        }

        private void buttonDevMode_Click(object sender, EventArgs e)
        {
            groupBoxAchsensteuerung.Visible = !groupBoxAchsensteuerung.Visible;
            groupBoxFile.Visible = !groupBoxFile.Visible;

            if (groupBoxFile.Visible)
            {
                buttonDevMode.BackColor = Color.Red;
            }
            else
            {
                buttonDevMode.BackColor = SystemColors.ButtonFace;
            }
        }
    }
}
