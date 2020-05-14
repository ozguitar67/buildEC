namespace buildEC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        static public string sourceNameCol;
        static public string sourceIdCol;
        static public string sourceIpCol;
        static public string mcastIpCol;
        static public string udpPortCol;
        static public string bandwidthCol;
        static public string deviceNameCol;
        static public string portCol;
        static public string mpegCol;
        static public string controllerCol;
        static public string ecUserName;
        static public string ecPassword;
        static public string frequencyCol;
        static public string dtaServiceCol;

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
            Build.getJSON();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SourceNameLbl = new System.Windows.Forms.Label();
            this.SrcNmCol = new System.Windows.Forms.TextBox();
            this.SourceIdLbl = new System.Windows.Forms.Label();
            this.SrcIdCol = new System.Windows.Forms.TextBox();
            this.SourceIpLbl = new System.Windows.Forms.Label();
            this.SrcIpCol = new System.Windows.Forms.TextBox();
            this.mCastIpLbl = new System.Windows.Forms.Label();
            this.MulticastIpCol = new System.Windows.Forms.TextBox();
            this.UdpLbl = new System.Windows.Forms.Label();
            this.UdpCol = new System.Windows.Forms.TextBox();
            this.BwLbl = new System.Windows.Forms.Label();
            this.BwCol = new System.Windows.Forms.TextBox();
            this.QamNameLbl = new System.Windows.Forms.Label();
            this.DeviceCol = new System.Windows.Forms.TextBox();
            this.PortLbl = new System.Windows.Forms.Label();
            this.PortCol = new System.Windows.Forms.TextBox();
            this.ProgNumLbl = new System.Windows.Forms.Label();
            this.ProgNumCol = new System.Windows.Forms.TextBox();
            this.ControllerLbl = new System.Windows.Forms.Label();
            this.ControllerCol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ecUserNameLbl = new System.Windows.Forms.Label();
            this.ecPasswordLbl = new System.Windows.Forms.Label();
            this.EcUserName = new System.Windows.Forms.TextBox();
            this.EcPassword = new System.Windows.Forms.TextBox();
            this.FrequencyLbl = new System.Windows.Forms.Label();
            this.FrequencyCol = new System.Windows.Forms.TextBox();
            this.DTAserviceLbl = new System.Windows.Forms.Label();
            this.DTAservCol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = @"C:\OneDrive - Comcast\SMOPs\2020\05-19_NCB LX Launch_NEDVSD-60111\Freedom Cisco Build.xlsx";
            this.openFileDialog1.Filter = "\"Excel files|*.xls,*.xlsx|All files|*.*\"";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(502, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = this.openFileDialog1.FileName;
            this.textBox1.WordWrap = false;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(520, 19);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(112, 20);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(238, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 52);
            this.button1.TabIndex = 30;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SourceNameLbl
            // 
            this.SourceNameLbl.AutoSize = true;
            this.SourceNameLbl.Location = new System.Drawing.Point(13, 81);
            this.SourceNameLbl.Name = "SourceNameLbl";
            this.SourceNameLbl.Size = new System.Drawing.Size(72, 13);
            this.SourceNameLbl.TabIndex = 2;
            this.SourceNameLbl.Text = "Source Name";
            // 
            // SrcNmCol
            // 
            this.SrcNmCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SrcNmCol.Location = new System.Drawing.Point(92, 78);
            this.SrcNmCol.MaxLength = 2;
            this.SrcNmCol.Name = "SrcNmCol";
            this.SrcNmCol.Size = new System.Drawing.Size(24, 20);
            this.SrcNmCol.TabIndex = 3;
            this.SrcNmCol.WordWrap = false;
            // 
            // SourceIdLbl
            // 
            this.SourceIdLbl.AutoSize = true;
            this.SourceIdLbl.Location = new System.Drawing.Point(122, 81);
            this.SourceIdLbl.Name = "SourceIdLbl";
            this.SourceIdLbl.Size = new System.Drawing.Size(55, 13);
            this.SourceIdLbl.TabIndex = 4;
            this.SourceIdLbl.Text = "Source ID";
            // 
            // SrcIdCol
            // 
            this.SrcIdCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SrcIdCol.Location = new System.Drawing.Point(183, 78);
            this.SrcIdCol.MaxLength = 2;
            this.SrcIdCol.Name = "SrcIdCol";
            this.SrcIdCol.Size = new System.Drawing.Size(24, 20);
            this.SrcIdCol.TabIndex = 5;
            this.SrcIdCol.WordWrap = false;
            // 
            // SourceIpLbl
            // 
            this.SourceIpLbl.AutoSize = true;
            this.SourceIpLbl.Location = new System.Drawing.Point(213, 81);
            this.SourceIpLbl.Name = "SourceIpLbl";
            this.SourceIpLbl.Size = new System.Drawing.Size(54, 13);
            this.SourceIpLbl.TabIndex = 6;
            this.SourceIpLbl.Text = "Source IP";
            // 
            // SrcIpCol
            // 
            this.SrcIpCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SrcIpCol.Location = new System.Drawing.Point(273, 78);
            this.SrcIpCol.MaxLength = 2;
            this.SrcIpCol.Name = "SrcIpCol";
            this.SrcIpCol.Size = new System.Drawing.Size(24, 20);
            this.SrcIpCol.TabIndex = 7;
            this.SrcIpCol.WordWrap = false;
            // 
            // mCastIpLbl
            // 
            this.mCastIpLbl.AutoSize = true;
            this.mCastIpLbl.Location = new System.Drawing.Point(303, 81);
            this.mCastIpLbl.Name = "mCastIpLbl";
            this.mCastIpLbl.Size = new System.Drawing.Size(62, 13);
            this.mCastIpLbl.TabIndex = 8;
            this.mCastIpLbl.Text = "Multicast IP";
            // 
            // MulticastIpCol
            // 
            this.MulticastIpCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MulticastIpCol.Location = new System.Drawing.Point(371, 78);
            this.MulticastIpCol.MaxLength = 2;
            this.MulticastIpCol.Name = "MulticastIpCol";
            this.MulticastIpCol.Size = new System.Drawing.Size(24, 20);
            this.MulticastIpCol.TabIndex = 9;
            this.MulticastIpCol.WordWrap = false;
            // 
            // UdpLbl
            // 
            this.UdpLbl.AutoSize = true;
            this.UdpLbl.Location = new System.Drawing.Point(401, 81);
            this.UdpLbl.Name = "UdpLbl";
            this.UdpLbl.Size = new System.Drawing.Size(52, 13);
            this.UdpLbl.TabIndex = 10;
            this.UdpLbl.Text = "UDP Port";
            // 
            // UdpCol
            // 
            this.UdpCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UdpCol.Location = new System.Drawing.Point(459, 78);
            this.UdpCol.MaxLength = 2;
            this.UdpCol.Name = "UdpCol";
            this.UdpCol.Size = new System.Drawing.Size(24, 20);
            this.UdpCol.TabIndex = 11;
            this.UdpCol.WordWrap = false;
            // 
            // BwLbl
            // 
            this.BwLbl.AutoSize = true;
            this.BwLbl.Location = new System.Drawing.Point(348, 112);
            this.BwLbl.Name = "BwLbl";
            this.BwLbl.Size = new System.Drawing.Size(57, 13);
            this.BwLbl.TabIndex = 20;
            this.BwLbl.Text = "Bandwidth";
            // 
            // BwCol
            // 
            this.BwCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BwCol.Location = new System.Drawing.Point(411, 109);
            this.BwCol.MaxLength = 2;
            this.BwCol.Name = "BwCol";
            this.BwCol.Size = new System.Drawing.Size(24, 20);
            this.BwCol.TabIndex = 21;
            this.BwCol.WordWrap = false;
            // 
            // QamNameLbl
            // 
            this.QamNameLbl.AutoSize = true;
            this.QamNameLbl.Location = new System.Drawing.Point(13, 112);
            this.QamNameLbl.Name = "QamNameLbl";
            this.QamNameLbl.Size = new System.Drawing.Size(72, 13);
            this.QamNameLbl.TabIndex = 14;
            this.QamNameLbl.Text = "Device Name";
            // 
            // DeviceCol
            // 
            this.DeviceCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DeviceCol.Location = new System.Drawing.Point(91, 109);
            this.DeviceCol.MaxLength = 2;
            this.DeviceCol.Name = "DeviceCol";
            this.DeviceCol.Size = new System.Drawing.Size(24, 20);
            this.DeviceCol.TabIndex = 15;
            this.DeviceCol.WordWrap = false;
            // 
            // PortLbl
            // 
            this.PortLbl.AutoSize = true;
            this.PortLbl.Location = new System.Drawing.Point(122, 112);
            this.PortLbl.Name = "PortLbl";
            this.PortLbl.Size = new System.Drawing.Size(103, 13);
            this.PortLbl.TabIndex = 16;
            this.PortLbl.Text = "Device Port Number";
            // 
            // PortCol
            // 
            this.PortCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PortCol.Location = new System.Drawing.Point(231, 109);
            this.PortCol.MaxLength = 2;
            this.PortCol.Name = "PortCol";
            this.PortCol.Size = new System.Drawing.Size(24, 20);
            this.PortCol.TabIndex = 17;
            this.PortCol.WordWrap = false;
            // 
            // ProgNumLbl
            // 
            this.ProgNumLbl.AutoSize = true;
            this.ProgNumLbl.Location = new System.Drawing.Point(489, 81);
            this.ProgNumLbl.Name = "ProgNumLbl";
            this.ProgNumLbl.Size = new System.Drawing.Size(86, 13);
            this.ProgNumLbl.TabIndex = 12;
            this.ProgNumLbl.Text = "Program Number";
            // 
            // ProgNumCol
            // 
            this.ProgNumCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ProgNumCol.Location = new System.Drawing.Point(581, 78);
            this.ProgNumCol.MaxLength = 2;
            this.ProgNumCol.Name = "ProgNumCol";
            this.ProgNumCol.Size = new System.Drawing.Size(24, 20);
            this.ProgNumCol.TabIndex = 13;
            this.ProgNumCol.WordWrap = false;
            // 
            // ControllerLbl
            // 
            this.ControllerLbl.AutoSize = true;
            this.ControllerLbl.Location = new System.Drawing.Point(261, 112);
            this.ControllerLbl.Name = "ControllerLbl";
            this.ControllerLbl.Size = new System.Drawing.Size(51, 13);
            this.ControllerLbl.TabIndex = 18;
            this.ControllerLbl.Text = "Controller";
            // 
            // ControllerCol
            // 
            this.ControllerCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ControllerCol.Location = new System.Drawing.Point(318, 109);
            this.ControllerCol.MaxLength = 2;
            this.ControllerCol.Name = "ControllerCol";
            this.ControllerCol.Size = new System.Drawing.Size(24, 20);
            this.ControllerCol.TabIndex = 19;
            this.ControllerCol.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Enter the column letters from the spreadsheet for each piece of information";
            // 
            // ecUserNameLbl
            // 
            this.ecUserNameLbl.AutoSize = true;
            this.ecUserNameLbl.Location = new System.Drawing.Point(393, 153);
            this.ecUserNameLbl.Name = "ecUserNameLbl";
            this.ecUserNameLbl.Size = new System.Drawing.Size(60, 13);
            this.ecUserNameLbl.TabIndex = 26;
            this.ecUserNameLbl.Text = "User Name";
            // 
            // ecPasswordLbl
            // 
            this.ecPasswordLbl.AutoSize = true;
            this.ecPasswordLbl.Location = new System.Drawing.Point(393, 179);
            this.ecPasswordLbl.Name = "ecPasswordLbl";
            this.ecPasswordLbl.Size = new System.Drawing.Size(53, 13);
            this.ecPasswordLbl.TabIndex = 28;
            this.ecPasswordLbl.Text = "Password";
            // 
            // EcUserName
            // 
            this.EcUserName.Location = new System.Drawing.Point(459, 150);
            this.EcUserName.MaxLength = 30;
            this.EcUserName.Name = "EcUserName";
            this.EcUserName.Size = new System.Drawing.Size(117, 20);
            this.EcUserName.TabIndex = 27;
            this.EcUserName.WordWrap = false;
            // 
            // EcPassword
            // 
            this.EcPassword.Location = new System.Drawing.Point(459, 176);
            this.EcPassword.MaxLength = 64;
            this.EcPassword.Name = "EcPassword";
            this.EcPassword.Size = new System.Drawing.Size(117, 20);
            this.EcPassword.TabIndex = 29;
            this.EcPassword.UseSystemPasswordChar = true;
            this.EcPassword.WordWrap = false;
            // 
            // FrequencyLbl
            // 
            this.FrequencyLbl.AutoSize = true;
            this.FrequencyLbl.Location = new System.Drawing.Point(441, 112);
            this.FrequencyLbl.Name = "FrequencyLbl";
            this.FrequencyLbl.Size = new System.Drawing.Size(57, 13);
            this.FrequencyLbl.TabIndex = 22;
            this.FrequencyLbl.Text = "Frequency";
            // 
            // FrequencyCol
            // 
            this.FrequencyCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FrequencyCol.Location = new System.Drawing.Point(504, 109);
            this.FrequencyCol.MaxLength = 2;
            this.FrequencyCol.Name = "FrequencyCol";
            this.FrequencyCol.Size = new System.Drawing.Size(24, 20);
            this.FrequencyCol.TabIndex = 23;
            this.FrequencyCol.WordWrap = false;
            // 
            // DTAserviceLbl
            // 
            this.DTAserviceLbl.AutoSize = true;
            this.DTAserviceLbl.Location = new System.Drawing.Point(534, 112);
            this.DTAserviceLbl.Name = "DTAserviceLbl";
            this.DTAserviceLbl.Size = new System.Drawing.Size(68, 13);
            this.DTAserviceLbl.TabIndex = 24;
            this.DTAserviceLbl.Text = "DTA Service";
            // 
            // DTAservCol
            // 
            this.DTAservCol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DTAservCol.Location = new System.Drawing.Point(608, 109);
            this.DTAservCol.MaxLength = 2;
            this.DTAservCol.Name = "DTAservCol";
            this.DTAservCol.Size = new System.Drawing.Size(24, 20);
            this.DTAservCol.TabIndex = 25;
            this.DTAservCol.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 208);
            this.Controls.Add(this.DTAservCol);
            this.Controls.Add(this.DTAserviceLbl);
            this.Controls.Add(this.FrequencyCol);
            this.Controls.Add(this.FrequencyLbl);
            this.Controls.Add(this.EcPassword);
            this.Controls.Add(this.EcUserName);
            this.Controls.Add(this.ecPasswordLbl);
            this.Controls.Add(this.ecUserNameLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ControllerCol);
            this.Controls.Add(this.ControllerLbl);
            this.Controls.Add(this.ProgNumCol);
            this.Controls.Add(this.ProgNumLbl);
            this.Controls.Add(this.PortCol);
            this.Controls.Add(this.PortLbl);
            this.Controls.Add(this.DeviceCol);
            this.Controls.Add(this.QamNameLbl);
            this.Controls.Add(this.BwCol);
            this.Controls.Add(this.BwLbl);
            this.Controls.Add(this.UdpCol);
            this.Controls.Add(this.UdpLbl);
            this.Controls.Add(this.MulticastIpCol);
            this.Controls.Add(this.mCastIpLbl);
            this.Controls.Add(this.SrcIpCol);
            this.Controls.Add(this.SourceIpLbl);
            this.Controls.Add(this.SrcIdCol);
            this.Controls.Add(this.SourceIdLbl);
            this.Controls.Add(this.SrcNmCol);
            this.Controls.Add(this.SourceNameLbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EC Service Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label SourceNameLbl;
        private System.Windows.Forms.TextBox SrcNmCol;
        private System.Windows.Forms.Label SourceIdLbl;
        private System.Windows.Forms.TextBox SrcIdCol;
        private System.Windows.Forms.Label SourceIpLbl;
        private System.Windows.Forms.TextBox SrcIpCol;
        private System.Windows.Forms.Label mCastIpLbl;
        private System.Windows.Forms.TextBox MulticastIpCol;
        private System.Windows.Forms.Label UdpLbl;
        private System.Windows.Forms.TextBox UdpCol;
        private System.Windows.Forms.Label BwLbl;
        private System.Windows.Forms.TextBox BwCol;
        private System.Windows.Forms.Label QamNameLbl;
        private System.Windows.Forms.TextBox DeviceCol;
        private System.Windows.Forms.Label PortLbl;
        private System.Windows.Forms.TextBox PortCol;
        private System.Windows.Forms.Label ProgNumLbl;
        private System.Windows.Forms.TextBox ProgNumCol;
        private System.Windows.Forms.Label ControllerLbl;
        private System.Windows.Forms.TextBox ControllerCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ecUserNameLbl;
        private System.Windows.Forms.Label ecPasswordLbl;
        private System.Windows.Forms.TextBox EcUserName;
        private System.Windows.Forms.TextBox EcPassword;
        private System.Windows.Forms.Label FrequencyLbl;
        private System.Windows.Forms.TextBox FrequencyCol;
        private System.Windows.Forms.Label DTAserviceLbl;
        private System.Windows.Forms.TextBox DTAservCol;
    }
}

