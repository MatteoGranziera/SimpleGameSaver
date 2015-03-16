﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleGameSaver
{
    public partial class AddFolderDialog : Form
    {
        public String absolutePath { get; set; }
        public String relativePath { get; set; }

        private String TAG_USERFOLDER = "%USERPROFILE%";
        private String TAG_SYSTEMDRIVE = "%SYSTEMDRIVE%";

        public AddFolderDialog()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fDialog = new FolderBrowserDialog();
            fDialog.ShowDialog();

            absolutePath = fDialog.SelectedPath;
            relativePath = AddRelativeTags(absolutePath);

            if (ckbAutoTag.Checked)
            {
                txtRelativePath.Text = relativePath;
            }
            else
            {
                txtRelativePath.Text = absolutePath;
            }
            
        }

        private string AddRelativeTags(string path)
        {
            String r = path;
            String userpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (r.Contains(userpath))
            {
                r = r.Replace(userpath, TAG_USERFOLDER);
            }

            String systempath = System.IO.DriveInfo.GetDrives()[0].Name.Replace("\\", "");

            if (r.Contains(systempath))
            {
                r = r.Replace(systempath, TAG_SYSTEMDRIVE);
            }

            return r;
        }

        private void ckbAutoTag_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAutoTag.Checked)
            {
                txtRelativePath.Text = relativePath;
            }
            else
            {
                txtRelativePath.Text = absolutePath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            absolutePath = "";
            relativePath = "";
            this.Close();

        }
    }
}
