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
            this.labelGroesse = new System.Windows.Forms.Label();
            this.labelMessobjekt = new System.Windows.Forms.Label();
            this.comboBoxGroesse = new System.Windows.Forms.ComboBox();
            this.comboBoxMessobjekt = new System.Windows.Forms.ComboBox();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.groupBoxCommand = new System.Windows.Forms.GroupBox();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.groupBoxAchsensteuerung = new System.Windows.Forms.GroupBox();
            this.buttonTMCMsend = new System.Windows.Forms.Button();
            this.textBoxTMCMval = new System.Windows.Forms.TextBox();
            this.comboBoxTMCMcmd = new System.Windows.Forms.ComboBox();
            this.labelTMCMcmd = new System.Windows.Forms.Label();
            this.labelTMCMval = new System.Windows.Forms.Label();
            this.comboBoxTMCMaxs = new System.Windows.Forms.ComboBox();
            this.labelTMCMaxs = new System.Windows.Forms.Label();
            this.groupBoxProgrammwahl.SuspendLayout();
            this.groupBoxCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.groupBoxAchsensteuerung.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProgrammwahl
            // 
            this.groupBoxProgrammwahl.Controls.Add(this.textBoxConsole);
            this.groupBoxProgrammwahl.Controls.Add(this.buttonMessStart);
            this.groupBoxProgrammwahl.Controls.Add(this.labelGroesse);
            this.groupBoxProgrammwahl.Controls.Add(this.labelMessobjekt);
            this.groupBoxProgrammwahl.Controls.Add(this.comboBoxGroesse);
            this.groupBoxProgrammwahl.Controls.Add(this.comboBoxMessobjekt);
            this.groupBoxProgrammwahl.Location = new System.Drawing.Point(470, 12);
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
            this.textBoxConsole.Location = new System.Drawing.Point(32, 156);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ReadOnly = true;
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(721, 98);
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
            // labelGroesse
            // 
            this.labelGroesse.AutoSize = true;
            this.labelGroesse.Location = new System.Drawing.Point(28, 100);
            this.labelGroesse.Name = "labelGroesse";
            this.labelGroesse.Size = new System.Drawing.Size(65, 20);
            this.labelGroesse.TabIndex = 3;
            this.labelGroesse.Text = "Grösse:";
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
            // comboBoxGroesse
            // 
            this.comboBoxGroesse.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxGroesse.FormattingEnabled = true;
            this.comboBoxGroesse.Items.AddRange(new object[] {
            "600",
            "2000"});
            this.comboBoxGroesse.Location = new System.Drawing.Point(220, 97);
            this.comboBoxGroesse.Name = "comboBoxGroesse";
            this.comboBoxGroesse.Size = new System.Drawing.Size(176, 28);
            this.comboBoxGroesse.TabIndex = 1;
            // 
            // comboBoxMessobjekt
            // 
            this.comboBoxMessobjekt.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxMessobjekt.FormattingEnabled = true;
            this.comboBoxMessobjekt.Items.AddRange(new object[] {
            "Impeller",
            "Pumpenkopf"});
            this.comboBoxMessobjekt.Location = new System.Drawing.Point(220, 42);
            this.comboBoxMessobjekt.Name = "comboBoxMessobjekt";
            this.comboBoxMessobjekt.Size = new System.Drawing.Size(176, 28);
            this.comboBoxMessobjekt.TabIndex = 0;
            this.comboBoxMessobjekt.SelectedIndexChanged += new System.EventHandler(this.comboBoxMessobjekt_SelectedIndexChanged);
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
            this.pictureBoxDisplay.Location = new System.Drawing.Point(54, 22);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(341, 259);
            this.pictureBoxDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDisplay.TabIndex = 3;
            this.pictureBoxDisplay.TabStop = false;
            // 
            // groupBoxAchsensteuerung
            // 
            this.groupBoxAchsensteuerung.Controls.Add(this.labelTMCMaxs);
            this.groupBoxAchsensteuerung.Controls.Add(this.comboBoxTMCMaxs);
            this.groupBoxAchsensteuerung.Controls.Add(this.labelTMCMval);
            this.groupBoxAchsensteuerung.Controls.Add(this.labelTMCMcmd);
            this.groupBoxAchsensteuerung.Controls.Add(this.buttonTMCMsend);
            this.groupBoxAchsensteuerung.Controls.Add(this.textBoxTMCMval);
            this.groupBoxAchsensteuerung.Controls.Add(this.comboBoxTMCMcmd);
            this.groupBoxAchsensteuerung.Location = new System.Drawing.Point(54, 315);
            this.groupBoxAchsensteuerung.Name = "groupBoxAchsensteuerung";
            this.groupBoxAchsensteuerung.Size = new System.Drawing.Size(341, 254);
            this.groupBoxAchsensteuerung.TabIndex = 4;
            this.groupBoxAchsensteuerung.TabStop = false;
            this.groupBoxAchsensteuerung.Text = "Achsensteuerung";
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
            // 
            // comboBoxTMCMcmd
            // 
            this.comboBoxTMCMcmd.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxTMCMcmd.FormattingEnabled = true;
            this.comboBoxTMCMcmd.Items.AddRange(new object[] {
            "Rotation Rechts",
            "Rotation Links",
            "Motor Stop",
            "Bewege auf Position"});
            this.comboBoxTMCMcmd.Location = new System.Drawing.Point(152, 29);
            this.comboBoxTMCMcmd.Name = "comboBoxTMCMcmd";
            this.comboBoxTMCMcmd.Size = new System.Drawing.Size(174, 28);
            this.comboBoxTMCMcmd.TabIndex = 0;
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
            // labelTMCMval
            // 
            this.labelTMCMval.AutoSize = true;
            this.labelTMCMval.Location = new System.Drawing.Point(20, 133);
            this.labelTMCMval.Name = "labelTMCMval";
            this.labelTMCMval.Size = new System.Drawing.Size(47, 20);
            this.labelTMCMval.TabIndex = 4;
            this.labelTMCMval.Text = "Wert:";
            // 
            // comboBoxTMCMaxs
            // 
            this.comboBoxTMCMaxs.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxTMCMaxs.FormattingEnabled = true;
            this.comboBoxTMCMaxs.Items.AddRange(new object[] {
            "Achse 1",
            "Achse 2",
            "Achse 3"});
            this.comboBoxTMCMaxs.Location = new System.Drawing.Point(152, 79);
            this.comboBoxTMCMaxs.Name = "comboBoxTMCMaxs";
            this.comboBoxTMCMaxs.Size = new System.Drawing.Size(174, 28);
            this.comboBoxTMCMaxs.TabIndex = 5;
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
            // OCT_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1258, 664);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProgrammwahl;
        private System.Windows.Forms.ComboBox comboBoxMessobjekt;
        private System.Windows.Forms.Label labelGroesse;
        private System.Windows.Forms.Label labelMessobjekt;
        private System.Windows.Forms.ComboBox comboBoxGroesse;
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
        private System.Windows.Forms.ComboBox comboBoxTMCMaxs;
        private System.Windows.Forms.Label labelTMCMval;
        private System.Windows.Forms.Label labelTMCMcmd;
    }
}

