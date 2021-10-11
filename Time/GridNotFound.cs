using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace Time
{
    public partial class GridNotFound : Form
    {
        public GridNotFound()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GridNotFound_Load(object sender, EventArgs e)
        {
            txtDate.Text = Check.start +" - " +Check.end + "\tAraliginda Bulunmayan Dosyalar: ";
            dataGridView1.Font = new Font("Calibri", 16.0f);
            dataGridView1.AutoSize = true;
            int n, row = 0;
            dataGridView1.Columns["date"].DefaultCellStyle.Format = Form1.DATE_FORMAT;
            //string tf = "", real;
            //dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dataGridView1.Columns[2].DefaultCellStyle.Format = "hh";
            for (int i = 0; i < Check.listNotFound.Count; i++)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells[0].Value = Check.listNotFound[i].date;
                dataGridView1.Rows[row++].Cells[1].Value = Check.listNotFound[i].sinif;
            }
           dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            app.StandardFont = "Calibri";
            app.StandardFontSize = 24;
            worksheet.Name = "Bulunmayan Dosyalar";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i].HeaderText;
            }
            Range rng = worksheet.get_Range("A1:B1", Missing.Value);
            rng.Interior.Color = XlRgbColor.rgbLightSteelBlue;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j ] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            worksheet.Columns.AutoFit();
            // save the application  
            workbook.SaveAs("d:\\excel-bulunmayan.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
    }
}
