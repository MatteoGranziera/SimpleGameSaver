namespace SimpleGameSaver
{
    partial class AddFolderDialog
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
            this.txtRelativePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblRelativePath = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.ckbAutoTag = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtRelativePath
            // 
            this.txtRelativePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelativePath.Location = new System.Drawing.Point(15, 32);
            this.txtRelativePath.Name = "txtRelativePath";
            this.txtRelativePath.Size = new System.Drawing.Size(333, 20);
            this.txtRelativePath.TabIndex = 0;
            this.txtRelativePath.TextChanged += new System.EventHandler(this.txtRelativePath_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(354, 30);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(83, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblRelativePath
            // 
            this.lblRelativePath.AutoSize = true;
            this.lblRelativePath.Location = new System.Drawing.Point(12, 16);
            this.lblRelativePath.Name = "lblRelativePath";
            this.lblRelativePath.Size = new System.Drawing.Size(74, 13);
            this.lblRelativePath.TabIndex = 2;
            this.lblRelativePath.Text = "Relative Path:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 73);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(258, 52);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Relative tag suggestions:\r\n\r\n- Current user folder : %USERPROFILE%\r\n- Drive where" +
    " system is installed : %SYSTEMDRIVE%";
            // 
            // ckbAutoTag
            // 
            this.ckbAutoTag.AutoSize = true;
            this.ckbAutoTag.Checked = true;
            this.ckbAutoTag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAutoTag.Location = new System.Drawing.Point(15, 53);
            this.ckbAutoTag.Name = "ckbAutoTag";
            this.ckbAutoTag.Size = new System.Drawing.Size(183, 17);
            this.ckbAutoTag.TabIndex = 4;
            this.ckbAutoTag.Text = "Automatic relative tag recognition";
            this.ckbAutoTag.UseVisualStyleBackColor = true;
            this.ckbAutoTag.CheckedChanged += new System.EventHandler(this.ckbAutoTag_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(362, 133);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(281, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Enabled = false;
            this.txtDestination.Location = new System.Drawing.Point(112, 136);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(157, 20);
            this.txtDestination.TabIndex = 7;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Enabled = false;
            this.lblDestination.Location = new System.Drawing.Point(12, 139);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(94, 13);
            this.lblDestination.TabIndex = 8;
            this.lblDestination.Text = "Destination Name:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(354, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AddFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 168);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ckbAutoTag);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblRelativePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtRelativePath);
            this.Name = "AddFolderDialog";
            this.Text = "AddFolderDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRelativePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblRelativePath;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckBox ckbAutoTag;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}