using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time
{
    public partial class GridSelected : Form
    {
        public static Person[] pToSend;
        public static bool mine;
        public GridSelected()
        {
            InitializeComponent();
        }
        private void GridSelected_Load(object sender, EventArgs e)
        {
            int n, row = 0;
            string[] tmp = new string[5];
            txtDate.Text = Form1.start + "  -  " + Form1.end;
            dataGridView1.Font = new Font("Calibri", 16.0f);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["date"].DefaultCellStyle.Format = Form1.DATE_FORMAT;
            dataGridView1.AutoSize = true;
            for (int i = 0; i < Form1.k; i++)
            {
                for (int j = 0; j < Form1.sendListS[i].date.Length && Form1.sendListS[i].date[j] != DateTime.MinValue; j++)
                {
                    n = dataGridView1.Rows.Add();
                    if (Form1.sendListS[i].type[j] == "ÖE")
                        dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Aqua;
                    dataGridView1.Rows[row].Cells[0].Value = Form1.sendListS[i].date[j];
                    dataGridView1.Rows[row].Cells[1].Value = Form1.sendListS[i].classroom;
                    dataGridView1.Rows[row].Cells[2].Value = Form1.sendListS[i].type[j];
                    dataGridView1.Rows[row].Cells[3].Value = Form1.sendListS[i].topic[j];
                    dataGridView1.Rows[row++].Cells[4].Value = Form1.sendListS[i].person[j];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                    if (Form1.interval && sinif == dataGridView1.Rows[index].Cells[3].Value.ToString())
                        p[k++] = new Person(tmp, exc[i].ReadCell(inc, 1).ToString(), sinif);
                    else if (!Form1.interval && sinif == dataGridView1.Rows[index].Cells[0].Value.ToString())
                        p[k++] = new Person(tmp, exc[i].ReadCell(inc, 0).ToString(), sinif);
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
            mine = true;
            People ppl = new People();
            ppl.ShowDialog();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && Form1.interval && e.ColumnIndex == 3)
                Sinifs(e.RowIndex);
            else if (e.RowIndex > -1 && !Form1.interval && e.ColumnIndex == 2)
                Sinifs(e.RowIndex);
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && Form1.interval && e.ColumnIndex == 3)
                Cursor = Cursors.Hand;
            else if (e.RowIndex > -1 && !Form1.interval && e.ColumnIndex == 2)
                Cursor = Cursors.Hand;
        }
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.Default;
        }

    }
}
