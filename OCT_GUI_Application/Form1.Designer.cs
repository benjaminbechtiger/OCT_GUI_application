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
            this.groupBoxProgrammwahl.SuspendLayout();
            this.groupBoxCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
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
            // OCT_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1258, 664);
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
    }
}

