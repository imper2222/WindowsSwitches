namespace WindowsSwitches
{
    partial class FmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.nudLeftTime = new System.Windows.Forms.NumericUpDown();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbZadanie = new System.Windows.Forms.ComboBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Godzina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Czas (minuty)";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(234, 42);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(54, 20);
            this.dtpTime.TabIndex = 7;
            this.dtpTime.ValueChanged += new System.EventHandler(this.dtpTime_ValueChanged);
            // 
            // nudLeftTime
            // 
            this.nudLeftTime.Location = new System.Drawing.Point(234, 68);
            this.nudLeftTime.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.nudLeftTime.Name = "nudLeftTime";
            this.nudLeftTime.Size = new System.Drawing.Size(54, 20);
            this.nudLeftTime.TabIndex = 11;
            this.nudLeftTime.ValueChanged += new System.EventHandler(this.nudLeftTime_ValueChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // cbZadanie
            // 
            this.cbZadanie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZadanie.FormattingEnabled = true;
            this.cbZadanie.Items.AddRange(new object[] {
            "zamknij",
            "uruchom ponownie",
            "wyloguj",
            "uśpij"});
            this.cbZadanie.Location = new System.Drawing.Point(12, 12);
            this.cbZadanie.Name = "cbZadanie";
            this.cbZadanie.Size = new System.Drawing.Size(157, 21);
            this.cbZadanie.TabIndex = 12;
            // 
            // btStart
            // 
            this.btStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btStart.BackgroundImage")));
            this.btStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btStart.Location = new System.Drawing.Point(12, 42);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(50, 50);
            this.btStart.TabIndex = 15;
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btStop.BackgroundImage")));
            this.btStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btStop.Location = new System.Drawing.Point(68, 42);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(50, 50);
            this.btStop.TabIndex = 16;
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 108);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.cbZadanie);
            this.Controls.Add(this.nudLeftTime);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FmMain";
            this.Text = "WindowsSwitches";
            this.Resize += new System.EventHandler(this.FmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        internal System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.NumericUpDown nudLeftTime;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox cbZadanie;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
    }
}

