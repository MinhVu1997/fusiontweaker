namespace FusionTweaker
{
	partial class PStateControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.Cofstate = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.VidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanelPstates = new System.Windows.Forms.TableLayoutPanel();
            this.VIDlabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CLKlabel = new System.Windows.Forms.Label();
            this.checkBox_Penable = new System.Windows.Forms.CheckBox();
            this.pllfreq = new System.Windows.Forms.Label();
            this.freqvalue = new System.Windows.Forms.Label();
            this.clockvalue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VidNumericUpDown)).BeginInit();
            this.tableLayoutPanelPstates.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cofstate
            // 
            this.Cofstate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Cofstate.AutoSize = true;
            this.Cofstate.Location = new System.Drawing.Point(3, 3);
            this.Cofstate.Margin = new System.Windows.Forms.Padding(3);
            this.Cofstate.Name = "Cofstate";
            this.Cofstate.Size = new System.Drawing.Size(57, 13);
            this.Cofstate.TabIndex = 0;
            this.Cofstate.Text = "Frequency";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.refreshButton.AutoSize = true;
            this.refreshButton.Image = global::FusionTweaker.Properties.Resources.refresh;
            this.refreshButton.Location = new System.Drawing.Point(159, 22);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tableLayoutPanelPstates.SetRowSpan(this.refreshButton, 2);
            this.refreshButton.Size = new System.Drawing.Size(90, 27);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.refreshButton, "Load the current settings directly from the CPU registers.");
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 30000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 500;
            // 
            // VidNumericUpDown
            // 
            this.VidNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VidNumericUpDown.AutoSize = true;
            this.VidNumericUpDown.DecimalPlaces = 4;
            this.VidNumericUpDown.Increment = new decimal(new int[] {
            125,
            0,
            0,
            262144});
            this.VidNumericUpDown.Location = new System.Drawing.Point(97, 22);
            this.VidNumericUpDown.Maximum = new decimal(new int[] {
            155,
            0,
            0,
            131072});
            this.VidNumericUpDown.Minimum = new decimal(new int[] {
            125,
            0,
            0,
            262144});
            this.VidNumericUpDown.Name = "VidNumericUpDown";
            this.VidNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.VidNumericUpDown.TabIndex = 3;
            this.toolTip1.SetToolTip(this.VidNumericUpDown, "Requested voltage level to supply the CPU part of the chip.");
            this.VidNumericUpDown.Value = new decimal(new int[] {
            130,
            0,
            0,
            131072});
            // 
            // tableLayoutPanelPstates
            // 
            this.tableLayoutPanelPstates.AutoSize = true;
            this.tableLayoutPanelPstates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelPstates.ColumnCount = 3;
            this.tableLayoutPanelPstates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPstates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPstates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPstates.Controls.Add(this.VIDlabel, 0, 1);
            this.tableLayoutPanelPstates.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanelPstates.Controls.Add(this.VidNumericUpDown, 1, 1);
            this.tableLayoutPanelPstates.Controls.Add(this.Cofstate, 0, 0);
            this.tableLayoutPanelPstates.Controls.Add(this.refreshButton, 2, 1);
            this.tableLayoutPanelPstates.Controls.Add(this.CLKlabel, 0, 2);
            this.tableLayoutPanelPstates.Controls.Add(this.checkBox_Penable, 0, 4);
            this.tableLayoutPanelPstates.Controls.Add(this.pllfreq, 0, 3);
            this.tableLayoutPanelPstates.Controls.Add(this.freqvalue, 1, 3);
            this.tableLayoutPanelPstates.Controls.Add(this.clockvalue, 1, 2);
            this.tableLayoutPanelPstates.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelPstates.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPstates.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPstates.MinimumSize = new System.Drawing.Size(0, 110);
            this.tableLayoutPanelPstates.Name = "tableLayoutPanelPstates";
            this.tableLayoutPanelPstates.RowCount = 5;
            this.tableLayoutPanelPstates.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPstates.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPstates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPstates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPstates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPstates.Size = new System.Drawing.Size(237, 110);
            this.tableLayoutPanelPstates.TabIndex = 0;
            // 
            // VIDlabel
            // 
            this.VIDlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VIDlabel.AutoSize = true;
            this.VIDlabel.Location = new System.Drawing.Point(3, 25);
            this.VIDlabel.Margin = new System.Windows.Forms.Padding(3);
            this.VIDlabel.Name = "VIDlabel";
            this.VIDlabel.Size = new System.Drawing.Size(43, 13);
            this.VIDlabel.TabIndex = 2;
            this.VIDlabel.Text = "Voltage";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelPstates.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(94, 9);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(158, 0);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // CLKlabel
            // 
            this.CLKlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CLKlabel.AutoSize = true;
            this.CLKlabel.Location = new System.Drawing.Point(3, 48);
            this.CLKlabel.Margin = new System.Windows.Forms.Padding(3);
            this.CLKlabel.Name = "CLKlabel";
            this.CLKlabel.Size = new System.Drawing.Size(36, 13);
            this.CLKlabel.TabIndex = 4;
            this.CLKlabel.Text = "clock:";
            // 
            // checkBox_Penable
            // 
            this.checkBox_Penable.AutoSize = true;
            this.checkBox_Penable.Location = new System.Drawing.Point(3, 88);
            this.checkBox_Penable.MinimumSize = new System.Drawing.Size(0, 20);
            this.checkBox_Penable.Name = "checkBox_Penable";
            this.checkBox_Penable.Size = new System.Drawing.Size(88, 20);
            this.checkBox_Penable.TabIndex = 8;
            this.checkBox_Penable.Text = "Pstate active";
            this.checkBox_Penable.UseVisualStyleBackColor = true;
            this.checkBox_Penable.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pllfreq
            // 
            this.pllfreq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pllfreq.AutoSize = true;
            this.pllfreq.Location = new System.Drawing.Point(3, 68);
            this.pllfreq.Margin = new System.Windows.Forms.Padding(3);
            this.pllfreq.Name = "pllfreq";
            this.pllfreq.Size = new System.Drawing.Size(28, 13);
            this.pllfreq.TabIndex = 7;
            this.pllfreq.Text = "Freq";
            this.pllfreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // freqvalue
            // 
            this.freqvalue.AutoSize = true;
            this.freqvalue.Location = new System.Drawing.Point(97, 68);
            this.freqvalue.Margin = new System.Windows.Forms.Padding(3);
            this.freqvalue.Name = "freqvalue";
            this.freqvalue.Size = new System.Drawing.Size(53, 13);
            this.freqvalue.TabIndex = 9;
            this.freqvalue.Text = "1000MHz";
            this.freqvalue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clockvalue
            // 
            this.clockvalue.AutoSize = true;
            this.clockvalue.Location = new System.Drawing.Point(97, 48);
            this.clockvalue.Margin = new System.Windows.Forms.Padding(3);
            this.clockvalue.Name = "clockvalue";
            this.clockvalue.Size = new System.Drawing.Size(47, 13);
            this.clockvalue.TabIndex = 10;
            this.clockvalue.Text = "100MHz";
            // 
            // PStateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelPstates);
            this.Name = "PStateControl";
            this.Size = new System.Drawing.Size(237, 146);
            ((System.ComponentModel.ISupportInitialize)(this.VidNumericUpDown)).EndInit();
            this.tableLayoutPanelPstates.ResumeLayout(false);
            this.tableLayoutPanelPstates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Cofstate;
        private System.Windows.Forms.Label pllfreq;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPstates;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label VIDlabel;
		private System.Windows.Forms.Label CLKlabel;
        private System.Windows.Forms.NumericUpDown VidNumericUpDown;
        private System.Windows.Forms.CheckBox checkBox_Penable;
        private System.Windows.Forms.Label freqvalue;
        private System.Windows.Forms.Label clockvalue;
	}
}
