namespace FusionTweaker
{
    partial class StatusControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.refreshButton = new System.Windows.Forms.Button();
            this.Reg64CPU = new System.Windows.Forms.Label();
            this.PCIDevices = new System.Windows.Forms.Label();
            this.Reg32NB = new System.Windows.Forms.Label();
            this.RegLabel64CPU = new System.Windows.Forms.Label();
            this.RegLabel32NB = new System.Windows.Forms.Label();
            this.PCIDevicesLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelStatus = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.AutoSize = true;
            this.refreshButton.Image = global::FusionTweaker.Properties.Resources.refresh;
            this.refreshButton.Location = new System.Drawing.Point(165, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.refreshButton.Size = new System.Drawing.Size(90, 27);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.refreshButton, "Load the current settings directly from the CPU registers.");
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // Reg64CPU
            // 
            this.Reg64CPU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Reg64CPU.AutoSize = true;
            this.Reg64CPU.Location = new System.Drawing.Point(37, 10);
            this.Reg64CPU.Name = "Reg64CPU";
            this.Reg64CPU.Size = new System.Drawing.Size(28, 13);
            this.Reg64CPU.TabIndex = 7;
            this.Reg64CPU.Text = "Freq";
            this.Reg64CPU.Click += new System.EventHandler(this.Reg64CPU_Click);
            // 
            // PCIDevices
            // 
            this.PCIDevices.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PCIDevices.AutoSize = true;
            this.PCIDevices.Location = new System.Drawing.Point(37, 46);
            this.PCIDevices.Name = "PCIDevices";
            this.PCIDevices.Size = new System.Drawing.Size(28, 13);
            this.PCIDevices.TabIndex = 7;
            this.PCIDevices.Text = "Freq";
            // 
            // Reg32NB
            // 
            this.Reg32NB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Reg32NB.AutoSize = true;
            this.Reg32NB.Location = new System.Drawing.Point(37, 33);
            this.Reg32NB.Name = "Reg32NB";
            this.Reg32NB.Size = new System.Drawing.Size(28, 13);
            this.Reg32NB.TabIndex = 7;
            this.Reg32NB.Text = "Freq";
            // 
            // RegLabel64CPU
            // 
            this.RegLabel64CPU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RegLabel64CPU.AutoSize = true;
            this.RegLabel64CPU.Location = new System.Drawing.Point(3, 10);
            this.RegLabel64CPU.Name = "RegLabel64CPU";
            this.RegLabel64CPU.Size = new System.Drawing.Size(28, 13);
            this.RegLabel64CPU.TabIndex = 7;
            this.RegLabel64CPU.Text = "Freq";
            // 
            // RegLabel32NB
            // 
            this.RegLabel32NB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RegLabel32NB.AutoSize = true;
            this.RegLabel32NB.Location = new System.Drawing.Point(3, 33);
            this.RegLabel32NB.Name = "RegLabel32NB";
            this.RegLabel32NB.Size = new System.Drawing.Size(28, 13);
            this.RegLabel32NB.TabIndex = 7;
            this.RegLabel32NB.Text = "Freq";
            // 
            // PCIDevicesLabel
            // 
            this.PCIDevicesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PCIDevicesLabel.AutoSize = true;
            this.PCIDevicesLabel.Location = new System.Drawing.Point(3, 46);
            this.PCIDevicesLabel.Name = "PCIDevicesLabel";
            this.PCIDevicesLabel.Size = new System.Drawing.Size(28, 13);
            this.PCIDevicesLabel.TabIndex = 7;
            this.PCIDevicesLabel.Text = "Freq";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 30000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 500;
            // 
            // tableLayoutPanelStatus
            // 
            this.tableLayoutPanelStatus.AutoSize = true;
            this.tableLayoutPanelStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelStatus.ColumnCount = 3;
            this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStatus.Controls.Add(this.Reg64CPU, 1, 0);
            this.tableLayoutPanelStatus.Controls.Add(this.Reg32NB, 1, 1);
            this.tableLayoutPanelStatus.Controls.Add(this.RegLabel64CPU, 0, 0);
            this.tableLayoutPanelStatus.Controls.Add(this.RegLabel32NB, 0, 1);
            this.tableLayoutPanelStatus.Controls.Add(this.PCIDevicesLabel, 0, 2);
            this.tableLayoutPanelStatus.Controls.Add(this.PCIDevices, 1, 2);
            this.tableLayoutPanelStatus.Controls.Add(this.refreshButton, 2, 0);
            this.tableLayoutPanelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelStatus.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelStatus.Name = "tableLayoutPanelStatus";
            this.tableLayoutPanelStatus.RowCount = 3;
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelStatus.Size = new System.Drawing.Size(258, 59);
            this.tableLayoutPanelStatus.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(90, 8);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(254, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // StatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelStatus);
            this.Name = "StatusControl";
            this.Size = new System.Drawing.Size(258, 73);
            this.tableLayoutPanelStatus.ResumeLayout(false);
            this.tableLayoutPanelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label Reg64CPU;
        //Brazos merge
		private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label PCIDevices;
        private System.Windows.Forms.Label Reg32NB;
        private System.Windows.Forms.Label RegLabel64CPU;
        private System.Windows.Forms.Label RegLabel32NB;
        private System.Windows.Forms.Label PCIDevicesLabel;
    }
}
