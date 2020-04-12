using System.Collections.Generic;

namespace buildEC
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EcListDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EcListDropDown
            // 
            // ***** To make changes in the form designer, remove this extra code and add it back *****
            IList<string> keys = Build.ECLIST.Keys;
            int arraySize = Build.ECLIST.Count;
            string[] ecList = new string[arraySize];
            int idx = 0;
            foreach (string s in keys)
            {
                ecList[idx] = s;
                idx++;
            }

            this.EcListDropDown.AllowDrop = true;
            this.EcListDropDown.FormattingEnabled = true;
            this.EcListDropDown.Location = new System.Drawing.Point(41, 49);
            this.EcListDropDown.Name = "EcListDropDown";
            this.EcListDropDown.Size = new System.Drawing.Size(147, 21);
            this.EcListDropDown.TabIndex = 0;
            this.EcListDropDown.Items.AddRange(ecList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cannot find " + Build.pubSvc.ControllerName + " in the list of ECs. Please choose one from the list below.";
            // ***** To here *****
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 96);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EcListDropDown);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EcListDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}