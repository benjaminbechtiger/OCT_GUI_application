using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace OCT_GUI_Application
{
    public partial class OCT_Window : Form
    {
        // Interne Variabeln
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        SerialPort spTMCM3110 = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);

        double pos_ax0;
        double pos_ax1;
        int selectedProgram;

        string macroRecorderPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\00_MacroRecorder\MacroRecorder.exe";
        string macroFile = "";

        private Timer mainTimer;
        private TMCM3110Controller tmcm3110Controller;
        private FileManager programFileManager;

        // Konstruktor
        public OCT_Window()
        {
            InitializeComponent();

            tmcm3110Controller = new TMCM3110Controller(spTMCM3110, LogToConsole);
            programFileManager = new FileManager(LogToConsole);

            try
            {      
                spTMCM3110.Open();
            }
            catch (Exception ex)
            {
                LogToConsole("Failed to open serial port: " + ex.Message);
            }

            programFileManager.LoadPrograms();
            groupBoxAchsensteuerung.Visible = false;
            groupBoxFile.Visible = false;
            buttonDevMode.Visible = false;

            this.Load += OCT_Window_Load;
            this.FormClosing += OCT_Window_FormClosing;

            this.KeyPreview = true;
            this.KeyDown += OCT_Window_KeyDown;
        }

        // Action when Application is first started. Gets executed once
        private void OCT_Window_Load(object sender, EventArgs e)
        {
            // Timer initialisieren
            mainTimer = new Timer();
            mainTimer.Interval = 100; // 100 ms
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();

            // Sicherstellen dass alle Achsen gestoppt sind
            SafetyStop();
        }

        private void OCT_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            SafetyStop();
            spTMCM3110.Close();
        }

        private void SafetyStop()
        {
            tmcm3110Controller.MotorStop(0);
            tmcm3110Controller.MotorStop(1);
            tmcm3110Controller.MotorStop(2);
        }

        // Event-Handler for key Pressed
        // -> for communication with autoclicker and commands
        private void OCT_Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + E zum Zurücksetzen des Messprogramms
            if (e.Control && e.KeyCode == Keys.E)
            {
                tmcm3110Controller.MotorStop(2);
                LogToConsole("Messung beendet, setze Anwendung zurück...");
                System.Threading.Thread.Sleep(3000);
                ResetMeasurement();
                LogToConsole("Bereit für die nächste Messung");
            }

            // Ctrl + D für den Wechsel in den Entwicklermodus
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
        public void LogToConsole(string text)
        {
            if (textBoxConsole.InvokeRequired)
            {
                textBoxConsole.Invoke(new Action(() =>
                    textBoxConsole.AppendText($"{DateTime.Now:HH:mm:ss}: {text}{Environment.NewLine}")));
            }
            else
            {
                textBoxConsole.AppendText($"{DateTime.Now:HH:mm:ss}: {text}{Environment.NewLine}");
            }
        }

        // Reset GUI for next measurement
        private void ResetMeasurement()
        {
            pictureBoxDisplay.Image = null;
            buttonMessStart.Enabled = true;
            buttonMessStart.BackColor = Color.GreenYellow;
            buttonMessStart.Text = "Messung Starten";
            comboBoxMessobjekt.Enabled = true;
            comboBoxMessobjekt.SelectedIndex = -1;
        }

        // Main Tick for continuous read/write actions and GUI update
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            buttonMessStart.Visible = comboBoxMessobjekt.SelectedIndex >= 0;

            tmcm3110Controller.GetActualPosition_mm(0, out pos_ax0);
            tmcm3110Controller.GetActualPosition_mm(1, out pos_ax1);
            labelPosAx0.Text = pos_ax0.ToString();
            labelPosAx1.Text = pos_ax1.ToString();
        }

        // Aktion wenn Messung gestartet wird
        private void buttonMessStart_Click(object sender, EventArgs e)
        {
            // Button während Messung deaktivieren
            buttonMessStart.Enabled = false;
            buttonMessStart.BackColor = Color.Orange;
            buttonMessStart.Text = "Messung läuft…";
            comboBoxMessobjekt.Enabled = false;
            this.Refresh();

            LogToConsole("Starte Makro: " + macroFile);

            tmcm3110Controller.MovePositionAbs(0, programFileManager.GetAxis0_Value(selectedProgram));
            tmcm3110Controller.MovePositionAbs(1, programFileManager.GetAxis1_Value(selectedProgram));
            tmcm3110Controller.RotateRight(2, 5);

            // Makro Rekorder starten
            try
            {
                var process = System.Diagnostics.Process.Start(macroRecorderPath, "\"" + macroFile + "\"");
                process.WaitForInputIdle();

                IntPtr hWnd = IntPtr.Zero;
                int retries = 10;

                while (hWnd == IntPtr.Zero && retries-- > 0)
                {
                    System.Threading.Thread.Sleep(300);
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

        // Updaten der Vorschau und des aktuell ausgewählten Programms
        private void comboBoxMessobjekt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vorschaubild auswählen
            if (comboBoxMessobjekt.SelectedIndex == 0 || comboBoxMessobjekt.SelectedIndex == 1)
            {
                pictureBoxDisplay.Image = Image.FromFile(@"C:\Users\benjamin.bechtiger\source\repos\OCT_GUI_Application\OCT_GUI_Application\Grafiken\impeller.gif");
            }
            else if (comboBoxMessobjekt.SelectedIndex == 2 || comboBoxMessobjekt.SelectedIndex == 3)
            {
                pictureBoxDisplay.Image = Image.FromFile(@"C:\Users\benjamin.bechtiger\source\repos\OCT_GUI_Application\OCT_GUI_Application\Grafiken\pumphead.gif");
            }
            else if (comboBoxMessobjekt.SelectedIndex == -1)
            {
                pictureBoxDisplay.Image = null;
            }

            // Makro-Pfad auswählen
            switch (comboBoxMessobjekt.SelectedIndex)
            {
                case 0:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_Impeller_Turbo.mrf";
                    selectedProgram = 0;
                    break;
                case 1:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_Impeller_Turbo.mrf";
                    selectedProgram = 1;
                    break;
                case 2:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_LPP_600_Turbo.mrf";
                    selectedProgram = 2;
                    break;
                case 3:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_LPP_2000_Turbo.mrf";
                    selectedProgram = 3;
                    break;
                default:
                    selectedProgram = 4;
                    break;
            }
            labelSelProgDisp.Text = programFileManager.GetProgramName(selectedProgram);
        }

        // Manuelle Achsensteuerung im Entwicklermodus
        private void buttonTMCMsend_Click(object sender, EventArgs e)
        {
            byte TMCM_command = (byte)(comboBoxTMCMcmd.SelectedIndex);
            byte TMCM_axis = (byte)(comboBoxTMCMaxis.SelectedIndex);

            // Parse the value as signed int
            if (!double.TryParse(textBoxTMCMval.Text, out double TMCM_value))
            {
                LogToConsole("Please enter a valid signed double!");
                return;
            }

            switch (TMCM_command)
            {
                case 0:
                    tmcm3110Controller.RotateRight(TMCM_axis, (int)TMCM_value);
                    break;
                case 1:
                    tmcm3110Controller.RotateLeft(TMCM_axis, (int)TMCM_value);
                    break;
                case 2:
                    tmcm3110Controller.MotorStop(TMCM_axis);
                    break;
                case 3:
                    tmcm3110Controller.MovePositionAbs(TMCM_axis, TMCM_value);
                    break;
                case 4:
                    tmcm3110Controller.StartReferenceSearch(TMCM_axis);
                    break;
                default:
                    break;
            }

            LogToConsole($"Sent Command={TMCM_command}, Axis={TMCM_axis}, Value={(int)TMCM_value} (raw=0x{(int)TMCM_value:X8})");
        }

        // Aktuelles Programm speichern
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (selectedProgram < 4)
            {
                var selectedProg = programFileManager.GetProgram(selectedProgram);

                // Overwrite axis values with the *current live values*
                selectedProg.Axis0 = pos_ax0;
                selectedProg.Axis1 = pos_ax1;

                // Save back to CSV
                programFileManager.SavePrograms();

                // UI feedback
                buttonSave.BackColor = Color.Gray;
                LogToConsole($"CSV gespeichert! {selectedProg.Name} -> Ax0={selectedProg.Axis0}, Ax1={selectedProg.Axis1}");
                buttonSave.BackColor = SystemColors.ButtonFace;
            }
        }

        // Entwicklermodus freischalten
        private void buttonDevMode_Click(object sender, EventArgs e)
        {
            groupBoxAchsensteuerung.Visible = !groupBoxAchsensteuerung.Visible;
            groupBoxFile.Visible = !groupBoxFile.Visible;

            if (groupBoxFile.Visible)
            {
                buttonDevMode.BackColor = Color.Red;
                comboBoxTMCMaxis.SelectedIndex = 0;
                comboBoxTMCMcmd.SelectedIndex = 2;
            }
            else
            {
                buttonDevMode.BackColor = SystemColors.ButtonFace;
                SafetyStop();
            }
        }
    }
}
