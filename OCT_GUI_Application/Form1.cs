using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace OCT_GUI_Application
{
    public partial class OCT_Window : Form
    {
        // Interne Variabeln
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private Process macroProcess;
        private static int MAX_POS_TIME = 20000;    //Maximale Zeit zum Erreichen der Position
        private static double POS_TOL  = 0.1;       //Toleranz für die Positionierung in mm

        private double pos_ax0;
        private double pos_ax1;
        private int speed_rot;
        private int selectedProgram;
        private double targetPos0;
        private double targetPos1;

        string macroRecorderPath = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\00_MacroRecorder\MacroRecorder.exe";
        string macroFile = "";

        private Timer mainTimer;
        private TMCM3110Controller tmcm3110Controller;
        private FileManager programFileManager;
        private ImageManager imageManager;

        public OCT_Window()
        {
            InitializeComponent();

            tmcm3110Controller = new TMCM3110Controller(LogToConsole);
            programFileManager = new FileManager(LogToConsole);
            imageManager = new ImageManager(LogToConsole);


            programFileManager.LoadPrograms();

            InitGUI();

            Load += OCT_Window_Load;
            FormClosing += OCT_Window_FormClosing;

            KeyPreview = true;
            KeyDown += OCT_Window_KeyDown;
        }

        // Main Tick for continuous read/write actions and GUI update
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            buttonMessStart.Visible = comboBoxProgramme.SelectedIndex >= 0;
            buttonPositioning.Visible = buttonMessStart.Visible;

            bool success = tmcm3110Controller.GetActualPosition_mm(0, out pos_ax0);

            if (!success)
            {
                // iterate over the COM ports from ComboBox
                foreach (var item in comboBoxCOMPort.Items)
                {
                    comboBoxCOMPort.SelectedItem = item;
                    if (tmcm3110Controller.GetActualPosition_mm(0, out pos_ax0))
                    {
                        success = true;
                        break;
                    }
                }
            }

            if (success)
            {
                tmcm3110Controller.GetActualPosition_mm(1, out pos_ax1);
                labelPosAx0.Text = pos_ax0.ToString();
                labelPosAx1.Text = pos_ax1.ToString();
            }
            else
            {
                labelPosAx0.Text = "N/A";
                labelPosAx1.Text = "N/A";
            }
        }

        // Event-Handler for key Pressed
        // -> for communication with autoclicker and commands
        private void OCT_Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + E zum Zurücksetzen des Messprogramms
            if (e.Control && e.KeyCode == Keys.E)
            {
                tmcm3110Controller.MotorStop(2);
                StopMacroProcess();
                LogToConsole("Messung beendet, exportiere Bilder...");
                imageManager.ProcessImages();
                LogToConsole("Messung" + programFileManager.GetProgramName(selectedProgram) + "beendet, setze Messung zurück...");
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

        //Beim Schliessen der Applikation
        private void OCT_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            SafetyStop();
            StopMacroProcess();
        }

        // GUI initialisieren
        private void InitGUI()
        {
            groupBoxAchsensteuerung.Visible = false;
            groupBoxFile.Visible = false;
            buttonDevMode.Visible = false;
            buttonMessStart.Visible = false;
            buttonPositioning.Visible = false;
            buttonMessStart.Enabled = false;

            comboBoxProgramme.DataSource = programFileManager.program_names;

            toolTipCommands.SetToolTip(groupBoxCommand, "CTRL + E um die Messung Zurücksetzen\n CTRL + D für Entwicklermodus");

            comboBoxCOMPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxCOMPort.Items.Count > 0)
                comboBoxCOMPort.SelectedIndex = 0;
        }

        //Sicherheits-Stopp -> alle Motoren anhalten
        private void SafetyStop()
        {
            tmcm3110Controller.MotorStop(0);
            tmcm3110Controller.MotorStop(1);
            tmcm3110Controller.MotorStop(2);
        }

        // Log to console with Timestamp and Color
        public void LogToConsole(string text, Color? color = null)
        {
            Color c = color ?? Color.White;

            if (textBoxConsole.InvokeRequired)
            {
                textBoxConsole.Invoke(new Action(() =>
                {
                    int start = textBoxConsole.TextLength;
                    string message = $"{DateTime.Now:HH:mm:ss}: {text}{Environment.NewLine}";
                    textBoxConsole.AppendText(message);
                    textBoxConsole.Select(start, message.Length);
                    textBoxConsole.SelectionColor = c;
                    textBoxConsole.SelectionLength = 0;
                    textBoxConsole.ScrollToCaret();
                }));
            }
            else
            {
                int start = textBoxConsole.TextLength;
                string message = $"{DateTime.Now:HH:mm:ss}: {text}{Environment.NewLine}";
                textBoxConsole.AppendText(message);
                textBoxConsole.Select(start, message.Length);
                textBoxConsole.SelectionColor = c;
                textBoxConsole.SelectionLength = 0;
                textBoxConsole.ScrollToCaret();
            }
        }

        // Reset GUI for next measurement
        private void ResetMeasurement()
        {
            pictureBoxDisplay.Image = null;
            buttonMessStart.Enabled = false;
            buttonMessStart.Visible = false;
            buttonPositioning.Enabled = true;
            buttonPositioning.Visible = false;
            buttonMessStart.BackColor = Color.GreenYellow;
            buttonMessStart.Text = "Messung Starten";
            comboBoxProgramme.Enabled = true;
            comboBoxProgramme.SelectedIndex = -1;
        }

        // Aktion wenn Messung gestartet wird
        private void buttonMessStart_Click(object sender, EventArgs e)
        {
            buttonMessStart.Enabled = false;
            buttonMessStart.BackColor = Color.Orange;
            buttonMessStart.Text = "Messung läuft…";
            comboBoxProgramme.Enabled = false;
            Refresh();

            LogToConsole("Starte Makro: " + macroFile);

            // Makro Rekorder starten
            try
            {
                tmcm3110Controller.RotateRight(2, programFileManager.GetSpeedRot(selectedProgram));
                macroProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = macroRecorderPath,
                        Arguments = "\"" + macroFile + "\"",
                        UseShellExecute = true
                    }
                };

                macroProcess.Start();
                macroProcess.WaitForInputIdle();

                IntPtr hWnd = IntPtr.Zero;
                int retries = 10;

                while (hWnd == IntPtr.Zero && retries-- > 0)
                {
                    System.Threading.Thread.Sleep(300);
                    macroProcess.Refresh();
                    hWnd = macroProcess.MainWindowHandle;
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
                LogToConsole("Fehler beim Starten oder Steuern:\n" + ex.Message, Color.Red);
            }
        }

        //Messobjekt auf Position bewegen
        private async void buttonPositioning_Click(object sender, EventArgs e)
        {
            LogToConsole("Positioniere...");

            try
            {
                tmcm3110Controller.MovePositionAbs(0, targetPos0);
                tmcm3110Controller.MovePositionAbs(1, targetPos1);
            }
            catch (Exception ex)
            {
                LogToConsole("TMCM Controller Fehler" + ex.Message);
            }

            var sw = Stopwatch.StartNew();
            while (Math.Abs(pos_ax0 - targetPos0) > POS_TOL || Math.Abs(pos_ax1 - targetPos1) > POS_TOL)
            {
                await Task.Delay(1);

                if (sw.ElapsedMilliseconds > MAX_POS_TIME)
                {
                    LogToConsole("[WARNING] Zielposition nicht erreicht", Color.Red);
                    SafetyStop();
                    ResetMeasurement();
                    return;
                }
            }

            LogToConsole("Zielposition erreicht", Color.Green);
            buttonMessStart.Enabled = true;
            buttonPositioning.Enabled = false;
        }

        // Manuelle Achsensteuerung im Entwicklermodus
        private void buttonTMCMsend_Click(object sender, EventArgs e)
        {
            byte TMCM_command = (byte)(comboBoxTMCMcmd.SelectedIndex);
            byte TMCM_axis = (byte)(comboBoxTMCMaxis.SelectedIndex);

            // Parse the value as signed double
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
            // Parse the value as signed double
            if (!int.TryParse(textBoxSpeedRot.Text, out speed_rot))
            {
                LogToConsole("Please enter a valid integer");
                return;
            }

            if (selectedProgram >= 0 && selectedProgram < programFileManager.GetNumPrograms())
            {
                var selectedProg = programFileManager.GetProgram(selectedProgram);

                // Overwrite axis values with the *current live values*
                selectedProg.Axis0 = pos_ax0;
                selectedProg.Axis1 = pos_ax1;
                selectedProg.SpeedRot = speed_rot;

                // Save back to CSV
                programFileManager.SavePrograms();

                // UI feedback
                buttonSave.BackColor = Color.Gray;
                LogToConsole($"CSV gespeichert! {selectedProg.Name} -> Ax0={selectedProg.Axis0}, Ax1={selectedProg.Axis1}, speed={selectedProg.SpeedRot}");
                buttonSave.BackColor = SystemColors.ButtonFace;
            }
            else
            {
                LogToConsole("Please select a program");
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

        // Updaten des aktuell ausgewählten Programms, mit Folgeaktionen
        private void comboBoxMessobjekt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Programmparameter updaten
            string programName;
            selectedProgram = comboBoxProgramme.SelectedIndex;
            if (selectedProgram >= 0)
            {
                targetPos0 = programFileManager.GetAxis0_Value(selectedProgram);
                targetPos1 = programFileManager.GetAxis1_Value(selectedProgram);
                programName = programFileManager.GetProgramName(selectedProgram);
                LogToConsole($"{programName} target position: {targetPos0},{targetPos1}");
                labelSelProgDisp.Text = programName;
            }
            else
            {
                targetPos0 = -99.99;
                targetPos1 = -99.99;
                labelSelProgDisp.Text = "";
            }

            // Makro-Pfad festlegen
            switch (selectedProgram)
            {
                case 0:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_Einschalten_auto.mrf";     //Lunker Boden
                    break;
                case 1:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_60_Bilder.mrf";            //2000er Impeller innen
                    break;
                case 2:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_60_Bilder.mrf";            //2000er Impeller aussen
                    break;
                case 3:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_30_Bilder.mrf";            //600er Pumpenkopf
                    break;
                case 4:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_30_Bilder.mrf";            //2000er Pumpenkopf
                    break;
                case 5:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_12_Bilder.mrf";            //Wandstärke 4k Impeller
                    break;
                case 6:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_12_Bilder.mrf";            //Wandstärke 4k ZB
                    break;
                case 7:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_30_Bilder.mrf";            //LPI 30
                    break;
                case 8:
                    macroFile = @"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Macro-Recorder\01_Makros-OCT\01_Master-Makro\OCT_30_Bilder.mrf";            //Varia 30 Bilder
                    break;
                default:
                    selectedProgram = -1;
                    break;
            }

            // Vorschaubild festlegen
            if (selectedProgram == 0)
            {
                pictureBoxDisplay.Image = null;
            }
            else if (selectedProgram == 1 || selectedProgram == 2)
            {
                pictureBoxDisplay.Image = Image.FromFile(@"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Positioniersystem\Grafiken\impeller.gif");
            }
            else if (selectedProgram == 3 || selectedProgram == 4)
            {
                pictureBoxDisplay.Image = Image.FromFile(@"W:\Production\Equipment\Apparate\OCT-Anterion\03_Software\Positioniersystem\Grafiken\pumphead.gif");
            }
            else
            {
                pictureBoxDisplay.Image = null;
            }

            //Wenn Positionen bereits in Toleranz liegen, Mess Start freigeben
            if (Math.Abs(pos_ax0 - targetPos0) < POS_TOL && Math.Abs(pos_ax1 - targetPos1) < POS_TOL)
            {
                buttonPositioning.Enabled = false;
                buttonMessStart.Enabled = true;
            }
            else
            {
                buttonPositioning.Enabled = true;
                buttonMessStart.Enabled = false;
            }
        }

        //COM Port wird geändert
        private void comboBoxCOMPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string portName = comboBoxCOMPort.SelectedItem.ToString();
            tmcm3110Controller.ReopenSerialPort(portName);
        }

        // Methode zum Stoppen des Makro-Prozesses
        private void StopMacroProcess()
        {
            try
            {
                if (macroProcess != null && !macroProcess.HasExited)
                {
                    // Versuche zuerst, das Fenster normal zu schließen
                    if (!macroProcess.CloseMainWindow())
                    {
                        // Falls das nicht geht, hart beenden
                        macroProcess.Kill();
                    }

                    macroProcess.WaitForExit();
                    macroProcess.Dispose();
                    macroProcess = null;

                    LogToConsole("Makro-Prozess gestoppt.");
                }
            }
            catch (Exception ex)
            {
                LogToConsole("Fehler beim Beenden des Makro-Prozesses:\n" + ex.Message, Color.Red);
            }
        }
    }
}
