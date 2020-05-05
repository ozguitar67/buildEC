namespace buildEC
{
    partial class QamSessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QamSessionForm));
            this.message1 = new System.Windows.Forms.Label();
            this.sessionDropDownList = new System.Windows.Forms.ComboBox();
            this.okayBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message1
            // 
            this.message1.AutoSize = true;
            this.message1.Location = new System.Drawing.Point(56, 13);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(337, 13);
            this.message1.TabIndex = 0;
            this.message1.Text = "Multiple Session ID options exist for QAM_NAME. Please choose one.";
            this.message1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sessionDropDownList
            // 
            this.sessionDropDownList.FormattingEnabled = true;
            this.sessionDropDownList.Location = new System.Drawing.Point(152, 36);
            this.sessionDropDownList.Name = "sessionDropDownList";
            this.sessionDropDownList.Size = new System.Drawing.Size(145, 21);
            this.sessionDropDownList.TabIndex = 1;
            // 
            // okayBtn
            // 
            this.okayBtn.Location = new System.Drawing.Point(187, 67);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(75, 23);
            this.okayBtn.TabIndex = 2;
            this.okayBtn.Text = "Okay";
            this.okayBtn.UseVisualStyleBackColor = true;
            // 
            // QamSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 101);
            this.Controls.Add(this.okayBtn);
            this.Controls.Add(this.sessionDropDownList);
            this.Controls.Add(this.message1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QamSessionForm";
            this.Text = "QamSessionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message1;
        private System.Windows.Forms.ComboBox sessionDropDownList;
        private System.Windows.Forms.Button okayBtn;
    }
}