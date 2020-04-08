using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            //ipAddress test = new ipAddress(textBox1.Text.ToString());
            ipAddress test = new ipAddress();
            test.Ip = textBox1.Text.ToString();
            MessageBox.Show(test.Ip);
            */

            
            //Assign all column values to pull cell values
            sourceNameCol = SrcNmCol.Text.ToString();
            sourceIdCol = SrcIdCol.Text.ToString();
            sourceIpCol = SrcIpCol.Text.ToString();
            mcastIpCol = MulticastIpCol.Text.ToString();
            udpPortCol = UdpCol.Text.ToString();
            mpegCol = ProgNumCol.Text.ToString();
            bandwidthCol = BwCol.Text.ToString();
            deviceNameCol = DeviceCol.Text.ToString();
            portCol = PortCol.Text.ToString();
            ecUserName = EcUserName.Text.ToString();
            ecPassword = EcPassword.Text.ToString();

            try
            {
                Build.openExcelFile(textBox1.Text.ToString());

                int blankLines = 0;
                int excelRow = 1;

                while (blankLines < 5)
                {
                    Build.pubSvc = Build.getService(excelRow++);
                    if (!Build.pubSvc.isValidService)
                    {
                        blankLines++;
                        continue;
                    }
                    MessageBox.Show($"{Build.pubSvc.SourceName} {Build.pubSvc.SourceId} {Convert.ToString(Build.pubSvc.SourceIp.Ip)} {Convert.ToString(Build.pubSvc.MulticastIp.Ip)} {Build.pubSvc.UdpPort} {Build.pubSvc.ProgramNumber} {Build.pubSvc.Bandwidth} {Build.pubSvc.Qam.Name} {Build.pubSvc.Qam.Port}");
                }

                Build.initBrowser();
                Build.gotoEC(@"http://10.34.107.194/dncs/console/home.do", ecUserName, ecPassword);
                Thread.Sleep(2500);
            }
            finally
            {
                Build.closeExcelFile();
                Build.driver.Quit();

                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }
            }
        }
    }

}
