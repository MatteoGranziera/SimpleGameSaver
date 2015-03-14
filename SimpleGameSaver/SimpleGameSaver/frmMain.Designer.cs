namespace SimpleGameSaver
{
    partial class frmMain
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
            this.btnBackupSaves = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbSaveOptions = new System.Windows.Forms.GroupBox();
            this.cmbUsersSave = new System.Windows.Forms.ComboBox();
            this.lblUserSave = new System.Windows.Forms.Label();
            this.ckbSaveToCloud = new System.Windows.Forms.CheckBox();
            this.ckbSaveToFolder = new System.Windows.Forms.CheckBox();
            this.grbRestoreOptions = new System.Windows.Forms.GroupBox();
            this.cmbUserRestore = new System.Windows.Forms.ComboBox();
            this.lblUserRestore = new System.Windows.Forms.Label();
            this.ckbRestoreFromCloud = new System.Windows.Forms.CheckBox();
            this.ckeRestoreFromFolder = new System.Windows.Forms.CheckBox();
            this.btnRestoreSaves = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSetUp = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.grbSaveOptions.SuspendLayout();
            this.grbRestoreOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackupSaves
            // 
            this.btnBackupSaves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackupSaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupSaves.Location = new System.Drawing.Point(6, 109);
            this.btnBackupSaves.Name = "btnBackupSaves";
            this.btnBackupSaves.Size = new System.Drawing.Size(228, 75);
            this.btnBackupSaves.TabIndex = 0;
            this.btnBackupSaves.Text = "Backup Savegames";
            this.btnBackupSaves.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // grbSaveOptions
            // 
            this.grbSaveOptions.Controls.Add(this.cmbUsersSave);
            this.grbSaveOptions.Controls.Add(this.lblUserSave);
            this.grbSaveOptions.Controls.Add(this.ckbSaveToCloud);
            this.grbSaveOptions.Controls.Add(this.ckbSaveToFolder);
            this.grbSaveOptions.Controls.Add(this.btnBackupSaves);
            this.grbSaveOptions.Location = new System.Drawing.Point(13, 28);
            this.grbSaveOptions.Name = "grbSaveOptions";
            this.grbSaveOptions.Size = new System.Drawing.Size(240, 190);
            this.grbSaveOptions.TabIndex = 4;
            this.grbSaveOptions.TabStop = false;
            this.grbSaveOptions.Text = "Backup Options";
            // 
            // cmbUsersSave
            // 
            this.cmbUsersSave.FormattingEnabled = true;
            this.cmbUsersSave.Location = new System.Drawing.Point(44, 65);
            this.cmbUsersSave.Name = "cmbUsersSave";
            this.cmbUsersSave.Size = new System.Drawing.Size(166, 21);
            this.cmbUsersSave.TabIndex = 3;
            this.cmbUsersSave.TextChanged += new System.EventHandler(this.cmbUsersSave_TextChanged);
            // 
            // lblUserSave
            // 
            this.lblUserSave.AutoSize = true;
            this.lblUserSave.Location = new System.Drawing.Point(6, 68);
            this.lblUserSave.Name = "lblUserSave";
            this.lblUserSave.Size = new System.Drawing.Size(32, 13);
            this.lblUserSave.TabIndex = 2;
            this.lblUserSave.Text = "User:";
            // 
            // ckbSaveToCloud
            // 
            this.ckbSaveToCloud.AutoSize = true;
            this.ckbSaveToCloud.Location = new System.Drawing.Point(7, 43);
            this.ckbSaveToCloud.Name = "ckbSaveToCloud";
            this.ckbSaveToCloud.Size = new System.Drawing.Size(134, 17);
            this.ckbSaveToCloud.TabIndex = 1;
            this.ckbSaveToCloud.Text = "Copy to cloud directory";
            this.ckbSaveToCloud.UseVisualStyleBackColor = true;
            // 
            // ckbSaveToFolder
            // 
            this.ckbSaveToFolder.AutoSize = true;
            this.ckbSaveToFolder.Location = new System.Drawing.Point(6, 19);
            this.ckbSaveToFolder.Name = "ckbSaveToFolder";
            this.ckbSaveToFolder.Size = new System.Drawing.Size(202, 17);
            this.ckbSaveToFolder.TabIndex = 0;
            this.ckbSaveToFolder.Text = "Copy to SimpleGameSaver\'s directory";
            this.ckbSaveToFolder.UseVisualStyleBackColor = true;
            // 
            // grbRestoreOptions
            // 
            this.grbRestoreOptions.Controls.Add(this.cmbUserRestore);
            this.grbRestoreOptions.Controls.Add(this.lblUserRestore);
            this.grbRestoreOptions.Controls.Add(this.ckbRestoreFromCloud);
            this.grbRestoreOptions.Controls.Add(this.ckeRestoreFromFolder);
            this.grbRestoreOptions.Controls.Add(this.btnRestoreSaves);
            this.grbRestoreOptions.Location = new System.Drawing.Point(259, 28);
            this.grbRestoreOptions.Name = "grbRestoreOptions";
            this.grbRestoreOptions.Size = new System.Drawing.Size(238, 190);
            this.grbRestoreOptions.TabIndex = 5;
            this.grbRestoreOptions.TabStop = false;
            this.grbRestoreOptions.Text = "Restore Options";
            // 
            // cmbUserRestore
            // 
            this.cmbUserRestore.FormattingEnabled = true;
            this.cmbUserRestore.Location = new System.Drawing.Point(44, 65);
            this.cmbUserRestore.Name = "cmbUserRestore";
            this.cmbUserRestore.Size = new System.Drawing.Size(166, 21);
            this.cmbUserRestore.TabIndex = 4;
            this.cmbUserRestore.TextChanged += new System.EventHandler(this.cmbUserRestore_TextChanged);
            // 
            // lblUserRestore
            // 
            this.lblUserRestore.AutoSize = true;
            this.lblUserRestore.Location = new System.Drawing.Point(6, 68);
            this.lblUserRestore.Name = "lblUserRestore";
            this.lblUserRestore.Size = new System.Drawing.Size(32, 13);
            this.lblUserRestore.TabIndex = 3;
            this.lblUserRestore.Text = "User:";
            // 
            // ckbRestoreFromCloud
            // 
            this.ckbRestoreFromCloud.AutoSize = true;
            this.ckbRestoreFromCloud.Location = new System.Drawing.Point(7, 43);
            this.ckbRestoreFromCloud.Name = "ckbRestoreFromCloud";
            this.ckbRestoreFromCloud.Size = new System.Drawing.Size(158, 17);
            this.ckbRestoreFromCloud.TabIndex = 1;
            this.ckbRestoreFromCloud.Text = "Restore from cloud directory";
            this.ckbRestoreFromCloud.UseVisualStyleBackColor = true;
            // 
            // ckeRestoreFromFolder
            // 
            this.ckeRestoreFromFolder.AutoSize = true;
            this.ckeRestoreFromFolder.Location = new System.Drawing.Point(6, 19);
            this.ckeRestoreFromFolder.Name = "ckeRestoreFromFolder";
            this.ckeRestoreFromFolder.Size = new System.Drawing.Size(226, 17);
            this.ckeRestoreFromFolder.TabIndex = 0;
            this.ckeRestoreFromFolder.Text = "Restore from SimpleGameSaver\'s directory";
            this.ckeRestoreFromFolder.UseVisualStyleBackColor = true;
            // 
            // btnRestoreSaves
            // 
            this.btnRestoreSaves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreSaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoreSaves.Location = new System.Drawing.Point(6, 109);
            this.btnRestoreSaves.Name = "btnRestoreSaves";
            this.btnRestoreSaves.Size = new System.Drawing.Size(226, 75);
            this.btnRestoreSaves.TabIndex = 0;
            this.btnRestoreSaves.Text = "Restore Savegames";
            this.btnRestoreSaves.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 224);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 35);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSetUp
            // 
            this.btnSetUp.Location = new System.Drawing.Point(102, 224);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(128, 35);
            this.btnSetUp.TabIndex = 7;
            this.btnSetUp.Text = "Setup Configuration";
            this.btnSetUp.UseVisualStyleBackColor = true;
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 271);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grbRestoreOptions);
            this.Controls.Add(this.grbSaveOptions);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Simple Game Saver";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbSaveOptions.ResumeLayout(false);
            this.grbSaveOptions.PerformLayout();
            this.grbRestoreOptions.ResumeLayout(false);
            this.grbRestoreOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackupSaves;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox grbSaveOptions;
        private System.Windows.Forms.CheckBox ckbSaveToCloud;
        private System.Windows.Forms.CheckBox ckbSaveToFolder;
        private System.Windows.Forms.GroupBox grbRestoreOptions;
        private System.Windows.Forms.CheckBox ckbRestoreFromCloud;
        private System.Windows.Forms.CheckBox ckeRestoreFromFolder;
        private System.Windows.Forms.Button btnRestoreSaves;
        private System.Windows.Forms.ComboBox cmbUsersSave;
        private System.Windows.Forms.Label lblUserSave;
        private System.Windows.Forms.ComboBox cmbUserRestore;
        private System.Windows.Forms.Label lblUserRestore;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSetUp;
    }
}