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
    public partial class frmSettings : Form
    {
        RepoConfig repoC;
        public frmSettings()
        {
            InitializeComponent();
            repoC = new RepoConfig("settings.xml");
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtAddUser.Text != "")
            {
                repoC.AddUser(txtAddUser.Text);
            }
        }
    }
}
