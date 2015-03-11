using System;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            btnBackupSaves.Enabled = false;
            btnRestoreSaves.Enabled = false;
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
    }
}
