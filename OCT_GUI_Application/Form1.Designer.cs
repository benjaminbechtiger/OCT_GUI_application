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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCT_Window));
            this.groupBoxProgrammwahl = new System.Windows.Forms.GroupBox();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
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
            this.labelAxis1Disp = new System.Windows.Forms.Label();
            this.labelAxis0Disp = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPosAx1 = new System.Windows.Forms.Label();
            this.labelPosAx0 = new System.Windows.Forms.Label();
            this.labelActPos = new System.Windows.Forms.Label();
            this.labelSelProgDisp = new System.Windows.Forms.Label();
            this.labelSelProg = new System.Windows.Forms.Label();
            this.labelSpeedRot = new System.Windows.Forms.Label();
            this.textBoxSpeedRot = new System.Windows.Forms.TextBox();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.groupBoxProgrammwahl.SuspendLayout();
            this.groupBoxCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.groupBoxAchsensteuerung.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProgrammwahl
            // 
            this.groupBoxProgrammwahl.Controls.Add(this.textBoxConsole);
            this.groupBoxProgrammwahl.Controls.Add(this.buttonMessStart);
            this.groupBoxProgrammwahl.Controls.Add(this.labelMessobjekt);
            this.groupBoxProgrammwahl.Controls.Add(this.comboBoxMessobjekt);
            this.groupBoxProgrammwahl.Location = new System.Drawing.Point(447, 12);
            this.groupBoxProgrammwahl.Name = "groupBoxProgrammwahl";
            this.groupBoxProgrammwahl.Size = new System.Drawing.Size(776, 269);
            this.groupBoxProgrammwahl.TabIndex = 0;
            this.groupBoxProgrammwahl.TabStop = false;
            this.groupBoxProgrammwahl.Text = "Programmwahl";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.BackColor = System.Drawing.Color.Black;
            this.textBoxConsole.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConsole.ForeColor = System.Drawing.SystemColors.Info;
            this.textBoxConsole.Location = new System.Drawing.Point(32, 102);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ReadOnly = true;
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(721, 152);
            this.textBoxConsole.TabIndex = 5;
            // 
            // buttonMessStart
            // 
            this.buttonMessStart.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonMessStart.Location = new System.Drawing.Point(619, 26);
            this.buttonMessStart.Name = "buttonMessStart";
            this.buttonMessStart.Size = new System.Drawing.Size(134, 59);
            this.buttonMessStart.TabIndex = 4;
            this.buttonMessStart.Text = "Messung Starten";
            this.buttonMessStart.UseVisualStyleBackColor = false;
            this.buttonMessStart.Visible = false;
            this.buttonMessStart.Click += new System.EventHandler(this.buttonMessStart_Click);
            // 
            // labelMessobjekt
            // 
            this.labelMessobjekt.AutoSize = true;
            this.labelMessobjekt.Location = new System.Drawing.Point(28, 45);
            this.labelMessobjekt.Name = "labelMessobjekt";
            this.labelMessobjekt.Size = new System.Drawing.Size(168, 20);
            this.labelMessobjekt.TabIndex = 2;
            this.labelMessobjekt.Text = "Zu messendes Objekt:";
            // 
            // comboBoxMessobjekt
            // 
            this.comboBoxMessobjekt.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxMessobjekt.FormattingEnabled = true;
            this.comboBoxMessobjekt.Items.AddRange(new object[] {
            "600er Impeller",
            "2000er Impeller innen",
            "2000er Impeller aussen",
            "600er Pumpenkopf",
            "2000er Pumpenkopf"});
            this.comboBoxMessobjekt.Location = new System.Drawing.Point(220, 42);
            this.comboBoxMessobjekt.Name = "comboBoxMessobjekt";
            this.comboBoxMessobjekt.Size = new System.Drawing.Size(298, 28);
            this.comboBoxMessobjekt.TabIndex = 0;
            this.comboBoxMessobjekt.SelectedIndexChanged += new System.EventHandler(this.comboBoxMessobjekt_SelectedIndexChanged);
            // 
            // buttonDevMode
            // 
            this.buttonDevMode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDevMode.Location = new System.Drawing.Point(1168, 286);
            this.buttonDevMode.Name = "buttonDevMode";
            this.buttonDevMode.Size = new System.Drawing.Size(55, 37);
            this.buttonDevMode.TabIndex = 6;
            this.buttonDevMode.Text = "Dev";
            this.buttonDevMode.UseVisualStyleBackColor = false;
            this.buttonDevMode.Click += new System.EventHandler(this.buttonDevMode_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxCommand.Location = new System.Drawing.Point(21, 25);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(1190, 26);
            this.textBoxCommand.TabIndex = 1;
            // 
            // groupBoxCommand
            // 
            this.groupBoxCommand.Controls.Add(this.textBoxCommand);
            this.groupBoxCommand.Location = new System.Drawing.Point(12, 588);
            this.groupBoxCommand.Name = "groupBoxCommand";
            this.groupBoxCommand.Size = new System.Drawing.Size(1234, 64);
            this.groupBoxCommand.TabIndex = 2;
            this.groupBoxCommand.TabStop = false;
            this.groupBoxCommand.Text = "Kommandozeile";
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.Location = new System.Drawing.Point(33, 22);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(259, 259);
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
            this.groupBoxAchsensteuerung.Location = new System.Drawing.Point(33, 315);
            this.groupBoxAchsensteuerung.Name = "groupBoxAchsensteuerung";
            this.groupBoxAchsensteuerung.Size = new System.Drawing.Size(371, 254);
            this.groupBoxAchsensteuerung.TabIndex = 4;
            this.groupBoxAchsensteuerung.TabStop = false;
            this.groupBoxAchsensteuerung.Text = "Achsensteuerung";
            // 
            // labelTMCMaxs
            // 
            this.labelTMCMaxs.AutoSize = true;
            this.labelTMCMaxs.Location = new System.Drawing.Point(20, 82);
            this.labelTMCMaxs.Name = "labelTMCMaxs";
            this.labelTMCMaxs.Size = new System.Drawing.Size(54, 20);
            this.labelTMCMaxs.TabIndex = 6;
            this.labelTMCMaxs.Text = "Motor:";
            // 
            // comboBoxTMCMaxis
            // 
            this.comboBoxTMCMaxis.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxTMCMaxis.FormattingEnabled = true;
            this.comboBoxTMCMaxis.Items.AddRange(new object[] {
            "Achse 0",
            "Achse 1",
            "Achse 2"});
            this.comboBoxTMCMaxis.Location = new System.Drawing.Point(152, 79);
            this.comboBoxTMCMaxis.Name = "comboBoxTMCMaxis";
            this.comboBoxTMCMaxis.Size = new System.Drawing.Size(174, 28);
            this.comboBoxTMCMaxis.TabIndex = 5;
            // 
            // labelTMCMval
            // 
            this.labelTMCMval.AutoSize = true;
            this.labelTMCMval.Location = new System.Drawing.Point(20, 133);
            this.labelTMCMval.Name = "labelTMCMval";
            this.labelTMCMval.Size = new System.Drawing.Size(47, 20);
            this.labelTMCMval.TabIndex = 4;
            this.labelTMCMval.Text = "Wert:";
            // 
            // labelTMCMcmd
            // 
            this.labelTMCMcmd.AutoSize = true;
            this.labelTMCMcmd.Location = new System.Drawing.Point(20, 32);
            this.labelTMCMcmd.Name = "labelTMCMcmd";
            this.labelTMCMcmd.Size = new System.Drawing.Size(94, 20);
            this.labelTMCMcmd.TabIndex = 3;
            this.labelTMCMcmd.Text = "Kommando:";
            // 
            // buttonTMCMsend
            // 
            this.buttonTMCMsend.BackColor = System.Drawing.Color.Turquoise;
            this.buttonTMCMsend.Location = new System.Drawing.Point(116, 190);
            this.buttonTMCMsend.Name = "buttonTMCMsend";
            this.buttonTMCMsend.Size = new System.Drawing.Size(110, 46);
            this.buttonTMCMsend.TabIndex = 2;
            this.buttonTMCMsend.Text = "Ausführen";
            this.buttonTMCMsend.UseVisualStyleBackColor = false;
            this.buttonTMCMsend.Click += new System.EventHandler(this.buttonTMCMsend_Click);
            // 
            // textBoxTMCMval
            // 
            this.textBoxTMCMval.Location = new System.Drawing.Point(152, 130);
            this.textBoxTMCMval.Name = "textBoxTMCMval";
            this.textBoxTMCMval.Size = new System.Drawing.Size(174, 26);
            this.textBoxTMCMval.TabIndex = 1;
            this.textBoxTMCMval.Text = "0";
            // 
            // comboBoxTMCMcmd
            // 
            this.comboBoxTMCMcmd.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxTMCMcmd.FormattingEnabled = true;
            this.comboBoxTMCMcmd.Items.AddRange(new object[] {
            "Rotation Rechts",
            "Rotation Links",
            "Motor Stop",
            "Bewege Absolut",
            "Referenzfahrt Start"});
            this.comboBoxTMCMcmd.Location = new System.Drawing.Point(152, 29);
            this.comboBoxTMCMcmd.Name = "comboBoxTMCMcmd";
            this.comboBoxTMCMcmd.Size = new System.Drawing.Size(174, 28);
            this.comboBoxTMCMcmd.TabIndex = 0;
            // 
            // groupBoxFile
            // 
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
            this.groupBoxFile.Location = new System.Drawing.Point(447, 315);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(776, 254);
            this.groupBoxFile.TabIndex = 5;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "Programmverwaltung";
            // 
            // labelAxis1Disp
            // 
            this.labelAxis1Disp.AutoSize = true;
            this.labelAxis1Disp.Location = new System.Drawing.Point(248, 87);
            this.labelAxis1Disp.Name = "labelAxis1Disp";
            this.labelAxis1Disp.Size = new System.Drawing.Size(29, 20);
            this.labelAxis1Disp.TabIndex = 7;
            this.labelAxis1Disp.Text = "A1";
            // 
            // labelAxis0Disp
            // 
            this.labelAxis0Disp.AutoSize = true;
            this.labelAxis0Disp.Location = new System.Drawing.Point(248, 64);
            this.labelAxis0Disp.Name = "labelAxis0Disp";
            this.labelAxis0Disp.Size = new System.Drawing.Size(29, 20);
            this.labelAxis0Disp.TabIndex = 6;
            this.labelAxis0Disp.Text = "A0";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.Location = new System.Drawing.Point(698, 14);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(72, 70);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelPosAx1
            // 
            this.labelPosAx1.AutoSize = true;
            this.labelPosAx1.ForeColor = System.Drawing.Color.Blue;
            this.labelPosAx1.Location = new System.Drawing.Point(289, 87);
            this.labelPosAx1.Name = "labelPosAx1";
            this.labelPosAx1.Size = new System.Drawing.Size(21, 20);
            this.labelPosAx1.TabIndex = 4;
            this.labelPosAx1.Text = "...";
            // 
            // labelPosAx0
            // 
            this.labelPosAx0.AutoSize = true;
            this.labelPosAx0.ForeColor = System.Drawing.Color.Crimson;
            this.labelPosAx0.Location = new System.Drawing.Point(289, 64);
            this.labelPosAx0.Name = "labelPosAx0";
            this.labelPosAx0.Size = new System.Drawing.Size(21, 20);
            this.labelPosAx0.TabIndex = 3;
            this.labelPosAx0.Text = "...";
            // 
            // labelActPos
            // 
            this.labelActPos.AutoSize = true;
            this.labelActPos.Location = new System.Drawing.Point(32, 64);
            this.labelActPos.Name = "labelActPos";
            this.labelActPos.Size = new System.Drawing.Size(168, 20);
            this.labelActPos.TabIndex = 2;
            this.labelActPos.Text = "Aktuelle Position [mm]:";
            // 
            // labelSelProgDisp
            // 
            this.labelSelProgDisp.AutoSize = true;
            this.labelSelProgDisp.ForeColor = System.Drawing.Color.Yellow;
            this.labelSelProgDisp.Location = new System.Drawing.Point(248, 32);
            this.labelSelProgDisp.Name = "labelSelProgDisp";
            this.labelSelProgDisp.Size = new System.Drawing.Size(21, 20);
            this.labelSelProgDisp.TabIndex = 1;
            this.labelSelProgDisp.Text = "...";
            // 
            // labelSelProg
            // 
            this.labelSelProg.AutoSize = true;
            this.labelSelProg.Location = new System.Drawing.Point(32, 32);
            this.labelSelProg.Name = "labelSelProg";
            this.labelSelProg.Size = new System.Drawing.Size(190, 20);
            this.labelSelProg.TabIndex = 0;
            this.labelSelProg.Text = "Ausgewähltes Programm:";
            // 
            // labelSpeedRot
            // 
            this.labelSpeedRot.AutoSize = true;
            this.labelSpeedRot.Location = new System.Drawing.Point(32, 116);
            this.labelSpeedRot.Name = "labelSpeedRot";
            this.labelSpeedRot.Size = new System.Drawing.Size(206, 20);
            this.labelSpeedRot.TabIndex = 8;
            this.labelSpeedRot.Text = "Drehgeschwindigkeit [1/min]";
            // 
            // textBoxSpeedRot
            // 
            this.textBoxSpeedRot.Location = new System.Drawing.Point(252, 116);
            this.textBoxSpeedRot.Name = "textBoxSpeedRot";
            this.textBoxSpeedRot.Size = new System.Drawing.Size(100, 26);
            this.textBoxSpeedRot.TabIndex = 9;
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5"});
            this.comboBoxCOMPort.Location = new System.Drawing.Point(333, 54);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(82, 28);
            this.comboBoxCOMPort.TabIndex = 7;
            // 
            // OCT_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.comboBoxCOMPort);
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
        private System.Windows.Forms.TextBox textBoxConsole;
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
    }
}

