namespace WFA
{
    partial class aplicationForm
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
            this.networkConnectionTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewNetworkAdapter = new System.Windows.Forms.DataGridView();
            this.contextMenuStripTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsInnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsOuterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proxyGroupBox = new System.Windows.Forms.GroupBox();
            this.proxyButton = new System.Windows.Forms.Button();
            this.networkTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.outerNetworkButton = new System.Windows.Forms.Button();
            this.innerNetworkButton = new System.Windows.Forms.Button();
            this.clearSelectionButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.innerNetworkStatusPanel = new System.Windows.Forms.Panel();
            this.innerNetworkStatusLabel = new System.Windows.Forms.Label();
            this.outerNetworkStatusLabel = new System.Windows.Forms.Label();
            this.outerNetworkStatusPanel = new System.Windows.Forms.Panel();
            this.proxyStatusLabel = new System.Windows.Forms.Label();
            this.proxyStatusPanel = new System.Windows.Forms.Panel();
            this.checkBoxHideVirtualAdapter = new System.Windows.Forms.CheckBox();
            this.networkConnectionTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNetworkAdapter)).BeginInit();
            this.contextMenuStripTable.SuspendLayout();
            this.proxyGroupBox.SuspendLayout();
            this.networkTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // networkConnectionTabControl
            // 
            this.networkConnectionTabControl.Controls.Add(this.tabPage1);
            this.networkConnectionTabControl.Controls.Add(this.tabPage2);
            this.networkConnectionTabControl.Location = new System.Drawing.Point(12, 12);
            this.networkConnectionTabControl.Name = "networkConnectionTabControl";
            this.networkConnectionTabControl.SelectedIndex = 0;
            this.networkConnectionTabControl.Size = new System.Drawing.Size(688, 534);
            this.networkConnectionTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxHideVirtualAdapter);
            this.tabPage1.Controls.Add(this.dataGridViewNetworkAdapter);
            this.tabPage1.Controls.Add(this.proxyGroupBox);
            this.tabPage1.Controls.Add(this.networkTypeGroupBox);
            this.tabPage1.Controls.Add(this.clearSelectionButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(680, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Network Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewNetworkAdapter
            // 
            this.dataGridViewNetworkAdapter.AllowUserToAddRows = false;
            this.dataGridViewNetworkAdapter.AllowUserToDeleteRows = false;
            this.dataGridViewNetworkAdapter.AllowUserToOrderColumns = true;
            this.dataGridViewNetworkAdapter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNetworkAdapter.ContextMenuStrip = this.contextMenuStripTable;
            this.dataGridViewNetworkAdapter.Location = new System.Drawing.Point(6, 120);
            this.dataGridViewNetworkAdapter.Name = "dataGridViewNetworkAdapter";
            this.dataGridViewNetworkAdapter.ReadOnly = true;
            this.dataGridViewNetworkAdapter.Size = new System.Drawing.Size(667, 353);
            this.dataGridViewNetworkAdapter.TabIndex = 5;
            this.dataGridViewNetworkAdapter.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.networkAdapterDataGridView_CellContextMenuStripNeeded);
            // 
            // contextMenuStripTable
            // 
            this.contextMenuStripTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsInnerToolStripMenuItem,
            this.setAsOuterToolStripMenuItem});
            this.contextMenuStripTable.Name = "contextMenuStripTable";
            this.contextMenuStripTable.Size = new System.Drawing.Size(138, 48);
            // 
            // setAsInnerToolStripMenuItem
            // 
            this.setAsInnerToolStripMenuItem.Name = "setAsInnerToolStripMenuItem";
            this.setAsInnerToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.setAsInnerToolStripMenuItem.Text = "Set as Inner";
            this.setAsInnerToolStripMenuItem.Click += new System.EventHandler(this.setAsInnerToolStripMenuItem_Click);
            // 
            // setAsOuterToolStripMenuItem
            // 
            this.setAsOuterToolStripMenuItem.Name = "setAsOuterToolStripMenuItem";
            this.setAsOuterToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.setAsOuterToolStripMenuItem.Text = "Set as Outer";
            this.setAsOuterToolStripMenuItem.Click += new System.EventHandler(this.setAsOuterToolStripMenuItem_Click);
            // 
            // proxyGroupBox
            // 
            this.proxyGroupBox.Controls.Add(this.proxyButton);
            this.proxyGroupBox.Location = new System.Drawing.Point(210, 6);
            this.proxyGroupBox.Name = "proxyGroupBox";
            this.proxyGroupBox.Size = new System.Drawing.Size(197, 108);
            this.proxyGroupBox.TabIndex = 3;
            this.proxyGroupBox.TabStop = false;
            this.proxyGroupBox.Text = "Proxy:";
            // 
            // proxyButton
            // 
            this.proxyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.proxyButton.Location = new System.Drawing.Point(7, 20);
            this.proxyButton.Name = "proxyButton";
            this.proxyButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.proxyButton.Size = new System.Drawing.Size(184, 34);
            this.proxyButton.TabIndex = 0;
            this.proxyButton.Text = "Proxy";
            this.proxyButton.UseVisualStyleBackColor = true;
            this.proxyButton.Click += new System.EventHandler(this.proxyButton_Click);
            // 
            // networkTypeGroupBox
            // 
            this.networkTypeGroupBox.Controls.Add(this.outerNetworkButton);
            this.networkTypeGroupBox.Controls.Add(this.innerNetworkButton);
            this.networkTypeGroupBox.Location = new System.Drawing.Point(7, 4);
            this.networkTypeGroupBox.Name = "networkTypeGroupBox";
            this.networkTypeGroupBox.Size = new System.Drawing.Size(197, 110);
            this.networkTypeGroupBox.TabIndex = 2;
            this.networkTypeGroupBox.TabStop = false;
            this.networkTypeGroupBox.Text = "Network Type";
            // 
            // outerNetworkButton
            // 
            this.outerNetworkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outerNetworkButton.Location = new System.Drawing.Point(7, 60);
            this.outerNetworkButton.Name = "outerNetworkButton";
            this.outerNetworkButton.Size = new System.Drawing.Size(184, 37);
            this.outerNetworkButton.TabIndex = 1;
            this.outerNetworkButton.Text = "Outer Network";
            this.outerNetworkButton.UseVisualStyleBackColor = true;
            this.outerNetworkButton.Click += new System.EventHandler(this.outerNetworkButton_Click);
            // 
            // innerNetworkButton
            // 
            this.innerNetworkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.innerNetworkButton.Location = new System.Drawing.Point(7, 20);
            this.innerNetworkButton.Name = "innerNetworkButton";
            this.innerNetworkButton.Size = new System.Drawing.Size(184, 34);
            this.innerNetworkButton.TabIndex = 0;
            this.innerNetworkButton.Text = "Inner Network";
            this.innerNetworkButton.UseVisualStyleBackColor = true;
            this.innerNetworkButton.Click += new System.EventHandler(this.innerNetworkButton_Click);
            // 
            // clearSelectionButton
            // 
            this.clearSelectionButton.Location = new System.Drawing.Point(573, 479);
            this.clearSelectionButton.Name = "clearSelectionButton";
            this.clearSelectionButton.Size = new System.Drawing.Size(100, 23);
            this.clearSelectionButton.TabIndex = 1;
            this.clearSelectionButton.Text = "Refresh Table";
            this.clearSelectionButton.UseVisualStyleBackColor = true;
            this.clearSelectionButton.Click += new System.EventHandler(this.clearSelectionButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(680, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // innerNetworkStatusPanel
            // 
            this.innerNetworkStatusPanel.Location = new System.Drawing.Point(12, 569);
            this.innerNetworkStatusPanel.Name = "innerNetworkStatusPanel";
            this.innerNetworkStatusPanel.Size = new System.Drawing.Size(111, 21);
            this.innerNetworkStatusPanel.TabIndex = 1;
            // 
            // innerNetworkStatusLabel
            // 
            this.innerNetworkStatusLabel.AutoSize = true;
            this.innerNetworkStatusLabel.Location = new System.Drawing.Point(13, 553);
            this.innerNetworkStatusLabel.Name = "innerNetworkStatusLabel";
            this.innerNetworkStatusLabel.Size = new System.Drawing.Size(110, 13);
            this.innerNetworkStatusLabel.TabIndex = 2;
            this.innerNetworkStatusLabel.Text = "Inner Network Status:";
            // 
            // outerNetworkStatusLabel
            // 
            this.outerNetworkStatusLabel.AutoSize = true;
            this.outerNetworkStatusLabel.Location = new System.Drawing.Point(129, 553);
            this.outerNetworkStatusLabel.Name = "outerNetworkStatusLabel";
            this.outerNetworkStatusLabel.Size = new System.Drawing.Size(112, 13);
            this.outerNetworkStatusLabel.TabIndex = 3;
            this.outerNetworkStatusLabel.Text = "Outer Network Status:";
            // 
            // outerNetworkStatusPanel
            // 
            this.outerNetworkStatusPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.outerNetworkStatusPanel.Location = new System.Drawing.Point(132, 569);
            this.outerNetworkStatusPanel.Name = "outerNetworkStatusPanel";
            this.outerNetworkStatusPanel.Size = new System.Drawing.Size(109, 21);
            this.outerNetworkStatusPanel.TabIndex = 2;
            // 
            // proxyStatusLabel
            // 
            this.proxyStatusLabel.AutoSize = true;
            this.proxyStatusLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.proxyStatusLabel.Location = new System.Drawing.Point(247, 553);
            this.proxyStatusLabel.Name = "proxyStatusLabel";
            this.proxyStatusLabel.Size = new System.Drawing.Size(84, 13);
            this.proxyStatusLabel.TabIndex = 4;
            this.proxyStatusLabel.Text = "Proxy Status: (?)";
            this.proxyStatusLabel.Click += new System.EventHandler(this.proxyStatusLabel_Click);
            // 
            // proxyStatusPanel
            // 
            this.proxyStatusPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.proxyStatusPanel.Location = new System.Drawing.Point(250, 569);
            this.proxyStatusPanel.Name = "proxyStatusPanel";
            this.proxyStatusPanel.Size = new System.Drawing.Size(109, 21);
            this.proxyStatusPanel.TabIndex = 3;
            // 
            // checkBoxHideVirtualAdapter
            // 
            this.checkBoxHideVirtualAdapter.AutoSize = true;
            this.checkBoxHideVirtualAdapter.Location = new System.Drawing.Point(444, 483);
            this.checkBoxHideVirtualAdapter.Name = "checkBoxHideVirtualAdapter";
            this.checkBoxHideVirtualAdapter.Size = new System.Drawing.Size(123, 17);
            this.checkBoxHideVirtualAdapter.TabIndex = 6;
            this.checkBoxHideVirtualAdapter.Text = "Hide virtual adapters";
            this.checkBoxHideVirtualAdapter.UseVisualStyleBackColor = true;
            this.checkBoxHideVirtualAdapter.CheckedChanged += new System.EventHandler(this.checkBoxHideVirtualAdapter_CheckedChanged);
            // 
            // aplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 602);
            this.Controls.Add(this.proxyStatusPanel);
            this.Controls.Add(this.proxyStatusLabel);
            this.Controls.Add(this.outerNetworkStatusPanel);
            this.Controls.Add(this.outerNetworkStatusLabel);
            this.Controls.Add(this.innerNetworkStatusLabel);
            this.Controls.Add(this.innerNetworkStatusPanel);
            this.Controls.Add(this.networkConnectionTabControl);
            this.Name = "aplicationForm";
            this.Text = "My Help Programm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.aplicationForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.networkConnectionTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNetworkAdapter)).EndInit();
            this.contextMenuStripTable.ResumeLayout(false);
            this.proxyGroupBox.ResumeLayout(false);
            this.networkTypeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl networkConnectionTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button clearSelectionButton;
        private System.Windows.Forms.GroupBox networkTypeGroupBox;
        private System.Windows.Forms.Button outerNetworkButton;
        private System.Windows.Forms.Button innerNetworkButton;
        private System.Windows.Forms.Panel innerNetworkStatusPanel;
        private System.Windows.Forms.Label innerNetworkStatusLabel;
        private System.Windows.Forms.Label outerNetworkStatusLabel;
        private System.Windows.Forms.Panel outerNetworkStatusPanel;
        private System.Windows.Forms.Label proxyStatusLabel;
        private System.Windows.Forms.Panel proxyStatusPanel;
        private System.Windows.Forms.GroupBox proxyGroupBox;
        private System.Windows.Forms.Button proxyButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTable;
        private System.Windows.Forms.ToolStripMenuItem setAsInnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsOuterToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewNetworkAdapter;
        private System.Windows.Forms.CheckBox checkBoxHideVirtualAdapter;
    }
}

