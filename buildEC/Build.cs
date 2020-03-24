using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace buildEC
{
    static class Build
    {
        public static Application excelApp = new Microsoft.Office.Interop.Excel.Application();

        static public void openExcelFile(string fileName)
        {
            //excelApp.Visible = false;
            excelApp.Workbooks.Open(fileName);
            Worksheet worksheet = excelApp.ActiveSheet;
        }
    }
}
