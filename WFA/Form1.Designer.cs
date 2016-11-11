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
            this.networkConnectionTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.proxyGroupBox = new System.Windows.Forms.GroupBox();
            this.proxyButton = new System.Windows.Forms.Button();
            this.networkTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.outerNetworkButton = new System.Windows.Forms.Button();
            this.innerNetworkButton = new System.Windows.Forms.Button();
            this.clearSelectionButton = new System.Windows.Forms.Button();
            this.networkAdapterDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.innerNetworkStatusPanel = new System.Windows.Forms.Panel();
            this.innerNetworkStatusLabel = new System.Windows.Forms.Label();
            this.outerNetworkStatusLabel = new System.Windows.Forms.Label();
            this.outerNetworkStatusPanel = new System.Windows.Forms.Panel();
            this.proxyStatusLabel = new System.Windows.Forms.Label();
            this.proxyStatusPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.networkConnectionTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.proxyGroupBox.SuspendLayout();
            this.networkTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkAdapterDataGridView)).BeginInit();
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
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.proxyGroupBox);
            this.tabPage1.Controls.Add(this.networkTypeGroupBox);
            this.tabPage1.Controls.Add(this.clearSelectionButton);
            this.tabPage1.Controls.Add(this.networkAdapterDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(680, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Network Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // proxyGroupBox
            // 
            this.proxyGroupBox.Controls.Add(this.proxyButton);
            this.proxyGroupBox.Location = new System.Drawing.Point(210, 6);
            this.proxyGroupBox.Name = "proxyGroupBox";
            this.proxyGroupBox.Size = new System.Drawing.Size(197, 110);
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
            // networkAdapterDataGridView
            // 
            this.networkAdapterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.networkAdapterDataGridView.Location = new System.Drawing.Point(3, 120);
            this.networkAdapterDataGridView.Name = "networkAdapterDataGridView";
            this.networkAdapterDataGridView.Size = new System.Drawing.Size(671, 353);
            this.networkAdapterDataGridView.TabIndex = 0;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.proxyGroupBox.ResumeLayout(false);
            this.networkTypeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.networkAdapterDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl networkConnectionTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView networkAdapterDataGridView;
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
        private System.Windows.Forms.Button button1;
    }
}

