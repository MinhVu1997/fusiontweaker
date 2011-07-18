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
            this.statusinfo = new FusionTweaker.StatusControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
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
			this.applyButton.Location = new System.Drawing.Point(363, 167);
			this.applyButton.Margin = new System.Windows.Forms.Padding(4);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(107, 33);
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
			this.powerSchemesComboBox.Location = new System.Drawing.Point(16, 172);
			this.powerSchemesComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.powerSchemesComboBox.Name = "powerSchemesComboBox";
			this.powerSchemesComboBox.Size = new System.Drawing.Size(220, 24);
			this.powerSchemesComboBox.TabIndex = 2;
			this.toolTip1.SetToolTip(this.powerSchemesComboBox, "Switch on-the-fly between Windows power schemes.");
			// 
			// serviceButton
			// 
			this.serviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.serviceButton.AutoSize = true;
			this.serviceButton.Location = new System.Drawing.Point(248, 167);
			this.serviceButton.Margin = new System.Windows.Forms.Padding(4);
			this.serviceButton.Name = "serviceButton";
			this.serviceButton.Size = new System.Drawing.Size(107, 33);
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
			this.tabControl1.Location = new System.Drawing.Point(16, 15);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(453, 138);
			this.tabControl1.TabIndex = 5;
			this.toolTip1.SetToolTip(this.tabControl1, "P(erformance)-states of your CPU/NB.\r\nP0 is the maximum performance state.");
			// 
			// tabPageP0
			// 
			this.tabPageP0.Controls.Add(this.p0StateControl);
			this.tabPageP0.Location = new System.Drawing.Point(4, 25);
			this.tabPageP0.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageP0.Name = "tabPageP0";
			this.tabPageP0.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageP0.Size = new System.Drawing.Size(445, 109);
			this.tabPageP0.TabIndex = 0;
			this.tabPageP0.Text = "P0";
			this.tabPageP0.UseVisualStyleBackColor = true;
			// 
			// p0StateControl
			// 
			this.p0StateControl.AutoSize = true;
			this.p0StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.p0StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p0StateControl.Location = new System.Drawing.Point(4, 4);
			this.p0StateControl.Margin = new System.Windows.Forms.Padding(5);
			this.p0StateControl.Name = "p0StateControl";
			this.p0StateControl.PStateIndex = 0;
			this.p0StateControl.Size = new System.Drawing.Size(437, 101);
			this.p0StateControl.TabIndex = 0;
			// 
			// tabPageP1
			// 
			this.tabPageP1.Controls.Add(this.p1StateControl);
			this.tabPageP1.Location = new System.Drawing.Point(4, 25);
			this.tabPageP1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageP1.Name = "tabPageP1";
			this.tabPageP1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageP1.Size = new System.Drawing.Size(445, 109);
			this.tabPageP1.TabIndex = 1;
			this.tabPageP1.Text = "P1";
			this.tabPageP1.UseVisualStyleBackColor = true;
			// 
			// p1StateControl
			// 
			this.p1StateControl.AutoSize = true;
			this.p1StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.p1StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p1StateControl.Location = new System.Drawing.Point(4, 4);
			this.p1StateControl.Margin = new System.Windows.Forms.Padding(5);
			this.p1StateControl.Name = "p1StateControl";
			this.p1StateControl.PStateIndex = 1;
			this.p1StateControl.Size = new System.Drawing.Size(437, 101);
			this.p1StateControl.TabIndex = 1;
			// 
			// tabPageP2
			// 
			this.tabPageP2.Controls.Add(this.p2StateControl);
			this.tabPageP2.Location = new System.Drawing.Point(4, 25);
			this.tabPageP2.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageP2.Name = "tabPageP2";
			this.tabPageP2.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageP2.Size = new System.Drawing.Size(445, 109);
			this.tabPageP2.TabIndex = 2;
			this.tabPageP2.Text = "P2";
			this.tabPageP2.UseVisualStyleBackColor = true;
			// 
			// p2StateControl
			// 
			this.p2StateControl.AutoSize = true;
			this.p2StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.p2StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p2StateControl.Location = new System.Drawing.Point(4, 4);
			this.p2StateControl.Margin = new System.Windows.Forms.Padding(5);
			this.p2StateControl.Name = "p2StateControl";
			this.p2StateControl.PStateIndex = 2;
			this.p2StateControl.Size = new System.Drawing.Size(437, 101);
			this.p2StateControl.TabIndex = 2;
            // 
            // tabPageP3
            // 
            this.tabPageP3.Controls.Add(this.p3StateControl);
            this.tabPageP3.Location = new System.Drawing.Point(4, 25);
            this.tabPageP3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageP3.Name = "tabPageP3";
            this.tabPageP3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageP3.Size = new System.Drawing.Size(445, 109);
            this.tabPageP3.TabIndex = 3;
            this.tabPageP3.Text = "P3";
            this.tabPageP3.UseVisualStyleBackColor = true;
            // 
            // p3StateControl
            // 
            this.p3StateControl.AutoSize = true;
            this.p3StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.p3StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p3StateControl.Location = new System.Drawing.Point(4, 4);
            this.p3StateControl.Margin = new System.Windows.Forms.Padding(5);
            this.p3StateControl.Name = "p3StateControl";
            this.p3StateControl.PStateIndex = 3;
            this.p3StateControl.Size = new System.Drawing.Size(437, 101);
            this.p3StateControl.TabIndex = 3;
            // 
            // tabPageP4
            // 
            this.tabPageP4.Controls.Add(this.p4StateControl);
            this.tabPageP4.Location = new System.Drawing.Point(4, 25);
            this.tabPageP4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageP4.Name = "tabPageP4";
            this.tabPageP4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageP4.Size = new System.Drawing.Size(445, 109);
            this.tabPageP4.TabIndex = 4;
            this.tabPageP4.Text = "P4";
            this.tabPageP4.UseVisualStyleBackColor = true;
            // 
            // p4StateControl
            // 
            this.p4StateControl.AutoSize = true;
            this.p4StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.p4StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p4StateControl.Location = new System.Drawing.Point(4, 4);
            this.p4StateControl.Margin = new System.Windows.Forms.Padding(5);
            this.p4StateControl.Name = "p4StateControl";
            this.p4StateControl.PStateIndex = 4;
            this.p4StateControl.Size = new System.Drawing.Size(437, 101);
            this.p4StateControl.TabIndex = 4;
            // 
            // tabPageP5
            // 
            this.tabPageP5.Controls.Add(this.p5StateControl);
            this.tabPageP5.Location = new System.Drawing.Point(4, 25);
            this.tabPageP5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageP5.Name = "tabPageP5";
            this.tabPageP5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageP5.Size = new System.Drawing.Size(445, 109);
            this.tabPageP5.TabIndex = 5;
            this.tabPageP5.Text = "P5";
            this.tabPageP5.UseVisualStyleBackColor = true;
            // 
            // p5StateControl
            // 
            this.p5StateControl.AutoSize = true;
            this.p5StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.p5StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p5StateControl.Location = new System.Drawing.Point(4, 4);
            this.p5StateControl.Margin = new System.Windows.Forms.Padding(5);
            this.p5StateControl.Name = "p5StateControl";
            this.p5StateControl.PStateIndex = 5;
            this.p5StateControl.Size = new System.Drawing.Size(437, 101);
            this.p5StateControl.TabIndex = 5;
            // 
            // tabPageP6
            // 
            this.tabPageP6.Controls.Add(this.p6StateControl);
            this.tabPageP6.Location = new System.Drawing.Point(4, 25);
            this.tabPageP6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageP6.Name = "tabPageP6";
            this.tabPageP6.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageP6.Size = new System.Drawing.Size(445, 109);
            this.tabPageP6.TabIndex = 6;
            this.tabPageP6.Text = "P6";
            this.tabPageP6.UseVisualStyleBackColor = true;
            // 
            // p6StateControl
            // 
            this.p6StateControl.AutoSize = true;
            this.p6StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.p6StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p6StateControl.Location = new System.Drawing.Point(4, 4);
            this.p6StateControl.Margin = new System.Windows.Forms.Padding(5);
            this.p6StateControl.Name = "p6StateControl";
            this.p6StateControl.PStateIndex = 6;
            this.p6StateControl.Size = new System.Drawing.Size(437, 101);
            this.p6StateControl.TabIndex = 6;
            // 
            // tabPageP7
            // 
            this.tabPageP7.Controls.Add(this.p7StateControl);
            this.tabPageP7.Location = new System.Drawing.Point(4, 25);
            this.tabPageP7.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageP7.Name = "tabPageP7";
            this.tabPageP7.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageP7.Size = new System.Drawing.Size(445, 109);
            this.tabPageP7.TabIndex = 7;
            this.tabPageP7.Text = "P7";
            this.tabPageP7.UseVisualStyleBackColor = true;
            // 
            // p7StateControl
            // 
            this.p7StateControl.AutoSize = true;
            this.p7StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.p7StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p7StateControl.Location = new System.Drawing.Point(4, 4);
            this.p7StateControl.Margin = new System.Windows.Forms.Padding(5);
            this.p7StateControl.Name = "p7StateControl";
            this.p7StateControl.PStateIndex = 7;
            this.p7StateControl.Size = new System.Drawing.Size(437, 101);
            this.p7StateControl.TabIndex = 7;
            // 
			// tabPageNbP0
			// 
			this.tabPageNbP0.Controls.Add(this.nbp0StateControl);
			this.tabPageNbP0.Location = new System.Drawing.Point(4, 25);
			this.tabPageNbP0.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageNbP0.Name = "tabPageNbP0";
			this.tabPageNbP0.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageNbP0.Size = new System.Drawing.Size(445, 109);
			this.tabPageNbP0.TabIndex = 3;
			this.tabPageNbP0.Text = "NB P0";
			this.tabPageNbP0.UseVisualStyleBackColor = true;
			// 
			// nbp0StateControl
			// 
			this.nbp0StateControl.AutoSize = true;
			this.nbp0StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.nbp0StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nbp0StateControl.Location = new System.Drawing.Point(4, 4);
			this.nbp0StateControl.Margin = new System.Windows.Forms.Padding(5);
			this.nbp0StateControl.Name = "nbp0StateControl";
			this.nbp0StateControl.PStateIndex = 3;
			this.nbp0StateControl.Size = new System.Drawing.Size(437, 101);
			this.nbp0StateControl.TabIndex = 0;
			// 
			// tabPageNbP1
			// 
			this.tabPageNbP1.Controls.Add(this.nbp1StateControl);
			this.tabPageNbP1.Location = new System.Drawing.Point(4, 25);
			this.tabPageNbP1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageNbP1.Name = "tabPageNbP1";
			this.tabPageNbP1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageNbP1.Size = new System.Drawing.Size(445, 109);
			this.tabPageNbP1.TabIndex = 4;
			this.tabPageNbP1.Text = "NB P1";
			this.tabPageNbP1.UseVisualStyleBackColor = true;
			// 
			// nbp1StateControl
			// 
			this.nbp1StateControl.AutoSize = true;
			this.nbp1StateControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.nbp1StateControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nbp1StateControl.Location = new System.Drawing.Point(4, 4);
			this.nbp1StateControl.Margin = new System.Windows.Forms.Padding(5);
			this.nbp1StateControl.Name = "nbp1StateControl";
			this.nbp1StateControl.PStateIndex = 4;
			this.nbp1StateControl.Size = new System.Drawing.Size(437, 101);
			this.nbp1StateControl.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.statusinfo);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 25);
            this.tabPageStatus.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageStatus.Size = new System.Drawing.Size(445, 109);
            this.tabPageStatus.TabIndex = 5;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // statusinfo
            // 
            this.statusinfo.AutoSize = true;
            this.statusinfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusinfo.Location = new System.Drawing.Point(4, 4);
            this.statusinfo.Margin = new System.Windows.Forms.Padding(5);
            this.statusinfo.Name = "statusinfo";
            this.statusinfo.StatusIndex = 0;
            this.statusinfo.Size = new System.Drawing.Size(437, 101);
            this.statusinfo.TabIndex = 0;
            // 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 250;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.Text = "FusionTweaker";
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 215);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.serviceButton);
			this.Controls.Add(this.powerSchemesComboBox);
			this.Controls.Add(this.applyButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(341, 252);
			this.Name = "Form1";
			this.Text = "FusionTweaker V1.0.1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.tabControl1.ResumeLayout(false);
			this.tabPageP0.ResumeLayout(false);
			this.tabPageP0.PerformLayout();
			this.tabPageP1.ResumeLayout(false);
			this.tabPageP1.PerformLayout();
			this.tabPageP2.ResumeLayout(false);
			this.tabPageP2.PerformLayout();
			this.tabPageNbP0.ResumeLayout(false);
			this.tabPageNbP0.PerformLayout();
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
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.TabControl tabControl1;
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
    }
}

