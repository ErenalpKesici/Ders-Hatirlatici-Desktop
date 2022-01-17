namespace Time
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.rbNow = new System.Windows.Forms.RadioButton();
            this.rbClosest = new System.Windows.Forms.RadioButton();
            this.dtpHour = new System.Windows.Forms.DateTimePicker();
            this.btnList = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programKlasorunuAcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secilenKlasorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblStart = new System.Windows.Forms.Label();
            this.btnSum = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkInterval = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxPerson = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BUL = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.ntiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbxRemind = new System.Windows.Forms.ComboBox();
            this.cbRemind = new System.Windows.Forms.CheckBox();
            this.lblRemind = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(44, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 13);
            this.lblDate.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.CalendarForeColor = System.Drawing.SystemColors.Control;
            this.dtpStart.CalendarMonthBackground = System.Drawing.SystemColors.MenuBar;
            this.dtpStart.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonFace;
            this.dtpStart.CalendarTrailingForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.dtpStart.CustomFormat = "MMMM dd, yyyy  |  hh:00";
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(130, 60);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(299, 26);
            this.dtpStart.TabIndex = 3;
            this.dtpStart.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // rbNow
            // 
            this.rbNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbNow.AutoSize = true;
            this.rbNow.BackColor = System.Drawing.Color.Transparent;
            this.rbNow.Checked = true;
            this.rbNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNow.Location = new System.Drawing.Point(161, 45);
            this.rbNow.Name = "rbNow";
            this.rbNow.Size = new System.Drawing.Size(99, 29);
            this.rbNow.TabIndex = 6;
            this.rbNow.TabStop = true;
            this.rbNow.Text = "Şimdiki";
            this.rbNow.UseVisualStyleBackColor = false;
            this.rbNow.CheckedChanged += new System.EventHandler(this.rbNow_CheckedChanged);
            // 
            // rbClosest
            // 
            this.rbClosest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbClosest.AutoSize = true;
            this.rbClosest.BackColor = System.Drawing.Color.Transparent;
            this.rbClosest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClosest.Location = new System.Drawing.Point(161, 100);
            this.rbClosest.Name = "rbClosest";
            this.rbClosest.Size = new System.Drawing.Size(157, 29);
            this.rbClosest.TabIndex = 7;
            this.rbClosest.Text = "En Yakındaki";
            this.rbClosest.UseVisualStyleBackColor = false;
            this.rbClosest.CheckedChanged += new System.EventHandler(this.rbClosest_CheckedChanged);
            // 
            // dtpHour
            // 
            this.dtpHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpHour.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHour.Location = new System.Drawing.Point(-291, 53);
            this.dtpHour.Name = "dtpHour";
            this.dtpHour.ShowUpDown = true;
            this.dtpHour.Size = new System.Drawing.Size(113, 22);
            this.dtpHour.TabIndex = 9;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.BackColor = System.Drawing.Color.Ivory;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnList.Image = ((System.Drawing.Image)(resources.GetObject("btnList.Image")));
            this.btnList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnList.Location = new System.Drawing.Point(451, 41);
            this.btnList.Name = "btnList";
            this.btnList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnList.Size = new System.Drawing.Size(347, 133);
            this.btnList.TabIndex = 10;
            this.btnList.Text = "Tarihdeki Dersleri Listele";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.listAtDate);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SeaShell;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programKlasorunuAcToolStripMenuItem,
            this.secilenKlasorToolStripMenuItem,
            this.cikisToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.dosyaToolStripMenuItem.Text = "Özellikler";
            // 
            // programKlasorunuAcToolStripMenuItem
            // 
            this.programKlasorunuAcToolStripMenuItem.Name = "programKlasorunuAcToolStripMenuItem";
            this.programKlasorunuAcToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.programKlasorunuAcToolStripMenuItem.Text = "Program Klasorunu Ac";
            this.programKlasorunuAcToolStripMenuItem.Click += new System.EventHandler(this.programKlasorunuAcToolStripMenuItem_Click);
            // 
            // secilenKlasorToolStripMenuItem
            // 
            this.secilenKlasorToolStripMenuItem.Name = "secilenKlasorToolStripMenuItem";
            this.secilenKlasorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.secilenKlasorToolStripMenuItem.Text = "Excel Klasorunu Ac";
            this.secilenKlasorToolStripMenuItem.Click += new System.EventHandler(this.secilenKlasorToolStripMenuItem_Click);
            // 
            // cikisToolStripMenuItem
            // 
            this.cikisToolStripMenuItem.Name = "cikisToolStripMenuItem";
            this.cikisToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cikisToolStripMenuItem.Text = "Kapat";
            this.cikisToolStripMenuItem.Click += new System.EventHandler(this.cikisToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(28, 62);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(91, 24);
            this.lblStart.TabIndex = 12;
            this.lblStart.Text = "Başlangıç";
            this.lblStart.Visible = false;
            // 
            // btnSum
            // 
            this.btnSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSum.BackColor = System.Drawing.Color.Turquoise;
            this.btnSum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSum.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSum.Location = new System.Drawing.Point(12, 359);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(431, 66);
            this.btnSum.TabIndex = 13;
            this.btnSum.Text = "Toplam Ders Sayısı Hesaplama";
            this.btnSum.UseVisualStyleBackColor = false;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.CalendarForeColor = System.Drawing.SystemColors.Control;
            this.dtpEnd.CalendarMonthBackground = System.Drawing.SystemColors.MenuBar;
            this.dtpEnd.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonFace;
            this.dtpEnd.CalendarTrailingForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(130, 126);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(299, 26);
            this.dtpEnd.TabIndex = 14;
            this.dtpEnd.Visible = false;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // chkInterval
            // 
            this.chkInterval.AutoSize = true;
            this.chkInterval.BackColor = System.Drawing.Color.Transparent;
            this.chkInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInterval.Location = new System.Drawing.Point(12, 124);
            this.chkInterval.Name = "chkInterval";
            this.chkInterval.Size = new System.Drawing.Size(113, 28);
            this.chkInterval.TabIndex = 15;
            this.chkInterval.Text = "Aralık Seç";
            this.chkInterval.UseVisualStyleBackColor = false;
            this.chkInterval.CheckedChanged += new System.EventHandler(this.chkInterval_CheckedChanged);
            // 
            // cbxPerson
            // 
            this.cbxPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPerson.FormattingEnabled = true;
            this.cbxPerson.Items.AddRange(new object[] {
            "Herkes"});
            this.cbxPerson.Location = new System.Drawing.Point(554, 0);
            this.cbxPerson.Name = "cbxPerson";
            this.cbxPerson.Size = new System.Drawing.Size(244, 24);
            this.cbxPerson.TabIndex = 18;
            this.cbxPerson.SelectedIndexChanged += new System.EventHandler(this.ddPerson_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Location = new System.Drawing.Point(0, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 21);
            this.panel1.TabIndex = 19;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(9, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Snow;
            this.panel2.Controls.Add(this.dtpHour);
            this.panel2.Controls.Add(this.BUL);
            this.panel2.Controls.Add(this.rbClosest);
            this.panel2.Controls.Add(this.rbNow);
            this.panel2.Location = new System.Drawing.Point(0, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 173);
            this.panel2.TabIndex = 20;
            // 
            // BUL
            // 
            this.BUL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BUL.BackColor = System.Drawing.Color.Ivory;
            this.BUL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUL.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BUL.Image = ((System.Drawing.Image)(resources.GetObject("BUL.Image")));
            this.BUL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BUL.Location = new System.Drawing.Point(507, 18);
            this.BUL.Name = "BUL";
            this.BUL.Size = new System.Drawing.Size(291, 135);
            this.BUL.TabIndex = 0;
            this.BUL.Text = "Dersi Bul";
            this.BUL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BUL.UseVisualStyleBackColor = false;
            this.BUL.Click += new System.EventHandler(this.findNow);
            // 
            // btnVideo
            // 
            this.btnVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVideo.BackColor = System.Drawing.Color.Turquoise;
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVideo.Location = new System.Drawing.Point(451, 359);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(351, 66);
            this.btnVideo.TabIndex = 21;
            this.btnVideo.Text = "Ders Video Kontrol";
            this.btnVideo.UseVisualStyleBackColor = false;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // ntiTray
            // 
            this.ntiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiTray.Icon")));
            this.ntiTray.Text = "Ders Hatirlatici";
            this.ntiTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntiTray_MouseClick);
            // 
            // cbxRemind
            // 
            this.cbxRemind.BackColor = System.Drawing.SystemColors.Window;
            this.cbxRemind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRemind.FormattingEnabled = true;
            this.cbxRemind.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "30",
            "40",
            "45",
            "50",
            "60"});
            this.cbxRemind.Location = new System.Drawing.Point(246, 0);
            this.cbxRemind.Name = "cbxRemind";
            this.cbxRemind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxRemind.Size = new System.Drawing.Size(38, 24);
            this.cbxRemind.TabIndex = 24;
            this.cbxRemind.Text = "10";
            this.cbxRemind.Visible = false;
            this.cbxRemind.SelectedIndexChanged += new System.EventHandler(this.cbxRemind_SelectedIndexChanged);
            // 
            // cbRemind
            // 
            this.cbRemind.AutoSize = true;
            this.cbRemind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbRemind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRemind.Location = new System.Drawing.Point(413, 0);
            this.cbRemind.Name = "cbRemind";
            this.cbRemind.Size = new System.Drawing.Size(85, 28);
            this.cbRemind.TabIndex = 25;
            this.cbRemind.Text = "Hatirlat";
            this.cbRemind.UseVisualStyleBackColor = true;
            this.cbRemind.CheckedChanged += new System.EventHandler(this.cbRemind_CheckedChanged);
            // 
            // lblRemind
            // 
            this.lblRemind.AutoSize = true;
            this.lblRemind.BackColor = System.Drawing.Color.Transparent;
            this.lblRemind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemind.Location = new System.Drawing.Point(290, 0);
            this.lblRemind.Name = "lblRemind";
            this.lblRemind.Size = new System.Drawing.Size(126, 24);
            this.lblRemind.TabIndex = 26;
            this.lblRemind.Text = "dakika kalinca";
            this.lblRemind.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(810, 451);
            this.Controls.Add(this.lblRemind);
            this.Controls.Add(this.cbRemind);
            this.Controls.Add(this.cbxRemind);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxPerson);
            this.Controls.Add(this.chkInterval);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.btnSum);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(500, 256);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders Hatırlatıcı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BUL;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.RadioButton rbNow;
        private System.Windows.Forms.RadioButton rbClosest;
        private System.Windows.Forms.DateTimePicker dtpHour;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox chkInterval;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem secilenKlasorToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxPerson;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.NotifyIcon ntiTray;
        private System.Windows.Forms.ComboBox cbxRemind;
        private System.Windows.Forms.CheckBox cbRemind;
        private System.Windows.Forms.Label lblRemind;
        private System.Windows.Forms.ToolStripMenuItem programKlasorunuAcToolStripMenuItem;
    }
}

