using Microsoft.Office.Interop.Excel;
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
    public partial class FindSum : Form
    {
        private Host[] h = new Host[24];
        private int k = 0;
        public FindSum()
        {
            InitializeComponent();
        }

        private void Find_Load(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; Form1.s[i] != null; i++)
            {
                for (int j = 0; j < Form1.s[i].person.Length; j++)
                {
                    if (Form1.s[i].person[j] == null || Form1.s[i].person[j] == "-")
                        continue;
                    for (int t = 0; h[t] != null; t++)
                    {
                        if (Form1.s[i].person[j] == h[t].name)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        h[k] = new Host();
                        h[k++].name = Form1.s[i].person[j];
                    }
                    else
                        exists = false;
                }
            }
            for (int i = 0; h[i] != null; i++)
                comboBox1.Items.Add(h[i].name);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Lutfen kisi secin.");
                return;
            }
            for (int i = 0; i < k; i++)
                h[i].frequency = 0;
            if (!cbAfterDate.Checked)
            {
                for (int i = 0; Form1.s[i] != null; i++)
                {
                    for (int j = 0; j < Form1.s[i].person.Length && Form1.s[i] != null; j++)
                    {
                        if (Form1.s[i].person[j] == null)
                            continue;
                        for (int t = 0; h[t] != null; t++)
                        {
                            if (h[t].name == Form1.s[i].person[j])
                            {
                                h[t].frequency++;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; Form1.s[i] != null; i++)
                {
                    if (Form1.s[i].date[0].Date.CompareTo(dtpAfter.Value.Date) > -1)
                        for (int j = 0; j < Form1.s[i].person.Length && Form1.s[i] != null; j++)
                        {
                            for (int t = 0; h[t] != null; t++)
                            {
                                if (h[t].name == Form1.s[i].person[j])
                                {
                                    h[t].frequency++;
                                }
                            }
                        }
                }
            }
            MessageBox.Show(comboBox1.SelectedItem + " kisinin ders sayisi: " + h[comboBox1.SelectedIndex].frequency);
        }
        public class Host
        {
            public string name { get; set; }
            public int frequency { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if(cbAfterDate.Checked)
                dtpAfter.Font = new System.Drawing.Font(dtpAfter.Font, dtpAfter.Font.Style | FontStyle.Bold);
           else
                dtpAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.0f);
        }
    }
}
