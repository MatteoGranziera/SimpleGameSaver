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
        //Private variables
        private RepoConfig repoC;
        private ImageList imgList;
        private UserItem user {get; set;}

        //Private static variables
        private int JOYSTICK_IMGE_IDEX = 0;
        private int FOLDERSAVE_IMGE_IDEX = 1;
        private int FOLDERCONFIG_IMGE_IDEX = 2;
        private int FILESAVE_IMGE_IDEX = 3;
        private int FILECONFIG_IMGE_IDEX = 4;
        private int CONFIG_IMGE_IDEX = 5;
        private int SAVE_IMGE_IDEX = 6;

        //Constructor
        public frmSettings()
        {
            InitializeComponent();

            lblActualGame.Text = "";
            lblActualUser.Text = "";
            
            //Inizialize class to read/write configuration file
            repoC = new RepoConfig("settings.xml");

            //Load images list from resource
            imgList = new ImageList();
            imgList.Images.Add(Properties.Resources.joystick);
            imgList.Images.Add(Properties.Resources.foldersave);
            imgList.Images.Add(Properties.Resources.folderconfig);
            imgList.Images.Add(Properties.Resources.filesave);
            imgList.Images.Add(Properties.Resources.fileconfig);
            imgList.Images.Add(Properties.Resources.config);
            imgList.Images.Add(Properties.Resources.save);

            //Apply images list on TreeView
            trvGamesList.ImageList = imgList;

            //Load users on DropDownList
            UpdateUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //Check if is empty
            if (txtAddUser.Text != "")
            {
                //Load user
                repoC.AddUser(new UserItem(txtAddUser.Text));
                UpdateUsers();
                txtAddUser.Text = "";
            }
        }

        private void UpdateUsers()
        {
            string selected = cmbUsers.SelectedText;

            cmbUsers.Items.Clear();
            cmbUsers.Items.AddRange(repoC.GetUsers().ToArray());

            if (cmbUsers.Items.Contains(selected))
            {
                cmbUsers.SelectedItem = selected;
            }
        }

        private void UpdateGames()
        {
            //Check if a user is selected
            if (user.Name != null && user.Name != "")
            {
                trvGamesList.Nodes.Clear();
                lblActualGame.Text = "";
                user.Games = repoC.GetGamesByUser(user);

                foreach (var game in user.Games)
                {
                    //Load game on TreeView
                    TreeNode gameNode = new TreeNode(game.Value.name);
                    gameNode.ImageIndex = JOYSTICK_IMGE_IDEX;
                    gameNode.SelectedImageIndex = JOYSTICK_IMGE_IDEX;

                    //Load TreeNode to group all saves
                    TreeNode savesNode = new TreeNode("Saves");
                    savesNode.ImageIndex = SAVE_IMGE_IDEX;
                    savesNode.SelectedImageIndex = SAVE_IMGE_IDEX;

                    //Load saves of game
                    foreach (String save in game.Value.SaveFolders)
                    {
                        TreeNode saveNode = new TreeNode(save);
                        saveNode.ImageIndex = FOLDERSAVE_IMGE_IDEX;
                        saveNode.SelectedImageIndex = FOLDERSAVE_IMGE_IDEX;
                        savesNode.Nodes.Add(saveNode);
                    }

                    gameNode.Nodes.Add(savesNode);

                    //Load TreeNode to group all config
                    TreeNode configsNode = new TreeNode("Configurations");
                    configsNode.ImageIndex = CONFIG_IMGE_IDEX;
                    configsNode.SelectedImageIndex = CONFIG_IMGE_IDEX;

                    //Load configs of game
                    foreach (String save in game.Value.ConfigFolders)
                    {
                        TreeNode configNode = new TreeNode(save);
                        configNode.ImageIndex = FOLDERCONFIG_IMGE_IDEX;
                        configNode.SelectedImageIndex = FOLDERCONFIG_IMGE_IDEX;
                        configsNode.Nodes.Add(configNode);
                    }

                    gameNode.Nodes.Add(configsNode);

                    trvGamesList.Nodes.Add(gameNode);
                    trvGamesList.ExpandAll();
                }
            }
            
        }

        private void btnSetUser_Click(object sender, EventArgs e)
        {
            if (cmbUsers.Text != "")
            {
                user = new UserItem(cmbUsers.Text);
                lblActualUser.Text = user.Name;
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
            if (user != null && user.Name != "" && lblActualGame.Text != "")
            {
                var game = user.Games.Where(g => trvGamesList.SelectedNode.FullPath.Substring(0, trvGamesList.SelectedNode.FullPath.IndexOf('\\')) == g.Value.name).ToList()[0];

                AddFolderDialog addF = new AddFolderDialog();
                addF.ShowDialog();

                if (addF.DialogResult == DialogResult.OK)
                {
                    game.Value.SaveFolders.Add(addF.result);
                    repoC.AddFolder(game.Value, addF.result, RepoConfig.PROPERTY_FOLDER_TYPE_SAVE);
                    UpdateGames();
                }
            }
        }

        private void btnAddConfigFolder_Click(object sender, EventArgs e)
        {
            if (user != null && user.Name != "" && lblActualGame.Text != "")
            {
                var game = user.Games.Where(g => trvGamesList.SelectedNode.FullPath.Substring(0, trvGamesList.SelectedNode.FullPath.IndexOf('\\')) == g.Value.name).ToList()[0];

                AddFolderDialog addF = new AddFolderDialog();
                addF.ShowDialog();

                if (addF.DialogResult == DialogResult.OK)
                {
                    game.Value.ConfigFolders.Add(addF.result);
                    repoC.AddFolder(game.Value, addF.result, RepoConfig.PROPERTY_FOLDER_TYPE_CONFIG);
                    UpdateGames();
                }
            }
        }

        private void trvGamesList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node != null)
            {
                lblActualGame.Text = GetRootParent(trvGamesList.SelectedNode).Text;
            }
            else
            {
                lblActualGame.Text = "";
            }
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            if(user != null)
            {
                if (txtAddGame.Text != "")
                {
                    GameItem gm = new GameItem(txtAddGame.Text, user);
                    repoC.AddGame(gm);
                    UpdateGames();
                }
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (trvGamesList.SelectedNode != null)
            {

                if(trvGamesList.SelectedNode.Nodes.Count == 0)
                {
                    String game = trvGamesList.SelectedNode.FullPath.Substring(0, trvGamesList.SelectedNode.FullPath.IndexOf('\\'));
                    GameItem gm = user.Games[game];
                    String path = trvGamesList.SelectedNode.Text;

                    if (gm.ConfigFolders.Contains(path))
                    {
                        repoC.RemoveFolder(gm, path, RepoConfig.PROPERTY_FOLDER_TYPE_CONFIG);
                    }
                    else if (gm.SaveFolders.Contains(path))
                    {
                        repoC.RemoveFolder(gm, path, RepoConfig.PROPERTY_FOLDER_TYPE_SAVE);
                    }

                }
                else if (trvGamesList.SelectedNode.Text == "Saves")
                {
                    String game = trvGamesList.SelectedNode.FullPath.Substring(0, trvGamesList.SelectedNode.FullPath.IndexOf('\\'));
                    GameItem gm = user.Games[game];
                    foreach (String f in gm.SaveFolders)
                    {
                        repoC.RemoveFolder(gm, f, RepoConfig.PROPERTY_FOLDER_TYPE_SAVE);
                    }
                }
                else if (trvGamesList.SelectedNode.Text == "Configurations")
                {
                    String game = trvGamesList.SelectedNode.FullPath.Substring(0, trvGamesList.SelectedNode.FullPath.IndexOf('\\'));
                    GameItem gm = user.Games[game];
                    foreach (String f in gm.ConfigFolders)
                    {
                        repoC.RemoveFolder(gm, f, RepoConfig.PROPERTY_FOLDER_TYPE_CONFIG);
                    }
                }
                else if(trvGamesList.SelectedNode.FullPath.IndexOf('\\') == -1)
                {
                    repoC.RemoveGame(new GameItem(trvGamesList.SelectedNode.Text, user));
                }

                UpdateGames();
            }

        }
        private TreeNode GetRootParent(TreeNode node)
        {
            TreeNode parentNode = node;
            while (!(parentNode.Parent == null))
            {
                parentNode = parentNode.Parent;
            }
            return parentNode;
        }
    }
}
