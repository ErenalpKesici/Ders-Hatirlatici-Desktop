namespace Time
{
    partial class Popup
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLeft = new System.Windows.Forms.Label();
            this.btnMute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.LightSlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Beige;
            this.button1.Location = new System.Drawing.Point(12, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.Column1,
            this.type,
            this.Column3,
            this.Column4});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSalmon;
            this.dataGridView1.Location = new System.Drawing.Point(15, 96);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 42;
            this.dataGridView1.RowTemplate.Height = 350;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(1031, 331);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.date.FillWeight = 200F;
            this.date.HeaderText = "Tarih";
            this.date.MinimumWidth = 300;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 300;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Grup";
            this.Column1.MinimumWidth = 2;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 55;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.type.FillWeight = 50F;
            this.type.HeaderText = "Tip";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 47;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.FillWeight = 200F;
            this.Column3.HeaderText = "Konu";
            this.Column3.MinimumWidth = 300;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Kisi";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.Location = new System.Drawing.Point(447, 9);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(0, 24);
            this.lblLeft.TabIndex = 35;
            // 
            // btnMute
            // 
            this.btnMute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMute.BackColor = System.Drawing.Color.Transparent;
            this.btnMute.FlatAppearance.BorderSize = 0;
            this.btnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMute.Image = global::Time.Properties.Resources.audio2;
            this.btnMute.Location = new System.Drawing.Point(979, 510);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(64, 49);
            this.btnMute.TabIndex = 36;
            this.btnMute.Tag = "Audio";
            this.btnMute.UseVisualStyleBackColor = false;
            this.btnMute.Visible = false;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click_1);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1060, 571);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(742, 317);
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hatirlatici";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hatirlatici_FormClosing);
            this.Load += new System.EventHandler(this.Popup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}