using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;
namespace Time
{
    class Excel
    {
        public string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }
        public string ReadCell(int i, int j)
        {
            if(ws.Cells[++i, ++j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString();
            return "";
        }
        public void Quit()
        {
            excel.Quit();
        }
    }
}
