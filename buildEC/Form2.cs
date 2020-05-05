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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.label1.Text = "Cannot find " + Build.pubSvc.ControllerName + " in the list of ECs. Please choose one from the list below.";
            // 
            // EcListDropDown population
            // 
            IList<string> keys = Build.ECLIST.Keys;
            int arraySize = Build.ECLIST.Count;
            string[] ecList = new string[arraySize];
            int idx = 0;
            foreach (string s in keys)
            {
                ecList[idx] = s;
                idx++;
            }

            this.EcListDropDown.Items.AddRange(ecList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Build.pubSvc.ControllerName = EcListDropDown.Text.ToString();
            this.Close();
        }
    }
}
