﻿using System;
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
        public frmMain()
        {
            InitializeComponent();
            btnBackupSaves.Enabled = false;
            btnRestoreSaves.Enabled = false;
            frmDebug debug = new frmDebug();
            debug.Show();
            LogSystem.Log("Main Form Opened");
        }

        private void cmbUsersSave_TextChanged(object sender, EventArgs e)
        {
            if (cmbUsersSave.Text != "" && cmbUsersSave.Text != null)
            {
                btnBackupSaves.Enabled = true;
            }
            else
            {
                btnBackupSaves.Enabled = false;
            }
        }

        private void cmbUserRestore_TextChanged(object sender, EventArgs e)
        {
            if (cmbUserRestore.Text != "" && cmbUserRestore.Text != null)
            {
                btnRestoreSaves.Enabled = true;
            }
            else
            {
                btnRestoreSaves.Enabled = false;
            }
        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
