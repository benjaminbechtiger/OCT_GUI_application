namespace OCT_GUI_Application
{
    partial class OCT_Window
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCT_Window));
            this.groupBoxProgrammwahl = new System.Windows.Forms.GroupBox();
            this.textBoxConsole = new System.Windows.Forms.RichTextBox();
            this.buttonMessStart = new System.Windows.Forms.Button();
            this.labelMessobjekt = new System.Windows.Forms.Label();
            this.comboBoxMessobjekt = new System.Windows.Forms.ComboBox();
            this.buttonDevMode = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.groupBoxCommand = new System.Windows.Forms.GroupBox();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.groupBoxAchsensteuerung = new System.Windows.Forms.GroupBox();
            this.labelTMCMaxs = new System.Windows.Forms.Label();
            this.comboBoxTMCMaxis = new System.Windows.Forms.ComboBox();
            this.labelTMCMval = new System.Windows.Forms.Label();
            this.labelTMCMcmd = new System.Windows.Forms.Label();
            this.buttonTMCMsend = new System.Windows.Forms.Button();
            this.textBoxTMCMval = new System.Windows.Forms.TextBox();
            this.comboBoxTMCMcmd = new System.Windows.Forms.ComboBox();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.labelCOMport = new System.Windows.Forms.Label();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.textBoxSpeedRot = new System.Windows.Forms.TextBox();
            this.labelSpeedRot = new System.Windows.Forms.Label();
            this.labelAxis1Disp = new System.Windows.Forms.Label();
            this.labelAxis0Disp = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPosAx1 = new System.Windows.Forms.Label();
            this.labelPosAx0 = new System.Windows.Forms.Label();
            this.labelActPos = new System.Windows.Forms.Label();
            this.labelSelProgDisp = new System.Windows.Forms.Label();
            this.labelSelProg = new System.Windows.Forms.Label();
            this.toolTipCommands = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPositioning = new System.Windows.Forms.Button();
            this.groupBoxProgrammwahl.SuspendLayout();
            this.groupBoxCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.groupBoxAchsensteuerung.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProgrammwahl
            // 
            this.groupBoxProgrammwahl.Controls.Add(this.buttonPositioning);
            this.groupBoxProgrammwahl.Controls.Add(this.textBoxConsole);
            this.groupBoxProgrammwahl.Controls.Add(this.buttonMessStart);
            this.groupBoxProgrammwahl.Controls.Add(this.labelMessobjekt);
            this.groupBoxProgrammwahl.Controls.Add(this.comboBoxMessobjekt);
            this.groupBoxProgrammwahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProgrammwahl.Location = new System.Drawing.Point(507, 37);
            this.groupBoxProgrammwahl.Name = "groupBoxProgrammwahl";
            this.groupBoxProgrammwahl.Size = new System.Drawing.Size(1361, 386);
            this.groupBoxProgrammwahl.TabIndex = 0;
            this.groupBoxProgrammwahl.TabStop = false;
            this.groupBoxProgrammwahl.Text = "Programmauswahl";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.BackColor = System.Drawing.Color.Black;
            this.textBoxConsole.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConsole.ForeColor = System.Drawing.Color.White;
            this.textBoxConsole.Location = new System.Drawing.Point(34, 246);
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.Size = new System.Drawing.Size(1301, 122);
            this.textBoxConsole.TabIndex = 5;
            this.textBoxConsole.Text = "";
            // 
            // buttonMessStart
            // 
            this.buttonMessStart.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonMessStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMessStart.Location = new System.Drawing.Point(1074, 59);
            this.buttonMessStart.Name = "buttonMessStart";
            this.buttonMessStart.Size = new System.Drawing.Size(213, 119);
            this.buttonMessStart.TabIndex = 4;
            this.buttonMessStart.Text = "Messung Starten";
            this.buttonMessStart.UseVisualStyleBackColor = false;
            this.buttonMessStart.Visible = false;
            this.buttonMessStart.Click += new System.EventHandler(this.buttonMessStart_Click);
            // 
            // labelMessobjekt
            // 
            this.labelMessobjekt.AutoSize = true;
            this.labelMessobjekt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessobjekt.Location = new System.Drawing.Point(28, 102);
            this.labelMessobjekt.Name = "labelMessobjekt";
            this.labelMessobjekt.Size = new System.Drawing.Size(154, 32);
            this.labelMessobjekt.TabIndex = 2;
            this.labelMessobjekt.Text = "Programm:";
            // 
            // comboBoxMessobjekt
            // 
            this.comboBoxMessobjekt.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxMessobjekt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMessobjekt.FormattingEnabled = true;
            this.comboBoxMessobjekt.Items.AddRange(new object[] {
            "Lunker Boden",
            "2000er Impeller innen",
            "2000er Impeller aussen",
            "600er Pumpenkopf",
            "2000er Pumpenkopf",
            "Wandstärke 4k Impeller",
            "Wandstärke 4k ZB",
            "LPI 30",
            "Varia 30 Bilder"});
            this.comboBoxMessobjekt.Location = new System.Drawing.Point(209, 96);
            this.comboBoxMessobjekt.Name = "comboBoxMessobjekt";
            this.comboBoxMessobjekt.Size = new System.Drawing.Size(543, 40);
            this.comboBoxMessobjekt.TabIndex = 0;
            this.comboBoxMessobjekt.SelectedIndexChanged += new System.EventHandler(this.comboBoxMessobjekt_SelectedIndexChanged);
            // 
            // buttonDevMode
            // 
            this.buttonDevMode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDevMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDevMode.Location = new System.Drawing.Point(899, 445);
            this.buttonDevMode.Name = "buttonDevMode";
            this.buttonDevMode.Size = new System.Drawing.Size(83, 50);
            this.buttonDevMode.TabIndex = 6;
            this.buttonDevMode.Text = "Dev";
            this.buttonDevMode.UseVisualStyleBackColor = false;
            this.buttonDevMode.Click += new System.EventHandler(this.buttonDevMode_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommand.Location = new System.Drawing.Point(21, 29);
            this.textBoxCommand.MinimumSize = new System.Drawing.Size(32, 32);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(1788, 35);
            this.textBoxCommand.TabIndex = 1;
            // 
            // groupBoxCommand
            // 
            this.groupBoxCommand.Controls.Add(this.textBoxCommand);
            this.groupBoxCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommand.Location = new System.Drawing.Point(33, 923);
            this.groupBoxCommand.Name = "groupBoxCommand";
            this.groupBoxCommand.Size = new System.Drawing.Size(1835, 79);
            this.groupBoxCommand.TabIndex = 2;
            this.groupBoxCommand.TabStop = false;
            this.groupBoxCommand.Text = "Kommandozeile";
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.Location = new System.Drawing.Point(33, 37);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(397, 386);
            this.pictureBoxDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDisplay.TabIndex = 3;
            this.pictureBoxDisplay.TabStop = false;
            // 
            // groupBoxAchsensteuerung
            // 
            this.groupBoxAchsensteuerung.Controls.Add(this.labelTMCMaxs);
            this.groupBoxAchsensteuerung.Controls.Add(this.comboBoxTMCMaxis);
            this.groupBoxAchsensteuerung.Controls.Add(this.labelTMCMval);
            this.groupBoxAchsensteuerung.Controls.Add(this.labelTMCMcmd);
            this.groupBoxAchsensteuerung.Controls.Add(this.buttonTMCMsend);
            this.groupBoxAchsensteuerung.Controls.Add(this.textBoxTMCMval);
            this.groupBoxAchsensteuerung.Controls.Add(this.comboBoxTMCMcmd);
            this.groupBoxAchsensteuerung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAchsensteuerung.Location = new System.Drawing.Point(33, 510);
            this.groupBoxAchsensteuerung.Name = "groupBoxAchsensteuerung";
            this.groupBoxAchsensteuerung.Size = new System.Drawing.Size(604, 386);
            this.groupBoxAchsensteuerung.TabIndex = 4;
            this.groupBoxAchsensteuerung.TabStop = false;
            this.groupBoxAchsensteuerung.Text = "Achsensteuerung";
            // 
            // labelTMCMaxs
            // 
            this.labelTMCMaxs.AutoSize = true;
            this.labelTMCMaxs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTMCMaxs.Location = new System.Drawing.Point(32, 135);
            this.labelTMCMaxs.Name = "labelTMCMaxs";
            this.labelTMCMaxs.Size = new System.Drawing.Size(95, 32);
            this.labelTMCMaxs.TabIndex = 6;
            this.labelTMCMaxs.Text = "Motor:";
            // 
            // comboBoxTMCMaxis
            // 
            this.comboBoxTMCMaxis.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxTMCMaxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTMCMaxis.FormattingEnabled = true;
            this.comboBoxTMCMaxis.Items.AddRange(new object[] {
            "Achse 0",
            "Achse 1",
            "Achse 2"});
            this.comboBoxTMCMaxis.Location = new System.Drawing.Point(202, 132);
            this.comboBoxTMCMaxis.Name = "comboBoxTMCMaxis";
            this.comboBoxTMCMaxis.Size = new System.Drawing.Size(271, 40);
            this.comboBoxTMCMaxis.TabIndex = 5;
            // 
            // labelTMCMval
            // 
            this.labelTMCMval.AutoSize = true;
            this.labelTMCMval.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTMCMval.Location = new System.Drawing.Point(32, 201);
            this.labelTMCMval.Name = "labelTMCMval";
            this.labelTMCMval.Size = new System.Drawing.Size(82, 32);
            this.labelTMCMval.TabIndex = 4;
            this.labelTMCMval.Text = "Wert:";
            // 
            // labelTMCMcmd
            // 
            this.labelTMCMcmd.AutoSize = true;
            this.labelTMCMcmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTMCMcmd.Location = new System.Drawing.Point(32, 64);
            this.labelTMCMcmd.Name = "labelTMCMcmd";
            this.labelTMCMcmd.Size = new System.Drawing.Size(168, 32);
            this.labelTMCMcmd.TabIndex = 3;
            this.labelTMCMcmd.Text = "Kommando:";
            // 
            // buttonTMCMsend
            // 
            this.buttonTMCMsend.BackColor = System.Drawing.Color.Turquoise;
            this.buttonTMCMsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTMCMsend.Location = new System.Drawing.Point(387, 277);
            this.buttonTMCMsend.Name = "buttonTMCMsend";
            this.buttonTMCMsend.Size = new System.Drawing.Size(194, 86);
            this.buttonTMCMsend.TabIndex = 2;
            this.buttonTMCMsend.Text = "Ausführen";
            this.buttonTMCMsend.UseVisualStyleBackColor = false;
            this.buttonTMCMsend.Click += new System.EventHandler(this.buttonTMCMsend_Click);
            // 
            // textBoxTMCMval
            // 
            this.textBoxTMCMval.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTMCMval.Location = new System.Drawing.Point(202, 198);
            this.textBoxTMCMval.Name = "textBoxTMCMval";
            this.textBoxTMCMval.Size = new System.Drawing.Size(271, 39);
            this.textBoxTMCMval.TabIndex = 1;
            this.textBoxTMCMval.Text = "0";
            // 
            // comboBoxTMCMcmd
            // 
            this.comboBoxTMCMcmd.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxTMCMcmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTMCMcmd.FormattingEnabled = true;
            this.comboBoxTMCMcmd.Items.AddRange(new object[] {
            "Rotation Rechts",
            "Rotation Links",
            "Motor Stop",
            "Bewege Absolut",
            "Referenzfahrt Start"});
            this.comboBoxTMCMcmd.Location = new System.Drawing.Point(202, 61);
            this.comboBoxTMCMcmd.Name = "comboBoxTMCMcmd";
            this.comboBoxTMCMcmd.Size = new System.Drawing.Size(271, 40);
            this.comboBoxTMCMcmd.TabIndex = 0;
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.labelCOMport);
            this.groupBoxFile.Controls.Add(this.comboBoxCOMPort);
            this.groupBoxFile.Controls.Add(this.textBoxSpeedRot);
            this.groupBoxFile.Controls.Add(this.labelSpeedRot);
            this.groupBoxFile.Controls.Add(this.labelAxis1Disp);
            this.groupBoxFile.Controls.Add(this.labelAxis0Disp);
            this.groupBoxFile.Controls.Add(this.buttonSave);
            this.groupBoxFile.Controls.Add(this.labelPosAx1);
            this.groupBoxFile.Controls.Add(this.labelPosAx0);
            this.groupBoxFile.Controls.Add(this.labelActPos);
            this.groupBoxFile.Controls.Add(this.labelSelProgDisp);
            this.groupBoxFile.Controls.Add(this.labelSelProg);
            this.groupBoxFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFile.Location = new System.Drawing.Point(725, 510);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(1143, 386);
            this.groupBoxFile.TabIndex = 5;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "Programmverwaltung";
            // 
            // labelCOMport
            // 
            this.labelCOMport.AutoSize = true;
            this.labelCOMport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCOMport.Location = new System.Drawing.Point(814, 304);
            this.labelCOMport.Name = "labelCOMport";
            this.labelCOMport.Size = new System.Drawing.Size(156, 32);
            this.labelCOMport.TabIndex = 10;
            this.labelCOMport.Text = "Serial Port:";
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxCOMPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(994, 301);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(124, 40);
            this.comboBoxCOMPort.TabIndex = 7;
            this.comboBoxCOMPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPort_SelectedIndexChanged);
            // 
            // textBoxSpeedRot
            // 
            this.textBoxSpeedRot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpeedRot.Location = new System.Drawing.Point(434, 301);
            this.textBoxSpeedRot.Name = "textBoxSpeedRot";
            this.textBoxSpeedRot.Size = new System.Drawing.Size(100, 39);
            this.textBoxSpeedRot.TabIndex = 9;
            // 
            // labelSpeedRot
            // 
            this.labelSpeedRot.AutoSize = true;
            this.labelSpeedRot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeedRot.Location = new System.Drawing.Point(32, 304);
            this.labelSpeedRot.Name = "labelSpeedRot";
            this.labelSpeedRot.Size = new System.Drawing.Size(372, 32);
            this.labelSpeedRot.TabIndex = 8;
            this.labelSpeedRot.Text = "Drehgeschwindigkeit [1/min]";
            // 
            // labelAxis1Disp
            // 
            this.labelAxis1Disp.AutoSize = true;
            this.labelAxis1Disp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAxis1Disp.Location = new System.Drawing.Point(428, 220);
            this.labelAxis1Disp.Name = "labelAxis1Disp";
            this.labelAxis1Disp.Size = new System.Drawing.Size(50, 32);
            this.labelAxis1Disp.TabIndex = 7;
            this.labelAxis1Disp.Text = "A1";
            // 
            // labelAxis0Disp
            // 
            this.labelAxis0Disp.AutoSize = true;
            this.labelAxis0Disp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAxis0Disp.Location = new System.Drawing.Point(428, 155);
            this.labelAxis0Disp.Name = "labelAxis0Disp";
            this.labelAxis0Disp.Size = new System.Drawing.Size(50, 32);
            this.labelAxis0Disp.TabIndex = 6;
            this.labelAxis0Disp.Text = "A0";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.Location = new System.Drawing.Point(1045, 29);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(72, 70);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelPosAx1
            // 
            this.labelPosAx1.AutoSize = true;
            this.labelPosAx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosAx1.ForeColor = System.Drawing.Color.Blue;
            this.labelPosAx1.Location = new System.Drawing.Point(484, 220);
            this.labelPosAx1.Name = "labelPosAx1";
            this.labelPosAx1.Size = new System.Drawing.Size(39, 32);
            this.labelPosAx1.TabIndex = 4;
            this.labelPosAx1.Text = "...";
            // 
            // labelPosAx0
            // 
            this.labelPosAx0.AutoSize = true;
            this.labelPosAx0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosAx0.ForeColor = System.Drawing.Color.Crimson;
            this.labelPosAx0.Location = new System.Drawing.Point(484, 155);
            this.labelPosAx0.Name = "labelPosAx0";
            this.labelPosAx0.Size = new System.Drawing.Size(39, 32);
            this.labelPosAx0.TabIndex = 3;
            this.labelPosAx0.Text = "...";
            // 
            // labelActPos
            // 
            this.labelActPos.AutoSize = true;
            this.labelActPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActPos.Location = new System.Drawing.Point(32, 155);
            this.labelActPos.Name = "labelActPos";
            this.labelActPos.Size = new System.Drawing.Size(305, 32);
            this.labelActPos.TabIndex = 2;
            this.labelActPos.Text = "Aktuelle Position [mm]:";
            // 
            // labelSelProgDisp
            // 
            this.labelSelProgDisp.AutoSize = true;
            this.labelSelProgDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelProgDisp.ForeColor = System.Drawing.Color.Yellow;
            this.labelSelProgDisp.Location = new System.Drawing.Point(428, 64);
            this.labelSelProgDisp.Name = "labelSelProgDisp";
            this.labelSelProgDisp.Size = new System.Drawing.Size(39, 32);
            this.labelSelProgDisp.TabIndex = 1;
            this.labelSelProgDisp.Text = "...";
            // 
            // labelSelProg
            // 
            this.labelSelProg.AutoSize = true;
            this.labelSelProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelProg.Location = new System.Drawing.Point(32, 64);
            this.labelSelProg.Name = "labelSelProg";
            this.labelSelProg.Size = new System.Drawing.Size(339, 32);
            this.labelSelProg.TabIndex = 0;
            this.labelSelProg.Text = "Ausgewähltes Programm:";
            // 
            // buttonPositioning
            // 
            this.buttonPositioning.BackColor = System.Drawing.Color.Aqua;
            this.buttonPositioning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPositioning.Location = new System.Drawing.Point(819, 61);
            this.buttonPositioning.Name = "buttonPositioning";
            this.buttonPositioning.Size = new System.Drawing.Size(213, 119);
            this.buttonPositioning.TabIndex = 6;
            this.buttonPositioning.Text = "Auf Position Bewegen";
            this.buttonPositioning.UseVisualStyleBackColor = false;
            this.buttonPositioning.Click += new System.EventHandler(this.buttonPositioning_Click);
            // 
            // OCT_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.buttonDevMode);
            this.Controls.Add(this.groupBoxFile);
            this.Controls.Add(this.groupBoxAchsensteuerung);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Controls.Add(this.groupBoxCommand);
            this.Controls.Add(this.groupBoxProgrammwahl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OCT_Window";
            this.Text = "OCT-Messung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OCT_Window_FormClosing);
            this.Load += new System.EventHandler(this.OCT_Window_Load);
            this.groupBoxProgrammwahl.ResumeLayout(false);
            this.groupBoxProgrammwahl.PerformLayout();
            this.groupBoxCommand.ResumeLayout(false);
            this.groupBoxCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.groupBoxAchsensteuerung.ResumeLayout(false);
            this.groupBoxAchsensteuerung.PerformLayout();
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProgrammwahl;
        private System.Windows.Forms.ComboBox comboBoxMessobjekt;
        private System.Windows.Forms.Label labelMessobjekt;
        private System.Windows.Forms.Button buttonMessStart;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.GroupBox groupBoxCommand;
        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.GroupBox groupBoxAchsensteuerung;
        private System.Windows.Forms.TextBox textBoxTMCMval;
        private System.Windows.Forms.ComboBox comboBoxTMCMcmd;
        private System.Windows.Forms.Button buttonTMCMsend;
        private System.Windows.Forms.Label labelTMCMaxs;
        private System.Windows.Forms.ComboBox comboBoxTMCMaxis;
        private System.Windows.Forms.Label labelTMCMval;
        private System.Windows.Forms.Label labelTMCMcmd;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.Label labelSelProgDisp;
        private System.Windows.Forms.Label labelSelProg;
        private System.Windows.Forms.Label labelActPos;
        private System.Windows.Forms.Label labelPosAx1;
        private System.Windows.Forms.Label labelPosAx0;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDevMode;
        private System.Windows.Forms.Label labelAxis0Disp;
        private System.Windows.Forms.Label labelAxis1Disp;
        private System.Windows.Forms.Label labelSpeedRot;
        private System.Windows.Forms.TextBox textBoxSpeedRot;
        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.Label labelCOMport;
        private System.Windows.Forms.ToolTip toolTipCommands;
        private System.Windows.Forms.RichTextBox textBoxConsole;
        private System.Windows.Forms.Button buttonPositioning;
    }
}

