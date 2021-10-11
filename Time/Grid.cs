using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time
{
    public partial class Grid : Form
    {
        public Grid()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_Load(object sender, EventArgs e)
        {
            int n = 0;
            dataGridView1.AutoSize = true;
            dataGridView1.Font = new Font("Calibri", 16.0f);
            for (int i = 0;Form1.s[i] != null; i++)
            {
                n = dataGridView1.Rows.Add();
                
                //for (int j = 0;Form1.s[i].hours[j] != 0; j++)
                //{
                //    dataGridView1.Rows[i].Cells[0].Value = Form1.s[i].date;
                //    dataGridView1.Rows[i].Cells[1].Value = Form1.s[i].sinif;
                //    dataGridView1.Rows[i].Cells[2].Value = 24*Form1.s[i].hours[j];
                //    dataGridView1.Rows[i].Cells[3].Value = Form1.s[i].topic[j];
                //    dataGridView1.Rows[i].Cells[4].Value = Form1.s[i].person[j];
                //}
            }
        }

        private void Grid_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
