namespace Time
{
    partial class Check
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
            this.btnNoMatch = new System.Windows.Forms.Button();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.ddPerson = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkFix = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.txtDelete = new System.Windows.Forms.TextBox();
            this.chkInnerDelete = new System.Windows.Forms.CheckBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNoMatch
            // 
            this.btnNoMatch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNoMatch.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNoMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoMatch.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoMatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNoMatch.Location = new System.Drawing.Point(46, 113);
            this.btnNoMatch.Name = "btnNoMatch";
            this.btnNoMatch.Size = new System.Drawing.Size(748, 100);
            this.btnNoMatch.TabIndex = 24;
            this.btnNoMatch.Text = "Eslesmeyenleri Bul";
            this.btnNoMatch.UseVisualStyleBackColor = false;
            this.btnNoMatch.Click += new System.EventHandler(this.btnNoMatch_Click);
            // 
            // dtStart
            // 
            this.dtStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.Location = new System.Drawing.Point(114, 12);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(299, 29);
            this.dtStart.TabIndex = 25;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.Location = new System.Drawing.Point(485, 12);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(309, 29);
            this.dtEnd.TabIndex = 26;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // ddPerson
            // 
            this.ddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddPerson.FormattingEnabled = true;
            this.ddPerson.Location = new System.Drawing.Point(117, 65);
            this.ddPerson.Name = "ddPerson";
            this.ddPerson.Size = new System.Drawing.Size(565, 32);
            this.ddPerson.TabIndex = 27;
            this.ddPerson.SelectedIndexChanged += new System.EventHandler(this.ddPerson_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Beige;
            this.btnBack.Location = new System.Drawing.Point(12, 295);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 34);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Geri";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.Honeydew;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnApply.Location = new System.Drawing.Point(571, 229);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(239, 100);
            this.btnApply.TabIndex = 29;
            this.btnApply.Text = "Uygula";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkFix
            // 
            this.chkFix.AutoSize = true;
            this.chkFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFix.Location = new System.Drawing.Point(117, 301);
            this.chkFix.Name = "chkFix";
            this.chkFix.Size = new System.Drawing.Size(181, 28);
            this.chkFix.TabIndex = 30;
            this.chkFix.Text = "Klasorleri Duzenle";
            this.chkFix.UseVisualStyleBackColor = true;
            this.chkFix.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelete.Location = new System.Drawing.Point(117, 234);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(326, 28);
            this.chkDelete.TabIndex = 31;
            this.chkDelete.Text = "Girilenden Kucuk Klasorleri Sil (MB)";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // txtDelete
            // 
            this.txtDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelete.Location = new System.Drawing.Point(449, 234);
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.Size = new System.Drawing.Size(100, 29);
            this.txtDelete.TabIndex = 32;
            this.txtDelete.Text = "2.5";
            this.txtDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkInnerDelete
            // 
            this.chkInnerDelete.AutoSize = true;
            this.chkInnerDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInnerDelete.Location = new System.Drawing.Point(117, 268);
            this.chkInnerDelete.Name = "chkInnerDelete";
            this.chkInnerDelete.Size = new System.Drawing.Size(269, 28);
            this.chkInnerDelete.TabIndex = 33;
            this.chkInnerDelete.Text = "Girilen Disindaki Dosyalari Sil";
            this.chkInnerDelete.UseVisualStyleBackColor = true;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(12, 12);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(96, 24);
            this.lblStart.TabIndex = 34;
            this.lblStart.Text = "Baslangic:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "Bitis:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(449, 269);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 36;
            this.textBox1.Text = "mp4";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(822, 341);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.chkInnerDelete);
            this.Controls.Add(this.txtDelete);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.chkFix);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.ddPerson);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.btnNoMatch);
            this.Name = "Check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Kontrol";
            this.Load += new System.EventHandler(this.Check_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNoMatch;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.ComboBox ddPerson;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkFix;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.TextBox txtDelete;
        private System.Windows.Forms.CheckBox chkInnerDelete;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}