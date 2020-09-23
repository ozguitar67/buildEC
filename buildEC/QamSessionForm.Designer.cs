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
            this.sessionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // message1
            // 
            this.message1.AutoSize = true;
            this.message1.Location = new System.Drawing.Point(56, 13);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(264, 13);
            this.message1.TabIndex = 0;
            this.message1.Text = "Session ID issue for QAM_NAME. Please choose one.";
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
            this.okayBtn.Location = new System.Drawing.Point(189, 118);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(75, 23);
            this.okayBtn.TabIndex = 2;
            this.okayBtn.Text = "Okay";
            this.okayBtn.UseVisualStyleBackColor = true;
            // 
            // sessionTextBox
            // 
            this.sessionTextBox.Location = new System.Drawing.Point(152, 92);
            this.sessionTextBox.MaxLength = 17;
            this.sessionTextBox.Name = "sessionTextBox";
            this.sessionTextBox.Size = new System.Drawing.Size(145, 20);
            this.sessionTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Or enter a value";
            // 
            // QamSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 167);
            this.Controls.Add(this.sessionTextBox);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.TextBox sessionTextBox;
        private System.Windows.Forms.Label label1;
    }
}