namespace FusionTweaker
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.applyButton = new System.Windows.Forms.Button();
            this.powerSchemesComboBox = new System.Windows.Forms.ComboBox();
            this.serviceButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cpu1Bar = new System.Windows.Forms.ProgressBar();
            this.cpu2Bar = new System.Windows.Forms.ProgressBar();
            this.cpu3Bar = new System.Windows.Forms.ProgressBar();
            this.cpu4Bar = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageP0 = new System.Windows.Forms.TabPage();
            this.p0StateControl = new FusionTweaker.PStateControl();
            this.tabPageP1 = new System.Windows.Forms.TabPage();
            this.p1StateControl = new FusionTweaker.PStateControl();
            this.tabPageP2 = new System.Windows.Forms.TabPage();
            this.p2StateControl = new FusionTweaker.PStateControl();
            this.tabPageP3 = new System.Windows.Forms.TabPage();
            this.p3StateControl = new FusionTweaker.PStateControl();
            this.tabPageP4 = new System.Windows.Forms.TabPage();
            this.p4StateControl = new FusionTweaker.PStateControl();
            this.tabPageP5 = new System.Windows.Forms.TabPage();
            this.p5StateControl = new FusionTweaker.PStateControl();
            this.tabPageP6 = new System.Windows.Forms.TabPage();
            this.p6StateControl = new FusionTweaker.PStateControl();
            this.tabPageP7 = new System.Windows.Forms.TabPage();
            this.p7StateControl = new FusionTweaker.PStateControl();
            this.tabPageNbP0 = new System.Windows.Forms.TabPage();
            this.nbp0StateControl = new FusionTweaker.PStateControl();
            this.tabPageNbP1 = new System.Windows.Forms.TabPage();
            this.nbp1StateControl = new FusionTweaker.PStateControl();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.logButton1 = new System.Windows.Forms.Button();
            this.statusinfo = new FusionTweaker.StatusControl();
            this.nbBar = new System.Windows.Forms.ProgressBar();
            this.pstateLabel = new System.Windows.Forms.Label();
            this.monitorCheckBox = new System.Windows.Forms.CheckBox();
            this.alwaysOnTopCheck = new System.Windows.Forms.CheckBox();
            this.ecread = new System.Windows.Forms.TextBox();
            this.cfgTempLabel = new System.Windows.Forms.Label();
            this.RealFreqLabel = new System.Windows.Forms.Label();
            this.core1label = new System.Windows.Forms.Label();
            this.core2label = new System.Windows.Forms.Label();
            this.core3label = new System.Windows.Forms.Label();
            this.core4label = new System.Windows.Forms.Label();
            this.pstateLabel1 = new System.Windows.Forms.Label();
            this.pstateLabel2 = new System.Windows.Forms.Label();
            this.pstateLabel3 = new System.Windows.Forms.Label();
            this.pstateLabel4 = new System.Windows.Forms.Label();
            this.nbLabel = new System.Windows.Forms.Label();
            this.nbPstateLabel = new System.Windows.Forms.Label();
            this.paypal = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.nbCfgTemp = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RealFreq = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageP0.SuspendLayout();
            this.tabPageP1.SuspendLayout();
            this.tabPageP2.SuspendLayout();
            this.tabPageP3.SuspendLayout();
            this.tabPageP4.SuspendLayout();
            this.tabPageP5.SuspendLayout();
            this.tabPageP6.SuspendLayout();
            this.tabPageP7.SuspendLayout();
            this.tabPageNbP0.SuspendLayout();
            this.tabPageNbP1.SuspendLayout();
            this.tabPageStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.AutoSize = true;
            this.applyButton.Location = new System.Drawing.Point(437, 366);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(80, 27);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "&Apply";
            this.toolTip1.SetToolTip(this.applyButton, "Apply the changes to the P-state settings.\r\nThey will last until the next reset.");
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // powerSchemesComboBox
            // 
            this.powerSchemesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.powerSchemesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.powerSchemesComboBox.FormattingEnabled = true;
            this.powerSchemesComboBox.Location = new System.Drawing.Point(12, 368);
            this.powerSchemesComboBox.Name = "powerSchemesComboBox";
            this.powerSchemesComboBox.Size = new System.Drawing.Size(317, 21);
            this.powerSchemesComboBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.powerSchemesComboBox, "Switch on-the-fly between Windows power schemes.");
            // 
            // serviceButton
            // 
            this.serviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceButton.AutoSize = true;
            this.serviceButton.Location = new System.Drawing.Point(337, 366);
            this.serviceButton.Name = "serviceButton";
            this.serviceButton.Size = new System.Drawing.Size(80, 27);
            this.serviceButton.TabIndex = 3;
            this.serviceButton.Text = "&Service...";
            this.toolTip1.SetToolTip(this.serviceButton, "Configure the FusionTweaker service.");
            this.serviceButton.UseVisualStyleBackColor = true;
            this.serviceButton.Click += new System.EventHandler(this.serviceButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 30000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 500;
            // 
            // cpu1Bar
            // 
            this.cpu1Bar.Location = new System.Drawing.Point(46, 56);
            this.cpu1Bar.Margin = new System.Windows.Forms.Padding(2);
            this.cpu1Bar.Name = "cpu1Bar";
            this.cpu1Bar.Size = new System.Drawing.Size(42, 10);
            this.cpu1Bar.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cpu1Bar, "Shows the current speed of the CPU");
            // 
            // cpu2Bar
            // 
            this.cpu2Bar.Location = new System.Drawing.Point(46, 69);
            this.cpu2Bar.Margin = new System.Windows.Forms.Padding(2);
            this.cpu2Bar.Name = "cpu2Bar";
            this.cpu2Bar.Size = new System.Drawing.Size(42, 11);
            this.cpu2Bar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cpu2Bar, "Shows the current speed of the CPU");
            // 
            // cpu3Bar
            // 
            this.cpu3Bar.Location = new System.Drawing.Point(46, 83);
            this.cpu3Bar.Margin = new System.Windows.Forms.Padding(2);
            this.cpu3Bar.Name = "cpu3Bar";
            this.cpu3Bar.Size = new System.Drawing.Size(42, 11);
            this.cpu3Bar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.cpu3Bar, "Shows the current speed of the CPU");
            // 
            // cpu4Bar
            // 
            this.cpu4Bar.Location = new System.Drawing.Point(46, 96);
            this.cpu4Bar.Margin = new System.Windows.Forms.Padding(2);
            this.cpu4Bar.Name = "cpu4Bar";
            this.cpu4Bar.Size = new System.Drawing.Size(42, 11);
            this.cpu4Bar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cpu4Bar, "Shows the current speed of the CPU");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageP0);
            this.tabControl1.Controls.Add(this.tabPageP1);
            this.tabControl1.Controls.Add(this.tabPageP2);
            this.tabControl1.Controls.Add(this.tabPageP3);
            this.tabControl1.Controls.Add(this.tabPageP4);
            this.tabControl1.Controls.Add(this.tabPageP5);
            this.tabControl1.Controls.Add(this.tabPageP6);
            this.tabControl1.Controls.Add(this.tabPageP7);
            this.tabControl1.Controls.Add(this.tabPageNbP0);
            this.tabControl1.Controls.Add(this.tabPageNbP1);
            this.tabControl1.Controls.Add(this.tabPageStatus);
            this.tabControl1.Location = new System.Drawing.Point(12, 130);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(507, 231);
            this.tabControl1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.tabControl1, "P(erformance)-states of your CPU/NB.\r\nP0 is the maximum performance state.");
            // 
            // tabPageP0
            // 
            this.tabPageP0.Controls.Add(this.p0StateControl);
            this.tabPageP0.Location = new System.Drawing.Point(4, 22);
            this.tabPageP0.Name = "tabPageP0";
            this.tabPageP0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP0.Size = new System.Drawing.Size(499, 205);
            this.tabPageP0.TabIndex = 0;
            this.tabPageP0.Text = "P0";
            this.tabPageP0.UseVisualStyleBackColor = true;
            // 
            // p0StateControl
            // 
            this.p0StateControl.Location = new System.Drawing.Point(0, 0);
            this.p0StateControl.Name = "p0StateControl";
            this.p0StateControl.PStateIndex = 0;
            this.p0StateControl.Size = new System.Drawing.Size(378, 131);
            this.p0StateControl.TabIndex = 0;
            // 
            // tabPageP1
            // 
            this.tabPageP1.Controls.Add(this.p1StateControl);
            this.tabPageP1.Location = new System.Drawing.Point(4, 22);
            this.tabPageP1.Name = "tabPageP1";
            this.tabPageP1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP1.Size = new System.Drawing.Size(499, 205);
            this.tabPageP1.TabIndex = 1;
            this.tabPageP1.Text = "P1";
            this.tabPageP1.UseVisualStyleBackColor = true;
            // 
            // p1StateControl
            // 
            this.p1StateControl.Location = new System.Drawing.Point(0, 0);
            this.p1StateControl.Name = "p1StateControl";
            this.p1StateControl.PStateIndex = 1;
            this.p1StateControl.Size = new System.Drawing.Size(377, 170);
            this.p1StateControl.TabIndex = 1;
            // 
            // tabPageP2
            // 
            this.tabPageP2.Controls.Add(this.p2StateControl);
            this.tabPageP2.Location = new System.Drawing.Point(4, 22);
            this.tabPageP2.Name = "tabPageP2";
            this.tabPageP2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP2.Size = new System.Drawing.Size(499, 205);
            this.tabPageP2.TabIndex = 2;
            this.tabPageP2.Text = "P2";
            this.tabPageP2.UseVisualStyleBackColor = true;
            // 
            // p2StateControl
            // 
            this.p2StateControl.Location = new System.Drawing.Point(0, 0);
            this.p2StateControl.Name = "p2StateControl";
            this.p2StateControl.PStateIndex = 2;
            this.p2StateControl.Size = new System.Drawing.Size(378, 131);
            this.p2StateControl.TabIndex = 2;
            // 
            // tabPageP3
            // 
            this.tabPageP3.Controls.Add(this.p3StateControl);
            this.tabPageP3.Location = new System.Drawing.Point(4, 22);
            this.tabPageP3.Name = "tabPageP3";
            this.tabPageP3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP3.Size = new System.Drawing.Size(499, 205);
            this.tabPageP3.TabIndex = 3;
            this.tabPageP3.Text = "P3";
            this.tabPageP3.UseVisualStyleBackColor = true;
            // 
            // p3StateControl
            // 
            this.p3StateControl.Location = new System.Drawing.Point(0, 0);
            this.p3StateControl.Name = "p3StateControl";
            this.p3StateControl.PStateIndex = 3;
            this.p3StateControl.Size = new System.Drawing.Size(378, 131);
            this.p3StateControl.TabIndex = 3;
            // 
            // tabPageP4
            // 
            this.tabPageP4.Controls.Add(this.p4StateControl);
            this.tabPageP4.Location = new System.Drawing.Point(4, 22);
            this.tabPageP4.Name = "tabPageP4";
            this.tabPageP4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP4.Size = new System.Drawing.Size(499, 205);
            this.tabPageP4.TabIndex = 4;
            this.tabPageP4.Text = "P4";
            this.tabPageP4.UseVisualStyleBackColor = true;
            // 
            // p4StateControl
            // 
            this.p4StateControl.Location = new System.Drawing.Point(0, 0);
            this.p4StateControl.Name = "p4StateControl";
            this.p4StateControl.PStateIndex = 4;
            this.p4StateControl.Size = new System.Drawing.Size(379, 131);
            this.p4StateControl.TabIndex = 4;
            // 
            // tabPageP5
            // 
            this.tabPageP5.Controls.Add(this.p5StateControl);
            this.tabPageP5.Location = new System.Drawing.Point(4, 22);
            this.tabPageP5.Name = "tabPageP5";
            this.tabPageP5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP5.Size = new System.Drawing.Size(499, 205);
            this.tabPageP5.TabIndex = 5;
            this.tabPageP5.Text = "P5";
            this.tabPageP5.UseVisualStyleBackColor = true;
            // 
            // p5StateControl
            // 
            this.p5StateControl.Location = new System.Drawing.Point(0, 0);
            this.p5StateControl.Name = "p5StateControl";
            this.p5StateControl.PStateIndex = 5;
            this.p5StateControl.Size = new System.Drawing.Size(378, 131);
            this.p5StateControl.TabIndex = 5;
            // 
            // tabPageP6
            // 
            this.tabPageP6.Controls.Add(this.p6StateControl);
            this.tabPageP6.Location = new System.Drawing.Point(4, 22);
            this.tabPageP6.Name = "tabPageP6";
            this.tabPageP6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP6.Size = new System.Drawing.Size(499, 205);
            this.tabPageP6.TabIndex = 6;
            this.tabPageP6.Text = "P6";
            this.tabPageP6.UseVisualStyleBackColor = true;
            // 
            // p6StateControl
            // 
            this.p6StateControl.Location = new System.Drawing.Point(0, 0);
            this.p6StateControl.Name = "p6StateControl";
            this.p6StateControl.PStateIndex = 6;
            this.p6StateControl.Size = new System.Drawing.Size(377, 131);
            this.p6StateControl.TabIndex = 6;
            // 
            // tabPageP7
            // 
            this.tabPageP7.Controls.Add(this.p7StateControl);
            this.tabPageP7.Location = new System.Drawing.Point(4, 22);
            this.tabPageP7.Name = "tabPageP7";
            this.tabPageP7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageP7.Size = new System.Drawing.Size(499, 205);
            this.tabPageP7.TabIndex = 7;
            this.tabPageP7.Text = "P7";
            this.tabPageP7.UseVisualStyleBackColor = true;
            // 
            // p7StateControl
            // 
            this.p7StateControl.Location = new System.Drawing.Point(0, 0);
            this.p7StateControl.Name = "p7StateControl";
            this.p7StateControl.PStateIndex = 7;
            this.p7StateControl.Size = new System.Drawing.Size(379, 131);
            this.p7StateControl.TabIndex = 7;
            // 
            // tabPageNbP0
            // 
            this.tabPageNbP0.Controls.Add(this.nbp0StateControl);
            this.tabPageNbP0.Location = new System.Drawing.Point(4, 22);
            this.tabPageNbP0.Name = "tabPageNbP0";
            this.tabPageNbP0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNbP0.Size = new System.Drawing.Size(499, 205);
            this.tabPageNbP0.TabIndex = 8;
            this.tabPageNbP0.Text = "NB P0";
            this.tabPageNbP0.UseVisualStyleBackColor = true;
            // 
            // nbp0StateControl
            // 
            this.nbp0StateControl.Location = new System.Drawing.Point(0, 0);
            this.nbp0StateControl.Name = "nbp0StateControl";
            this.nbp0StateControl.PStateIndex = 8;
            this.nbp0StateControl.Size = new System.Drawing.Size(420, 131);
            this.nbp0StateControl.TabIndex = 8;
            // 
            // tabPageNbP1
            // 
            this.tabPageNbP1.Controls.Add(this.nbp1StateControl);
            this.tabPageNbP1.Location = new System.Drawing.Point(4, 22);
            this.tabPageNbP1.Name = "tabPageNbP1";
            this.tabPageNbP1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNbP1.Size = new System.Drawing.Size(499, 205);
            this.tabPageNbP1.TabIndex = 9;
            this.tabPageNbP1.Text = "NB P1";
            this.tabPageNbP1.UseVisualStyleBackColor = true;
            // 
            // nbp1StateControl
            // 
            this.nbp1StateControl.AutoSize = true;
            this.nbp1StateControl.Location = new System.Drawing.Point(0, 0);
            this.nbp1StateControl.Name = "nbp1StateControl";
            this.nbp1StateControl.PStateIndex = 9;
            this.nbp1StateControl.Size = new System.Drawing.Size(422, 131);
            this.nbp1StateControl.TabIndex = 9;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.logButton1);
            this.tabPageStatus.Controls.Add(this.statusinfo);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatus.Size = new System.Drawing.Size(499, 205);
            this.tabPageStatus.TabIndex = 10;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // logButton1
            // 
            this.logButton1.Location = new System.Drawing.Point(88, 10);
            this.logButton1.Name = "logButton1";
            this.logButton1.Size = new System.Drawing.Size(75, 23);
            this.logButton1.TabIndex = 10;
            this.logButton1.Text = "Log now";
            this.toolTip1.SetToolTip(this.logButton1, "Hit the button to store the current settings in a file, which than will be opened" +
        " in your default editor for further use.");
            this.logButton1.UseVisualStyleBackColor = true;
            this.logButton1.Click += new System.EventHandler(this.logButton_Click);
            // 
            // statusinfo
            // 
            this.statusinfo.AutoSize = true;
            this.statusinfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusinfo.Location = new System.Drawing.Point(3, 3);
            this.statusinfo.Margin = new System.Windows.Forms.Padding(4);
            this.statusinfo.Name = "statusinfo";
            this.statusinfo.Size = new System.Drawing.Size(493, 199);
            this.statusinfo.StatusIndex = 0;
            this.statusinfo.TabIndex = 10;
            // 
            // nbBar
            // 
            this.nbBar.Location = new System.Drawing.Point(220, 55);
            this.nbBar.Margin = new System.Windows.Forms.Padding(2);
            this.nbBar.Name = "nbBar";
            this.nbBar.Size = new System.Drawing.Size(42, 10);
            this.nbBar.TabIndex = 22;
            this.toolTip1.SetToolTip(this.nbBar, "Shows the current Northbridge/GPU PState and its related frequency.");
            // 
            // pstateLabel
            // 
            this.pstateLabel.AutoSize = true;
            this.pstateLabel.Location = new System.Drawing.Point(88, 40);
            this.pstateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pstateLabel.Name = "pstateLabel";
            this.pstateLabel.Size = new System.Drawing.Size(69, 13);
            this.pstateLabel.TabIndex = 14;
            this.pstateLabel.Text = "PState - Freq";
            this.toolTip1.SetToolTip(this.pstateLabel, "This column shows the current Pstate and its related frequency per core. ");
            // 
            // monitorCheckBox
            // 
            this.monitorCheckBox.AutoSize = true;
            this.monitorCheckBox.Checked = true;
            this.monitorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.monitorCheckBox.Location = new System.Drawing.Point(7, 19);
            this.monitorCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.monitorCheckBox.Name = "monitorCheckBox";
            this.monitorCheckBox.Size = new System.Drawing.Size(110, 17);
            this.monitorCheckBox.TabIndex = 19;
            this.monitorCheckBox.Text = "Enable monitoring";
            this.toolTip1.SetToolTip(this.monitorCheckBox, "Check this option to watch the CPU stepping through the currently enabled frequen" +
        "cies based on current load.");
            this.monitorCheckBox.UseVisualStyleBackColor = true;
            this.monitorCheckBox.CheckedChanged += new System.EventHandler(this.monitorCheckBox_CheckedChanged);
            // 
            // alwaysOnTopCheck
            // 
            this.alwaysOnTopCheck.AutoSize = true;
            this.alwaysOnTopCheck.Location = new System.Drawing.Point(119, 19);
            this.alwaysOnTopCheck.Margin = new System.Windows.Forms.Padding(2);
            this.alwaysOnTopCheck.Name = "alwaysOnTopCheck";
            this.alwaysOnTopCheck.Size = new System.Drawing.Size(92, 17);
            this.alwaysOnTopCheck.TabIndex = 20;
            this.alwaysOnTopCheck.Text = "Always on top";
            this.toolTip1.SetToolTip(this.alwaysOnTopCheck, "Check this option, if you want to see the application always on top to monitor PS" +
        "tates and temperature.");
            this.alwaysOnTopCheck.UseVisualStyleBackColor = true;
            this.alwaysOnTopCheck.CheckedChanged += new System.EventHandler(this.alwaysOnTopCheck_CheckedChanged);
            // 
            // ecread
            // 
            this.ecread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ecread.Location = new System.Drawing.Point(12, 20);
            this.ecread.MinimumSize = new System.Drawing.Size(226, 20);
            this.ecread.Name = "ecread";
            this.ecread.Size = new System.Drawing.Size(231, 20);
            this.ecread.TabIndex = 7;
            this.toolTip1.SetToolTip(this.ecread, "Shows the chip and motherboard temperatures, while also adding an approximated va" +
        "lue of the fan speed.");
            // 
            // cfgTempLabel
            // 
            this.cfgTempLabel.AutoSize = true;
            this.cfgTempLabel.Location = new System.Drawing.Point(189, 69);
            this.cfgTempLabel.Name = "cfgTempLabel";
            this.cfgTempLabel.Size = new System.Drawing.Size(62, 13);
            this.cfgTempLabel.TabIndex = 24;
            this.cfgTempLabel.Text = "CPU Temp:";
            this.toolTip1.SetToolTip(this.cfgTempLabel, "Shows the current APU temperature.");
            // 
            // RealFreqLabel
            // 
            this.RealFreqLabel.AutoSize = true;
            this.RealFreqLabel.Location = new System.Drawing.Point(189, 95);
            this.RealFreqLabel.Name = "RealFreqLabel";
            this.RealFreqLabel.Size = new System.Drawing.Size(88, 13);
            this.RealFreqLabel.TabIndex = 26;
            this.RealFreqLabel.Text = "Core0 Real MHz:";
            this.toolTip1.SetToolTip(this.RealFreqLabel, "Shows the current APU temperature.");
            this.RealFreqLabel.Visible = false;
            // 
            // core1label
            // 
            this.core1label.AutoSize = true;
            this.core1label.Location = new System.Drawing.Point(4, 56);
            this.core1label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.core1label.Name = "core1label";
            this.core1label.Size = new System.Drawing.Size(38, 13);
            this.core1label.TabIndex = 10;
            this.core1label.Text = "Core 1";
            // 
            // core2label
            // 
            this.core2label.AutoSize = true;
            this.core2label.Location = new System.Drawing.Point(4, 69);
            this.core2label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.core2label.Name = "core2label";
            this.core2label.Size = new System.Drawing.Size(38, 13);
            this.core2label.TabIndex = 11;
            this.core2label.Text = "Core 2";
            // 
            // core3label
            // 
            this.core3label.AutoSize = true;
            this.core3label.Location = new System.Drawing.Point(4, 82);
            this.core3label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.core3label.Name = "core3label";
            this.core3label.Size = new System.Drawing.Size(38, 13);
            this.core3label.TabIndex = 12;
            this.core3label.Text = "Core 3";
            // 
            // core4label
            // 
            this.core4label.AutoSize = true;
            this.core4label.Location = new System.Drawing.Point(4, 96);
            this.core4label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.core4label.Name = "core4label";
            this.core4label.Size = new System.Drawing.Size(38, 13);
            this.core4label.TabIndex = 13;
            this.core4label.Text = "Core 4";
            // 
            // pstateLabel1
            // 
            this.pstateLabel1.AutoSize = true;
            this.pstateLabel1.Location = new System.Drawing.Point(101, 55);
            this.pstateLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pstateLabel1.Name = "pstateLabel1";
            this.pstateLabel1.Size = new System.Drawing.Size(16, 13);
            this.pstateLabel1.TabIndex = 15;
            this.pstateLabel1.Text = "-1";
            // 
            // pstateLabel2
            // 
            this.pstateLabel2.AutoSize = true;
            this.pstateLabel2.Location = new System.Drawing.Point(101, 68);
            this.pstateLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pstateLabel2.Name = "pstateLabel2";
            this.pstateLabel2.Size = new System.Drawing.Size(16, 13);
            this.pstateLabel2.TabIndex = 16;
            this.pstateLabel2.Text = "-1";
            // 
            // pstateLabel3
            // 
            this.pstateLabel3.AutoSize = true;
            this.pstateLabel3.Location = new System.Drawing.Point(101, 82);
            this.pstateLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pstateLabel3.Name = "pstateLabel3";
            this.pstateLabel3.Size = new System.Drawing.Size(16, 13);
            this.pstateLabel3.TabIndex = 17;
            this.pstateLabel3.Text = "-1";
            // 
            // pstateLabel4
            // 
            this.pstateLabel4.AutoSize = true;
            this.pstateLabel4.Location = new System.Drawing.Point(101, 95);
            this.pstateLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pstateLabel4.Name = "pstateLabel4";
            this.pstateLabel4.Size = new System.Drawing.Size(16, 13);
            this.pstateLabel4.TabIndex = 18;
            this.pstateLabel4.Text = "-1";
            // 
            // nbLabel
            // 
            this.nbLabel.AutoSize = true;
            this.nbLabel.Location = new System.Drawing.Point(189, 55);
            this.nbLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nbLabel.Name = "nbLabel";
            this.nbLabel.Size = new System.Drawing.Size(22, 13);
            this.nbLabel.TabIndex = 21;
            this.nbLabel.Text = "NB";
            // 
            // nbPstateLabel
            // 
            this.nbPstateLabel.AutoSize = true;
            this.nbPstateLabel.Location = new System.Drawing.Point(268, 53);
            this.nbPstateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nbPstateLabel.Name = "nbPstateLabel";
            this.nbPstateLabel.Size = new System.Drawing.Size(16, 13);
            this.nbPstateLabel.TabIndex = 23;
            this.nbPstateLabel.Text = "-1";
            // 
            // paypal
            // 
            this.paypal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paypal.AutoSize = true;
            this.paypal.Location = new System.Drawing.Point(9, 2);
            this.paypal.Margin = new System.Windows.Forms.Padding(2);
            this.paypal.Name = "paypal";
            this.paypal.Size = new System.Drawing.Size(192, 13);
            this.paypal.TabIndex = 6;
            this.paypal.TabStop = true;
            this.paypal.Text = "Please donate to support development.";
            this.paypal.Click += new System.EventHandler(this.paypal_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // nbCfgTemp
            // 
            this.nbCfgTemp.AutoSize = true;
            this.nbCfgTemp.Location = new System.Drawing.Point(268, 69);
            this.nbCfgTemp.Name = "nbCfgTemp";
            this.nbCfgTemp.Size = new System.Drawing.Size(30, 13);
            this.nbCfgTemp.TabIndex = 25;
            this.nbCfgTemp.Text = "35°C";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "FusionTweaker";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // RealFreq
            // 
            this.RealFreq.AutoSize = true;
            this.RealFreq.Location = new System.Drawing.Point(283, 95);
            this.RealFreq.Name = "RealFreq";
            this.RealFreq.Size = new System.Drawing.Size(25, 13);
            this.RealFreq.TabIndex = 27;
            this.RealFreq.Text = "800";
            this.RealFreq.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 406);
            this.Controls.Add(this.RealFreq);
            this.Controls.Add(this.RealFreqLabel);
            this.Controls.Add(this.nbCfgTemp);
            this.Controls.Add(this.cfgTempLabel);
            this.Controls.Add(this.nbBar);
            this.Controls.Add(this.nbPstateLabel);
            this.Controls.Add(this.nbLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.paypal);
            this.Controls.Add(this.serviceButton);
            this.Controls.Add(this.alwaysOnTopCheck);
            this.Controls.Add(this.pstateLabel);
            this.Controls.Add(this.monitorCheckBox);
            this.Controls.Add(this.pstateLabel1);
            this.Controls.Add(this.core1label);
            this.Controls.Add(this.cpu1Bar);
            this.Controls.Add(this.pstateLabel2);
            this.Controls.Add(this.core2label);
            this.Controls.Add(this.cpu2Bar);
            this.Controls.Add(this.pstateLabel3);
            this.Controls.Add(this.core3label);
            this.Controls.Add(this.cpu3Bar);
            this.Controls.Add(this.pstateLabel4);
            this.Controls.Add(this.core4label);
            this.Controls.Add(this.cpu4Bar);
            this.Controls.Add(this.powerSchemesComboBox);
            this.Controls.Add(this.applyButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "Form1";
            this.Text = "FusionTweaker V2.0.6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPageP0.ResumeLayout(false);
            this.tabPageP1.ResumeLayout(false);
            this.tabPageP2.ResumeLayout(false);
            this.tabPageP3.ResumeLayout(false);
            this.tabPageP4.ResumeLayout(false);
            this.tabPageP5.ResumeLayout(false);
            this.tabPageP6.ResumeLayout(false);
            this.tabPageP7.ResumeLayout(false);
            this.tabPageNbP0.ResumeLayout(false);
            this.tabPageNbP1.ResumeLayout(false);
            this.tabPageNbP1.PerformLayout();
            this.tabPageStatus.ResumeLayout(false);
            this.tabPageStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button applyButton;
		private System.Windows.Forms.ComboBox powerSchemesComboBox;
		private System.Windows.Forms.Button serviceButton;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Timer timer1;
		//Brazos merge adding timer2 ecread cfgTempLabel nbCfgTemp
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox ecread;
        private System.Windows.Forms.Label cfgTempLabel;
        private System.Windows.Forms.Label nbCfgTemp;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.LinkLabel paypal;
		private System.Windows.Forms.TabPage tabPageP0;
		private PStateControl p0StateControl;
		private System.Windows.Forms.TabPage tabPageP1;
		private PStateControl p1StateControl;
		private System.Windows.Forms.TabPage tabPageP2;
		private PStateControl p2StateControl;
        private System.Windows.Forms.TabPage tabPageP3;
        private PStateControl p3StateControl;
        private System.Windows.Forms.TabPage tabPageP4;
        private PStateControl p4StateControl;
        private System.Windows.Forms.TabPage tabPageP5;
        private PStateControl p5StateControl;
        private System.Windows.Forms.TabPage tabPageP6;
        private PStateControl p6StateControl;
        private System.Windows.Forms.TabPage tabPageP7;
        private PStateControl p7StateControl;
        private System.Windows.Forms.TabPage tabPageNbP0;
		private PStateControl nbp0StateControl;
		private System.Windows.Forms.TabPage tabPageNbP1;
		private PStateControl nbp1StateControl;
        private System.Windows.Forms.TabPage tabPageStatus;
        private StatusControl statusinfo;
        private System.Windows.Forms.ProgressBar cpu1Bar;
        private System.Windows.Forms.ProgressBar cpu2Bar;
        private System.Windows.Forms.ProgressBar cpu3Bar;
        private System.Windows.Forms.ProgressBar cpu4Bar;
        private System.Windows.Forms.Label core1label;
        private System.Windows.Forms.Label core2label;
        private System.Windows.Forms.Label core3label;
        private System.Windows.Forms.Label core4label;
        private System.Windows.Forms.Label pstateLabel;
        private System.Windows.Forms.Label pstateLabel1;
        private System.Windows.Forms.Label pstateLabel2;
        private System.Windows.Forms.Label pstateLabel3;
        private System.Windows.Forms.Label pstateLabel4;
        private System.Windows.Forms.CheckBox monitorCheckBox;
        private System.Windows.Forms.CheckBox alwaysOnTopCheck;
        private System.Windows.Forms.Label nbLabel;
        private System.Windows.Forms.ProgressBar nbBar;
        private System.Windows.Forms.Label nbPstateLabel;
        private System.Windows.Forms.Button logButton1;
        private System.Windows.Forms.Label RealFreqLabel;
        private System.Windows.Forms.Label RealFreq;
    }
}

