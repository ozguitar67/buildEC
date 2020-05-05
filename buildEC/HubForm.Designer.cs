namespace buildEC
{
    partial class HubForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HubForm));
            this.message1 = new System.Windows.Forms.Label();
            this.hubDropDownList = new System.Windows.Forms.ComboBox();
            this.okayBtn = new System.Windows.Forms.Button();
            this.message2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // message1
            // 
            this.message1.AutoSize = true;
            this.message1.Location = new System.Drawing.Point(37, 37);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(385, 13);
            this.message1.TabIndex = 0;
            this.message1.Text = "Default hub not found. Please choose a hub on the controller from the below list." +
    "";
            // 
            // hubDropDownList
            // 
            this.hubDropDownList.FormattingEnabled = true;
            this.hubDropDownList.Location = new System.Drawing.Point(125, 66);
            this.hubDropDownList.Name = "hubDropDownList";
            this.hubDropDownList.Size = new System.Drawing.Size(200, 21);
            this.hubDropDownList.TabIndex = 1;
            // 
            // okayBtn
            // 
            this.okayBtn.Location = new System.Drawing.Point(187, 97);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(75, 23);
            this.okayBtn.TabIndex = 2;
            this.okayBtn.Text = "Okay";
            this.okayBtn.UseVisualStyleBackColor = true;
            // 
            // message2
            // 
            this.message2.AutoSize = true;
            this.message2.Location = new System.Drawing.Point(83, 13);
            this.message2.Name = "message2";
            this.message2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.message2.Size = new System.Drawing.Size(284, 13);
            this.message2.TabIndex = 3;
            this.message2.Text = "QAM NSG_Name RF Carrier  XX/XX default hub not found";
            this.message2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 136);
            this.Controls.Add(this.message2);
            this.Controls.Add(this.okayBtn);
            this.Controls.Add(this.hubDropDownList);
            this.Controls.Add(this.message1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HubForm";
            this.Text = "HubForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message1;
        private System.Windows.Forms.ComboBox hubDropDownList;
        private System.Windows.Forms.Button okayBtn;
        private System.Windows.Forms.Label message2;
    }
}