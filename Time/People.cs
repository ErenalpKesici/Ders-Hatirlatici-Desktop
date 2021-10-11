using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace Time
{
    public partial class People : Form
    {
        public People()
        {
            InitializeComponent();
        }

        private void People_Load(object sender, EventArgs e)
        {
            if (GridSelected.mine && GridSelected.pToSend == null )
            {
                MessageBox.Show("Ogrenci bulunamadi.");
                Close();
                return;
            }
            if (Popup.mine && Popup.pToSend == null)
            {
                MessageBox.Show("Ogrenci bulunamadi.");
                Close();
                return;
            }
            if (GridSelected.mine)
            {
                txtSinif.Text = GridSelected.pToSend[0].sinif + " ogrencileri: ";
                int n;
                dataGridView1.Font = new Font("Calibri", 16.0f);
                dataGridView1.AutoSize = true;
                for (int i = 0; GridSelected.pToSend[i] != null; i++)
                {
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    dataGridView1.Rows[i].Cells[1].Value = GridSelected.pToSend[i].name;
                    dataGridView1.Rows[i].Cells[2].Value = GridSelected.pToSend[i].email;
                }
            }
            else if (Popup.mine)
            {
                txtSinif.Text = Popup.pToSend[0].sinif + " ogrencileri: ";
                int n;
                dataGridView1.Font = new Font("Calibri", 16.0f);
                dataGridView1.AutoSize = true;
                for (int i = 0; Popup.pToSend[i] != null; i++)
                {
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    dataGridView1.Rows[i].Cells[1].Value = Popup.pToSend[i].name;
                    dataGridView1.Rows[i].Cells[2].Value = Popup.pToSend[i].email;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            //    return;

            _Application app = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = app.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;
            app.Visible = true;
            string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            if (sysFormat.ToLower()[0] == 'm')
                worksheet = workbook.Sheets["Sheet1"];
            else
                worksheet = workbook.Sheets["Sayfa1"];
            worksheet = workbook.ActiveSheet;
            if (workbook.Worksheets.Count < 1)
                workbook.Worksheets.Add();
            app.StandardFont = "Calibri";
            app.StandardFontSize = 24;
            if(GridSelected.mine)
                worksheet.Name = GridSelected.pToSend[0].sinif + " ogrencileri ";
            else if(Popup.mine)
                worksheet.Name = Popup.pToSend[0].sinif + " ogrencileri ";
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            Range rng = worksheet.get_Range("A1:C1", Missing.Value);
            rng.Interior.Color = XlRgbColor.rgbLightSteelBlue;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            worksheet.Columns.AutoFit();
            string[] test = Directory.GetDirectories(Form1.location);
            bool skip = false;
            foreach (string item in test)
                if (item == Form1.location + "Ogrenci Listeleri")
                    skip = true;
            if(!skip)
                Directory.CreateDirectory(Form1.location + "\\Ogrenci Listeleri\\");
            workbook.SaveAs(Form1.location+"\\Ogrenci Listeleri\\"+(GridSelected.mine?GridSelected.pToSend[0].sinif:Popup.pToSend[0].sinif)+" Ogrenci Listesi.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            app.Quit();
        }
    }
}
