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
    public partial class HubForm : Form
    {
        public HubForm(string[] list)
        {
            InitializeComponent();
            this.Text = "HubForm - " + Build.pubSvc.ControllerName;
            this.message2.Text = "QAM " + Build.pubSvc.Qam.Name + " " + Build.pubSvc.Qam.Port + " default hub not found.";
            this.okayBtn.Click += new System.EventHandler(OkayBtn_Click);
            this.hubDropDownList.Items.AddRange(list);
        }

        public void OkayBtn_Click(object sender, EventArgs e)
        {
            //Build.pubSvc.DefaultHub = this.hubDropDownList.Text.ToString();
            //this.Close();

            if (String.IsNullOrEmpty(this.hubTextBox.Text.ToString()) || this.hubTextBox.Text.ToString() == "")
            {
                Build.pubSvc.DefaultHub = this.hubDropDownList.Text.ToString();
            }
            else
            {
                Build.pubSvc.DefaultHub = this.hubTextBox.Text.ToString();
            }

            this.Close();
        }
    }
}
