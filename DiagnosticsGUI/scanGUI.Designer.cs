namespace DiagnosticsGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.exitButton = new System.Windows.Forms.Button();
            this.scanButton = new System.Windows.Forms.Button();
            this.forumsButton = new System.Windows.Forms.Button();
            this.visualRedistButton = new System.Windows.Forms.Button();
            this.dotNETinstallButton = new System.Windows.Forms.Button();
            this.driverDownloadButton = new System.Windows.Forms.Button();
            this.repairDragonButton = new System.Windows.Forms.Button();
            this.repairSKSEButton = new System.Windows.Forms.Button();
            this.repairInstallationButton = new System.Windows.Forms.Button();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.statusList = new System.Windows.Forms.ListView();
            this.requirementColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aboutLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(13, 466);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 30);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(13, 394);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(100, 30);
            this.scanButton.TabIndex = 2;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // forumsButton
            // 
            this.forumsButton.Location = new System.Drawing.Point(13, 430);
            this.forumsButton.Name = "forumsButton";
            this.forumsButton.Size = new System.Drawing.Size(100, 30);
            this.forumsButton.TabIndex = 4;
            this.forumsButton.Text = "Forums";
            this.forumsButton.UseVisualStyleBackColor = true;
            this.forumsButton.Click += new System.EventHandler(this.forumsButton_Click);
            // 
            // visualRedistButton
            // 
            this.visualRedistButton.Location = new System.Drawing.Point(119, 466);
            this.visualRedistButton.Name = "visualRedistButton";
            this.visualRedistButton.Size = new System.Drawing.Size(250, 30);
            this.visualRedistButton.TabIndex = 6;
            this.visualRedistButton.Text = "Download Visual Studio 2012 x86 Redistributable";
            this.visualRedistButton.UseVisualStyleBackColor = true;
            this.visualRedistButton.Click += new System.EventHandler(this.visualRedistButton_Click);
            // 
            // dotNETinstallButton
            // 
            this.dotNETinstallButton.Location = new System.Drawing.Point(119, 430);
            this.dotNETinstallButton.Name = "dotNETinstallButton";
            this.dotNETinstallButton.Size = new System.Drawing.Size(250, 30);
            this.dotNETinstallButton.TabIndex = 7;
            this.dotNETinstallButton.Text = "Install .NET Framework 4.5";
            this.dotNETinstallButton.UseVisualStyleBackColor = true;
            this.dotNETinstallButton.Click += new System.EventHandler(this.dotNETinstallButton_Click);
            // 
            // driverDownloadButton
            // 
            this.driverDownloadButton.Location = new System.Drawing.Point(119, 394);
            this.driverDownloadButton.Name = "driverDownloadButton";
            this.driverDownloadButton.Size = new System.Drawing.Size(250, 30);
            this.driverDownloadButton.TabIndex = 8;
            this.driverDownloadButton.Text = "Download appropriate drivers";
            this.driverDownloadButton.UseVisualStyleBackColor = true;
            this.driverDownloadButton.Click += new System.EventHandler(this.driverDownloadButton_Click);
            // 
            // repairDragonButton
            // 
            this.repairDragonButton.Location = new System.Drawing.Point(375, 466);
            this.repairDragonButton.Name = "repairDragonButton";
            this.repairDragonButton.Size = new System.Drawing.Size(250, 30);
            this.repairDragonButton.TabIndex = 9;
            this.repairDragonButton.Text = "Repair ScriptDragon";
            this.repairDragonButton.UseVisualStyleBackColor = true;
            // 
            // repairSKSEButton
            // 
            this.repairSKSEButton.Location = new System.Drawing.Point(375, 430);
            this.repairSKSEButton.Name = "repairSKSEButton";
            this.repairSKSEButton.Size = new System.Drawing.Size(250, 30);
            this.repairSKSEButton.TabIndex = 10;
            this.repairSKSEButton.Text = "Repair SKSE installation";
            this.repairSKSEButton.UseVisualStyleBackColor = true;
            // 
            // repairInstallationButton
            // 
            this.repairInstallationButton.Location = new System.Drawing.Point(375, 394);
            this.repairInstallationButton.Name = "repairInstallationButton";
            this.repairInstallationButton.Size = new System.Drawing.Size(250, 30);
            this.repairInstallationButton.TabIndex = 11;
            this.repairInstallationButton.Text = "Attempt to repair installation";
            this.repairInstallationButton.UseVisualStyleBackColor = true;
            this.repairInstallationButton.MouseCaptureChanged += new System.EventHandler(this.repairInstallationButton_Click);
            // 
            // versionTextBox
            // 
            this.versionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.versionTextBox.Location = new System.Drawing.Point(13, 12);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.ReadOnly = true;
            this.versionTextBox.Size = new System.Drawing.Size(186, 13);
            this.versionTextBox.TabIndex = 12;
            this.versionTextBox.Text = "Skyrim Online Diagnostics Tool - v1.4";
            // 
            // statusList
            // 
            this.statusList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.requirementColumn,
            this.statusColumn});
            this.statusList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.statusList.Location = new System.Drawing.Point(13, 32);
            this.statusList.Name = "statusList";
            this.statusList.Size = new System.Drawing.Size(625, 356);
            this.statusList.TabIndex = 13;
            this.statusList.UseCompatibleStateImageBehavior = false;
            this.statusList.SelectedIndexChanged += new System.EventHandler(this.statusList_SelectedIndexChanged);
            // 
            // requirementColumn
            // 
            this.requirementColumn.Text = "Requirement";
            this.requirementColumn.Width = 140;
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 350;
            // 
            // aboutLink
            // 
            this.aboutLink.AutoSize = true;
            this.aboutLink.Location = new System.Drawing.Point(603, 12);
            this.aboutLink.Name = "aboutLink";
            this.aboutLink.Size = new System.Drawing.Size(35, 13);
            this.aboutLink.TabIndex = 14;
            this.aboutLink.TabStop = true;
            this.aboutLink.Text = "About";
            this.aboutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 508);
            this.Controls.Add(this.aboutLink);
            this.Controls.Add(this.statusList);
            this.Controls.Add(this.versionTextBox);
            this.Controls.Add(this.repairInstallationButton);
            this.Controls.Add(this.repairSKSEButton);
            this.Controls.Add(this.repairDragonButton);
            this.Controls.Add(this.driverDownloadButton);
            this.Controls.Add(this.dotNETinstallButton);
            this.Controls.Add(this.visualRedistButton);
            this.Controls.Add(this.forumsButton);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Skyrim Online Diagnostics Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button forumsButton;
        private System.Windows.Forms.Button visualRedistButton;
        private System.Windows.Forms.Button dotNETinstallButton;
        private System.Windows.Forms.Button driverDownloadButton;
        private System.Windows.Forms.Button repairDragonButton;
        private System.Windows.Forms.Button repairSKSEButton;
        private System.Windows.Forms.Button repairInstallationButton;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.ListView statusList;
        private System.Windows.Forms.ColumnHeader statusColumn;
        private System.Windows.Forms.ColumnHeader requirementColumn;
        private System.Windows.Forms.LinkLabel aboutLink;
    }
}

