using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DebugSystem.DebugService;

namespace SimpleGameSaver
{
    public partial class frmMain : Form
    {
        RepoConfig repoC = new RepoConfig("settings.xml");
        public frmMain()
        {
            InitializeComponent();
            cmbUsersSave.Items.AddRange(repoC.GetUsers().ToArray());
            cmbUserRestore.Items.AddRange(repoC.GetUsers().ToArray());
            btnBackupSaves.Enabled = CheckBackupBtn();
            btnRestoreSaves.Enabled = CheckRestoreBtn();
            frmDebug debug = new frmDebug();
            debug.Show();
            LogSystem.Log("Main Form Opened");
        }

        private void cmbUsersSave_TextChanged(object sender, EventArgs e)
        {
            LogSystem.Log("Event: cmbUserSave - TextChanged");
            btnBackupSaves.Enabled = CheckBackupBtn();
        }

        private void cmbUserRestore_TextChanged(object sender, EventArgs e)
        {
            LogSystem.Log("Event: cmbUserRestore - TextChanged");
            btnRestoreSaves.Enabled = CheckRestoreBtn();
        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            LogSystem.Log("Event: btnSetUp - Click");
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LogSystem.Log("Event: btnExit - Click");
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSystem.Log("Event: settingsToolStripMenuItem - Click");
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSystem.Log("Event: exitToolStripMenuItem - Click");
            this.Close();
        }

        private void btnBackupSaves_Click(object sender, EventArgs e)
        {
            if (CheckBackupBtn())
            {
                RepoFiles repoF = new RepoFiles();
                repoF.Backup(repoC, new UserItem(cmbUsersSave.Text));
            }
        }

        private void ckbSaveToFolder_CheckedChanged(object sender, EventArgs e)
        {
            btnBackupSaves.Enabled = CheckBackupBtn();
        }

        private void ckbSaveToCloud_CheckedChanged(object sender, EventArgs e)
        {
            btnBackupSaves.Enabled = CheckBackupBtn();
        }

        public bool CheckBackupBtn()
        {
            return cmbUsersSave.Text != "" && (ckbSaveToFolder.Checked || ckbSaveToCloud.Checked);
        }

        public bool CheckRestoreBtn()
        {
            return cmbUserRestore.Text != "" && (ckeRestoreFromFolder.Checked || ckbRestoreFromCloud.Checked);
        }

        private void ckeRestoreFromFolder_CheckedChanged(object sender, EventArgs e)
        {
            btnRestoreSaves.Enabled = CheckRestoreBtn();
        }

        private void ckbRestoreFromCloud_CheckedChanged(object sender, EventArgs e)
        {
            btnRestoreSaves.Enabled = CheckRestoreBtn();
        }

        private void btnRestoreSaves_Click(object sender, EventArgs e)
        {
            if (CheckRestoreBtn())
            {
                RepoFiles repoF = new RepoFiles();
                repoF.Restore(repoC, new UserItem(cmbUserRestore.Text));
            }
        }

    }
}
