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
    public partial class QamSessionForm : Form
    {
        public QamSessionForm(string[] list)
        {
            InitializeComponent();
            this.message1.Text = "Multiple Session ID options exist for " + Build.pubSvc.Qam.Name + ". Please choose one.";
            this.okayBtn.Click += new System.EventHandler(OkayBtn_Click);
            this.sessionDropDownList.Items.AddRange(list);
        }

        public void OkayBtn_Click(object sender, EventArgs e)
        {
            Build.pubSvc.SessionID = this.sessionDropDownList.Text.ToString();
            this.Close();
        }
    }
}
