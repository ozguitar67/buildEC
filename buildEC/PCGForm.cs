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
    public partial class PCGForm : Form
    {
        public PCGForm(string[] list)
        {
            InitializeComponent();
            this.Text = "PCGForm - " + Build.pubSvc.Qam.Name + ": " + Build.pubSvc.Qam.Port;
            this.pcgSessionsTooltip.Active = true;
            this.pcgSessionsTooltip.IsBalloon = false;
            this.pcgSessionsTooltip.ShowAlways = true;
            this.pcgSessionsTooltip.AutomaticDelay = 50;
            this.pcgSessionsTooltip.AutoPopDelay = 10000;
            this.pcgSessionsTooltip.SetToolTip(this.pcgTextBox, "Only the PCG server pair portion of the session needs to be present. For example, 00:F1:00:00:00:00");
            this.pcgDropDown.Items.AddRange(list);
            this.okayBtn.Click += new System.EventHandler(OkayBtn_Click);
        }

        public void OkayBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.pcgTextBox.Text.ToString()) || this.pcgTextBox.Text.Length < 17)
            {
                Build.pubSvc.PCGsession = this.pcgDropDown.Text.ToString();
            }
            else
            {
                Build.pubSvc.PCGsession = this.pcgTextBox.Text.ToString();
            }

            this.Close();
        }

    }
}
