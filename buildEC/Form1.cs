using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buildEC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Excel Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xls,xlsx",
                Filter = "Excel Files|*.xls;*.xlsx|All files|*.*",
                FilterIndex = 1
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            ipAddress test = new ipAddress(textBox1.Text.ToString());
            MessageBox.Show(test.Ip);
            */

            Build.openExcelFile(textBox1.Text.ToString());
        }
    }

}
