namespace buildEC
{
    partial class PCGForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCGForm));
            this.Message1 = new System.Windows.Forms.Label();
            this.pcgDropDown = new System.Windows.Forms.ComboBox();
            this.Message2 = new System.Windows.Forms.Label();
            this.pcgTextBox = new System.Windows.Forms.TextBox();
            this.pcgSessionsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.okayBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Message1
            // 
            this.Message1.AutoSize = true;
            this.Message1.Location = new System.Drawing.Point(74, 10);
            this.Message1.Name = "Message1";
            this.Message1.Size = new System.Drawing.Size(302, 13);
            this.Message1.TabIndex = 0;
            this.Message1.Text = "Multiple PCG session options found. Please choose one to use";
            // 
            // pcgDropDown
            // 
            this.pcgDropDown.FormattingEnabled = true;
            this.pcgDropDown.Location = new System.Drawing.Point(165, 33);
            this.pcgDropDown.Name = "pcgDropDown";
            this.pcgDropDown.Size = new System.Drawing.Size(121, 21);
            this.pcgDropDown.TabIndex = 1;
            // 
            // Message2
            // 
            this.Message2.AutoSize = true;
            this.Message2.Location = new System.Drawing.Point(118, 64);
            this.Message2.Name = "Message2";
            this.Message2.Size = new System.Drawing.Size(213, 13);
            this.Message2.TabIndex = 2;
            this.Message2.Text = "Or enter a value to use for the PCG Session";
            // 
            // pcgTextBox
            // 
            this.pcgTextBox.Location = new System.Drawing.Point(165, 87);
            this.pcgTextBox.MaxLength = 17;
            this.pcgTextBox.Name = "pcgTextBox";
            this.pcgTextBox.Size = new System.Drawing.Size(121, 20);
            this.pcgTextBox.TabIndex = 3;
            // 
            // okayBtn
            // 
            this.okayBtn.Location = new System.Drawing.Point(187, 117);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(75, 23);
            this.okayBtn.TabIndex = 4;
            this.okayBtn.Text = "Okay";
            this.okayBtn.UseVisualStyleBackColor = true;
            // 
            // PCGForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.okayBtn);
            this.Controls.Add(this.pcgTextBox);
            this.Controls.Add(this.Message2);
            this.Controls.Add(this.pcgDropDown);
            this.Controls.Add(this.Message1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PCGForm";
            this.Text = "PCGForm -";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Message1;
        private System.Windows.Forms.ComboBox pcgDropDown;
        private System.Windows.Forms.Label Message2;
        private System.Windows.Forms.TextBox pcgTextBox;
        private System.Windows.Forms.ToolTip pcgSessionsTooltip;
        private System.Windows.Forms.Button okayBtn;
    }
}