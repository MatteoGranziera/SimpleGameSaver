﻿namespace SimpleGameSaver
{
    partial class frmSettings
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
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.grbList = new System.Windows.Forms.GroupBox();
            this.lblActualGame = new System.Windows.Forms.Label();
            this.lblActualGameL = new System.Windows.Forms.Label();
            this.lblActualUserL = new System.Windows.Forms.Label();
            this.btnAddGameFolder = new System.Windows.Forms.Button();
            this.btnAddConfigFolder = new System.Windows.Forms.Button();
            this.lblActualUser = new System.Windows.Forms.Label();
            this.btnSetUser = new System.Windows.Forms.Button();
            this.trvGamesList = new System.Windows.Forms.TreeView();
            this.grbAddUser = new System.Windows.Forms.GroupBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtAddUser = new System.Windows.Forms.TextBox();
            this.grbAddGame = new System.Windows.Forms.GroupBox();
            this.lstGameSugg = new System.Windows.Forms.ListBox();
            this.btnAddGame = new System.Windows.Forms.Button();
            this.txtAddGame = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbDefaultFolders = new System.Windows.Forms.CheckBox();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.grbList.SuspendLayout();
            this.grbAddUser.SuspendLayout();
            this.grbAddGame.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(53, 20);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(140, 21);
            this.cmbUsers.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(15, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User:";
            // 
            // grbList
            // 
            this.grbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbList.Controls.Add(this.btnRemoveSelected);
            this.grbList.Controls.Add(this.lblActualGame);
            this.grbList.Controls.Add(this.lblActualGameL);
            this.grbList.Controls.Add(this.lblActualUserL);
            this.grbList.Controls.Add(this.btnAddGameFolder);
            this.grbList.Controls.Add(this.btnAddConfigFolder);
            this.grbList.Controls.Add(this.lblActualUser);
            this.grbList.Controls.Add(this.btnSetUser);
            this.grbList.Controls.Add(this.trvGamesList);
            this.grbList.Controls.Add(this.lblUser);
            this.grbList.Controls.Add(this.cmbUsers);
            this.grbList.Location = new System.Drawing.Point(170, 27);
            this.grbList.Name = "grbList";
            this.grbList.Size = new System.Drawing.Size(481, 341);
            this.grbList.TabIndex = 2;
            this.grbList.TabStop = false;
            this.grbList.Text = "Actual User";
            // 
            // lblActualGame
            // 
            this.lblActualGame.AutoSize = true;
            this.lblActualGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualGame.Location = new System.Drawing.Point(50, 52);
            this.lblActualGame.Name = "lblActualGame";
            this.lblActualGame.Size = new System.Drawing.Size(39, 17);
            this.lblActualGame.TabIndex = 8;
            this.lblActualGame.Text = "NaN";
            // 
            // lblActualGameL
            // 
            this.lblActualGameL.AutoSize = true;
            this.lblActualGameL.Location = new System.Drawing.Point(10, 54);
            this.lblActualGameL.Name = "lblActualGameL";
            this.lblActualGameL.Size = new System.Drawing.Size(41, 13);
            this.lblActualGameL.TabIndex = 7;
            this.lblActualGameL.Text = "Game: ";
            // 
            // lblActualUserL
            // 
            this.lblActualUserL.AutoSize = true;
            this.lblActualUserL.Location = new System.Drawing.Point(332, 56);
            this.lblActualUserL.Name = "lblActualUserL";
            this.lblActualUserL.Size = new System.Drawing.Size(32, 13);
            this.lblActualUserL.TabIndex = 6;
            this.lblActualUserL.Text = "User:";
            // 
            // btnAddGameFolder
            // 
            this.btnAddGameFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddGameFolder.Location = new System.Drawing.Point(10, 314);
            this.btnAddGameFolder.Name = "btnAddGameFolder";
            this.btnAddGameFolder.Size = new System.Drawing.Size(108, 27);
            this.btnAddGameFolder.TabIndex = 5;
            this.btnAddGameFolder.Text = "Add Save Folder";
            this.btnAddGameFolder.UseVisualStyleBackColor = true;
            this.btnAddGameFolder.Click += new System.EventHandler(this.btnAddGameFolder_Click);
            // 
            // btnAddConfigFolder
            // 
            this.btnAddConfigFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddConfigFolder.Location = new System.Drawing.Point(124, 314);
            this.btnAddConfigFolder.Name = "btnAddConfigFolder";
            this.btnAddConfigFolder.Size = new System.Drawing.Size(104, 27);
            this.btnAddConfigFolder.TabIndex = 4;
            this.btnAddConfigFolder.Text = "Add Config Folder";
            this.btnAddConfigFolder.UseVisualStyleBackColor = true;
            this.btnAddConfigFolder.Click += new System.EventHandler(this.btnAddConfigFolder_Click);
            // 
            // lblActualUser
            // 
            this.lblActualUser.AutoSize = true;
            this.lblActualUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualUser.Location = new System.Drawing.Point(370, 54);
            this.lblActualUser.Name = "lblActualUser";
            this.lblActualUser.Size = new System.Drawing.Size(39, 17);
            this.lblActualUser.TabIndex = 1;
            this.lblActualUser.Text = "NaN";
            // 
            // btnSetUser
            // 
            this.btnSetUser.Location = new System.Drawing.Point(199, 18);
            this.btnSetUser.Name = "btnSetUser";
            this.btnSetUser.Size = new System.Drawing.Size(75, 23);
            this.btnSetUser.TabIndex = 3;
            this.btnSetUser.Text = "Set User";
            this.btnSetUser.UseVisualStyleBackColor = true;
            this.btnSetUser.Click += new System.EventHandler(this.btnSetUser_Click);
            // 
            // trvGamesList
            // 
            this.trvGamesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvGamesList.CheckBoxes = true;
            this.trvGamesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvGamesList.ItemHeight = 18;
            this.trvGamesList.Location = new System.Drawing.Point(10, 77);
            this.trvGamesList.Name = "trvGamesList";
            this.trvGamesList.Size = new System.Drawing.Size(458, 225);
            this.trvGamesList.TabIndex = 0;
            this.trvGamesList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvGamesList_AfterCheck);
            this.trvGamesList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvGamesList_AfterSelect);
            // 
            // grbAddUser
            // 
            this.grbAddUser.Controls.Add(this.btnAddUser);
            this.grbAddUser.Controls.Add(this.txtAddUser);
            this.grbAddUser.Location = new System.Drawing.Point(12, 27);
            this.grbAddUser.Name = "grbAddUser";
            this.grbAddUser.Size = new System.Drawing.Size(152, 80);
            this.grbAddUser.TabIndex = 4;
            this.grbAddUser.TabStop = false;
            this.grbAddUser.Text = "Add User";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(70, 47);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtAddUser
            // 
            this.txtAddUser.Location = new System.Drawing.Point(6, 21);
            this.txtAddUser.Name = "txtAddUser";
            this.txtAddUser.Size = new System.Drawing.Size(139, 20);
            this.txtAddUser.TabIndex = 0;
            // 
            // grbAddGame
            // 
            this.grbAddGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbAddGame.Controls.Add(this.ckbDefaultFolders);
            this.grbAddGame.Controls.Add(this.lstGameSugg);
            this.grbAddGame.Controls.Add(this.btnAddGame);
            this.grbAddGame.Controls.Add(this.txtAddGame);
            this.grbAddGame.Location = new System.Drawing.Point(12, 116);
            this.grbAddGame.Name = "grbAddGame";
            this.grbAddGame.Size = new System.Drawing.Size(152, 252);
            this.grbAddGame.TabIndex = 5;
            this.grbAddGame.TabStop = false;
            this.grbAddGame.Text = "Add Game";
            // 
            // lstGameSugg
            // 
            this.lstGameSugg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGameSugg.FormattingEnabled = true;
            this.lstGameSugg.Location = new System.Drawing.Point(6, 46);
            this.lstGameSugg.Name = "lstGameSugg";
            this.lstGameSugg.Size = new System.Drawing.Size(139, 134);
            this.lstGameSugg.TabIndex = 3;
            // 
            // btnAddGame
            // 
            this.btnAddGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGame.Location = new System.Drawing.Point(70, 223);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(75, 23);
            this.btnAddGame.TabIndex = 2;
            this.btnAddGame.Text = "Add Game";
            this.btnAddGame.UseVisualStyleBackColor = true;
            this.btnAddGame.Click += new System.EventHandler(this.btnAddGame_Click);
            // 
            // txtAddGame
            // 
            this.txtAddGame.Location = new System.Drawing.Point(6, 19);
            this.txtAddGame.Name = "txtAddGame";
            this.txtAddGame.Size = new System.Drawing.Size(139, 20);
            this.txtAddGame.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 6;
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
            // ckbDefaultFolders
            // 
            this.ckbDefaultFolders.AutoSize = true;
            this.ckbDefaultFolders.Location = new System.Drawing.Point(6, 192);
            this.ckbDefaultFolders.Name = "ckbDefaultFolders";
            this.ckbDefaultFolders.Size = new System.Drawing.Size(109, 17);
            this.ckbDefaultFolders.TabIndex = 4;
            this.ckbDefaultFolders.Text = "Add default folder";
            this.ckbDefaultFolders.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSelected.Location = new System.Drawing.Point(361, 314);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(107, 27);
            this.btnRemoveSelected.TabIndex = 9;
            this.btnRemoveSelected.Text = "Remove selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 375);
            this.Controls.Add(this.grbAddGame);
            this.Controls.Add(this.grbAddUser);
            this.Controls.Add(this.grbList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSettings";
            this.Text = "Simple Game Saver";
            this.grbList.ResumeLayout(false);
            this.grbList.PerformLayout();
            this.grbAddUser.ResumeLayout(false);
            this.grbAddUser.PerformLayout();
            this.grbAddGame.ResumeLayout(false);
            this.grbAddGame.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.GroupBox grbList;
        private System.Windows.Forms.Label lblActualUser;
        private System.Windows.Forms.TreeView trvGamesList;
        private System.Windows.Forms.Button btnSetUser;
        private System.Windows.Forms.GroupBox grbAddUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtAddUser;
        private System.Windows.Forms.Button btnAddGameFolder;
        private System.Windows.Forms.Button btnAddConfigFolder;
        private System.Windows.Forms.GroupBox grbAddGame;
        private System.Windows.Forms.ListBox lstGameSugg;
        private System.Windows.Forms.Button btnAddGame;
        private System.Windows.Forms.TextBox txtAddGame;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label lblActualGame;
        private System.Windows.Forms.Label lblActualGameL;
        private System.Windows.Forms.Label lblActualUserL;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.CheckBox ckbDefaultFolders;
    }
}

