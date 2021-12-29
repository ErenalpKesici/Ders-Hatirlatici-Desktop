using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Font = System.Drawing.Font;

namespace Time
{
    public partial class Popup : Form
    {
        public static Person[] pToSend;
        public static bool mine;
        private readonly int startedAt;
        private bool automated;
        SoundPlayer player;
        public Popup(int startedAt, bool automated)
        {
            this.startedAt = startedAt/60000;
            this.automated = automated;
            InitializeComponent();
        }
        private void UpdateTime(object state)
        {
            if (startedAt < 0)
                SetLblLeftText((60 - DateTime.Now.Minute).ToString() + " dakika once basladi.");
            else
                SetLblLeftText((60 - DateTime.Now.Minute).ToString() + " dakika icinde baslayacak.");
        }
        private void SetLblLeftText(string text)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)SetLblLeftText, text);
                return;
            }
            lblLeft.Text = text;
        }
        private void Popup_Load(object sender, EventArgs e)
        {
            if (automated)
            {
                btnMute.Visible = true;
                player = new SoundPlayer(Directory.GetCurrentDirectory() + "\\assets\\alarm.wav");
                player.PlayLooping();
                var timer = new System.Threading.Timer(UpdateTime, null, 0, 5000);
            }
            else
            {
                btnMute.Visible = false;
                if (startedAt < 0)
                    SetLblLeftText((-1 * startedAt + Form1.minBeforeRemind).ToString() + " dakika once basladi.");
                else
                    SetLblLeftText((startedAt + Form1.minBeforeRemind).ToString() + " dakika icinde baslayacak.");
            }
            int n, rows = 0;
            dataGridView1.Font = new Font("Calibri", 16.0f);
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["date"].DefaultCellStyle.Format = Form1.DATE_FORMAT;
            dataGridView1.AutoSize = true;
            for (int i = 0; Form1.sendListS[i] != null; i++)
            {
                for (int j = 0; j < Form1.sendListS[i].date.Count && Form1.sendListS[i].date[j] != DateTime.MinValue; j++)
                {
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rows].Cells[0].Value = Form1.sendListS[i].date[j];
                    dataGridView1.Rows[rows].Cells[1].Value = Form1.sendListS[i].classroom;
                    dataGridView1.Rows[rows].Cells[2].Value = Form1.sendListS[i].type[j];
                    dataGridView1.Rows[rows].Cells[3].Value = Form1.sendListS[i].topic[j];
                    dataGridView1.Rows[rows++].Cells[4].Value = Form1.sendListS[i].person[j];
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void btnMute_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
        
        private void Sinifs(int index)
        {
            Cursor = Cursors.WaitCursor;
            Excel[] exc = new Excel[Form1.fl];
            string tmp = "";
            Person[] p = new Person[256];
            int k = 0, r = 0;
            string sinif = "";
            bool have = false;
            for (int i = 0; i < exc.Length; i++)
            {
                have = false;
                r = 0;
                exc[i] = new Excel(Form1.sFiles[i], 1);
                for (int inc = 9; (tmp = exc[i].ReadCell(inc, 0).ToString()) != ""; inc++)
                {
                    string info = exc[i].ReadCell(1, 1).ToString();
                    while (!have && r < info.Length)
                    {
                        if (Char.IsLetter(info[r]))
                        {
                            sinif = "";
                            sinif += info[r];
                            while ((r + 1) < info.Length && Char.IsDigit(info[r + 1]))
                            {
                                sinif += info[r + 1];
                                r++;
                                have = true;
                            }
                            if (have)
                            {
                                break;
                            }
                        }
                        r++;
                    }
                    if (sinif == dataGridView1.Rows[index].Cells[1].Value.ToString())
                        p[k++] = new Person(tmp, exc[i].ReadCell(inc, 1).ToString(), sinif);
                }
                exc[i].Quit();
            }
            Cursor = Cursors.Default;
            if (k == 0)
            {
                MessageBox.Show("Ogrenci bulunamadi.");
                return;
            }
            pToSend = p;
            People ppl = new People();
            mine = true;
            ppl.ShowDialog();
        }

        private void lblSinif_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblSinif_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex ==  1)
                Sinifs(e.RowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(automated)
                player.Stop();
            this.Hide();
        }

        private void Hatirlatici_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (automated)
                player.Stop();
            this.Hide();
        }

        private void btnMute_Click_1(object sender, EventArgs e)
        {
            if (automated) 
            {
                if (btnMute.Tag.Equals("Audio"))
                {
                    player.Stop();
                    btnMute.Image = Properties.Resources.mute;
                    btnMute.Tag = "Mute";
                }
                else
                {
                    player.PlayLooping();
                    btnMute.Image = Properties.Resources.audio;
                    btnMute.Tag = "Audio";
                }
            }
        }
    }
    public class Person
    {
        public string name { get; set; }
        public string email { get; set; }
        public string sinif { get; set; }
        public Person(string name, string email, string sinif)
        {
            this.name = name;
            this.email = email;
            this.sinif = sinif;
        }
    }
}
