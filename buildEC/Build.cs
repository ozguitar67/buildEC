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
        public static Worksheet excelWkSht = new Microsoft.Office.Interop.Excel.Worksheet();

        static public void openExcelFile(string fileName)
        {
            //excelApp.Visible = false;
            excelApp.Workbooks.Open(fileName);
            excelWkSht = excelApp.ActiveSheet;
        }

        static public void getService()
        {
            //excelWkSht.Range()
        }
    }
}
