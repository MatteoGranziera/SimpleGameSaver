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
        private RepoConfig repoC;
        private String user;
        private ImageList imgList;

        private int JOYSTICK_IMGE_IDEX = 0;
        private int FOLDERSAVE_IMGE_IDEX = 1;
        private int FOLDERCONFIG_IMGE_IDEX = 2;
        private int FILESAVE_IMGE_IDEX = 3;
        private int FILECONFIG_IMGE_IDEX = 4;
        private int CONFIG_IMGE_IDEX = 5;
        private int SAVE_IMGE_IDEX = 6;

        public frmSettings()
        {
            InitializeComponent();
            repoC = new RepoConfig("settings.xml");

            imgList = new ImageList();
            imgList.Images.Add(Properties.Resources.joystick);
            imgList.Images.Add(Properties.Resources.foldersave);
            imgList.Images.Add(Properties.Resources.folderconfig);
            imgList.Images.Add(Properties.Resources.filesave);
            imgList.Images.Add(Properties.Resources.fileconfig);
            imgList.Images.Add(Properties.Resources.config);
            imgList.Images.Add(Properties.Resources.save);

            trvGamesList.ImageList = imgList;
            UpdateUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtAddUser.Text != "")
            {
                repoC.AddUser(txtAddUser.Text);
                UpdateUsers();
                txtAddUser.Text = "";
            }
        }

        private void UpdateUsers()
        {
            string selected = cmbUsers.SelectedText;

            cmbUsers.Items.Clear();
            cmbUsers.Items.AddRange(repoC.GetUsers().ToArray());
        }

        private void UpdateGames()
        {
            if (user != null && user != "")
            {
                List<GameItem> games = repoC.GetGamesByUser(user);

                foreach (GameItem game in games)
                {
                    TreeNode gameNode = new TreeNode(game.name);
                    gameNode.ImageIndex = JOYSTICK_IMGE_IDEX;
                    gameNode.SelectedImageIndex = JOYSTICK_IMGE_IDEX;

                    TreeNode savesNode = new TreeNode("Saves");
                    savesNode.ImageIndex = SAVE_IMGE_IDEX;
                    savesNode.SelectedImageIndex = SAVE_IMGE_IDEX;

                    foreach (String save in game.SaveFolders)
                    {
                        TreeNode saveNode = new TreeNode(save);
                        saveNode.ImageIndex = FOLDERSAVE_IMGE_IDEX;
                        saveNode.SelectedImageIndex = FOLDERSAVE_IMGE_IDEX;
                        savesNode.Nodes.Add(saveNode);
                    }

                    gameNode.Nodes.Add(savesNode);

                    TreeNode configsNode = new TreeNode("Configurations");
                    configsNode.ImageIndex = CONFIG_IMGE_IDEX;
                    configsNode.SelectedImageIndex = CONFIG_IMGE_IDEX;

                    foreach (String save in game.ConfigFolders)
                    {
                        TreeNode configNode = new TreeNode(save);
                        configNode.ImageIndex = FOLDERCONFIG_IMGE_IDEX;
                        configNode.SelectedImageIndex = FOLDERCONFIG_IMGE_IDEX;
                        configsNode.Nodes.Add(configNode);
                    }

                    gameNode.Nodes.Add(configsNode);

                    trvGamesList.Nodes.Add(gameNode);
                }
            }
            
        }

        private void btnSetUser_Click(object sender, EventArgs e)
        {
            if (cmbUsers.Text != "")
            {
                user = cmbUsers.Text;
                UpdateGames();
            }
            
        }

        private void trvGamesList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode child in e.Node.Nodes)
            {
                child.Checked = e.Node.Checked;
            }
        }

        private void btnAddGameFolder_Click(object sender, EventArgs e)
        {
            AddFolderDialog addF = new AddFolderDialog();
            addF.ShowDialog();
        }
    }
}
