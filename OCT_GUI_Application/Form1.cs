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
using System.Runtime.InteropServices;

namespace OCT_GUI_Application
{
    public partial class OCT_Window : Form
    {
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

            this.Load += OCT_Window_Load;
            this.FormClosing += OCT_Window_FormClosing;

            this.KeyPreview = true;
            this.KeyDown += OCT_Window_KeyDown;
        }

        private void SendTMCLCommand(byte slave, byte command, byte type, byte axis, uint value)
        {
            byte[] frame = new byte[9];

            frame[0] = slave;     // Module address
            frame[1] = command;   // Command number
            frame[2] = type;      // Type number (usually 0)
            frame[3] = axis;      // Motor / Bank number
            frame[4] = (byte)((value >> 24) & 0xFF); // Value MSB
            frame[5] = (byte)((value >> 16) & 0xFF);
            frame[6] = (byte)((value >> 8) & 0xFF);
            frame[7] = (byte)(value & 0xFF);        // Value LSB

            // Checksum = simple 8-bit addition of bytes 0..7
            byte checksum = frame[0];
            for (int i = 1; i < 8; i++)
                checksum += frame[i];
            frame[8] = checksum;  // insert checksum as last byte

            spTMCM3110.Write(frame, 0, frame.Length);
        }

        private void OCT_Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Makro sendet Ctrl + E wenn beendet
            if (e.Control && e.KeyCode == Keys.E)
            {
                LogToConsole("Messung beendet, setze Anwendung zurück...");
                System.Threading.Thread.Sleep(3000);
                ResetMessung();
                LogToConsole("Bereit für die nächste Messung");
            }
        }
        private void LogToConsole(string text)
        {
            textBoxConsole.AppendText($"{DateTime.Now:HH:mm:ss}: {text}{Environment.NewLine}");
        }

        private void ResetMessung()
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

        private void OCT_Window_Load(object sender, EventArgs e)
        {
            // Timer initialisieren
            mainTimer = new Timer();
            mainTimer.Interval = 100; // 100 ms
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

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

            if (spTMCM3110.BytesToRead >= 9)
            {
                byte[] response = new byte[9];
                spTMCM3110.Read(response, 0, 9);
                Console.WriteLine("Received response from TMCM-3110!");

                // Print each byte in hex
                Console.WriteLine("Response bytes: " + BitConverter.ToString(response));
            }
            else
            {
                Console.WriteLine("No response from TMCM-3110!");
            }

            // Makro-Pfad auswählen
            string playerPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\00_MacroRecorder\MacroRecorder.exe";
            string macroFile = "";

            if (comboBoxMessobjekt.SelectedIndex == 0)
            {
                macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_Impeller_Turbo.mrf";
            }
            else if (comboBoxMessobjekt.SelectedIndex == 1)
            {
                if (comboBoxGroesse.SelectedIndex == 0)
                {
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_LPP_600_Turbo.mrf";
                }
                else if (comboBoxGroesse.SelectedIndex == 1)
                {
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_LPP_2000_Turbo.mrf";
                }
            }

            LogToConsole("Starte Makro: " + macroFile);

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
                pictureBoxDisplay.Image = Image.FromFile(@"C:\Users\benjamin.bechtiger\source\repos\OCT_GUI_Application\OCT_GUI_Application\Grafiken\impeller.png");
            }
            else if (comboBoxMessobjekt.SelectedIndex == 1)
            {
                pictureBoxDisplay.Image = Image.FromFile(@"C:\Users\benjamin.bechtiger\source\repos\OCT_GUI_Application\OCT_GUI_Application\Grafiken\pumphead.png");
            }
            else if (comboBoxMessobjekt.SelectedIndex == -1)
            {
                pictureBoxDisplay.Image = null;
            }
        }

        private void buttonTMCMsend_Click(object sender, EventArgs e)
        {
            byte TMCM_command = (byte)(comboBoxTMCMcmd.SelectedIndex + 1);

            // Parse the value as a 32-bit unsigned integer
            uint TMCM_value;
            if (!uint.TryParse(textBoxTMCMval.Text, out TMCM_value))
            {
                MessageBox.Show("Please enter a valid number!");
                return;
            }

            // Send the command
            SendTMCLCommand(2, TMCM_command, 0, 0, TMCM_value); // slave=2, type=0, axis=0
        }
    }
}
