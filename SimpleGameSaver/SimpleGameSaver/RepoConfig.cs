using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using DebugSystem.DebugService;

namespace SimpleGameSaver
{
    /// <summary>
    /// Class to write and read settings file
    /// </summary>
    public class RepoConfig
    {
        /// <summary>
        /// tag for user in xml file
        /// </summary>
        public const String TAG_USER = "User";
        /// <summary>
        /// tag for game in xml file
        /// </summary>
        public const String TAG_GAME = "Game";
        /// <summary>
        /// tag for folder in xml file
        /// </summary>
        public const String TAG_FOLDER = "Folder";
        /// <summary>
        /// property for name of user in xml file
        /// </summary>
        public const String PROPERTY_USER_NAME = "name";
        /// <summary>
        /// property for name of game in xml file
        /// </summary>
        public const String PROPERTY_GAME_NAME = "name";
        /// <summary>
        /// property for type of folder in xml file
        /// </summary>
        public const String PROPERTY_FOLDER_TYPE = "type";
        /// <summary>
        /// property for destination of folder in xml file
        /// </summary>
        public const String PROPERTY_FOLDER_DESTINATION = "destFolder";
        /// <summary>
        /// property for enable of folder in xml file
        /// </summary>
        public const String PROPERTY_FOLDER_ENABLED = "enaFolder";

        /// <summary>
        /// XmlDocument of settings file
        /// </summary>
        private XmlDocument doc = null;
        /// <summary>
        /// root node in settings file
        /// </summary>
        private XmlNode rootNode = null;
        /// <summary>
        /// get or set name of settings file
        /// </summary>
        public string filename { get; set; }

        /// <summary>
        /// Constructor of RepoConfig
        /// </summary>
        /// <param name="filename"> name of settings file</param>
        public RepoConfig(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Update xml settings file with changes 
        /// </summary>
        /// <returns>true if all was write correctly else false</returns>
        private bool WriteChanges()
        {
            try
            {
                doc.Save(filename);
                LogSystem.Log("Config file saved correctly : " + filename);
                return true;
            }
            catch (Exception e)
            {
                //Exception
                LogSystem.LogError(e);
                return false;
            }
        }

        /// <summary>
        /// Load xml settings file
        /// </summary>
        /// <returns>true if all was load correctly else false</returns>
        private bool InizializeFile()
        {
            if(filename != null)
            {
                try
                {
                    if(File.Exists(filename))
                    {
                        LogSystem.Log("Config file exists  : " + filename);
                        doc = new XmlDocument();
                        doc.Load(filename);
                        rootNode = doc.ChildNodes[1];
                        LogSystem.Log("Config file loaded correctly  : " + filename);
                    }
                    else
                    {
                        LogSystem.Log("Config file not exists  : " + filename);
                        doc = new XmlDocument();
                        rootNode = doc.CreateElement("root");
                        doc.AppendChild(rootNode);
                        doc.InsertBefore(doc.CreateXmlDeclaration("1.0", null, null), doc.DocumentElement);
                        LogSystem.Log("new config file created : " + filename);
                        return WriteChanges();
                    }
                    return true;
                }
                catch (FileNotFoundException xmlE)
                {
                    //Exception
                    LogSystem.LogError(xmlE);
                    return false;
                }
                catch(Exception e)
                {
                    //Exception
                    LogSystem.LogError(e);
                    return false;
                }
            }
            else
            {
                LogSystem.Log("Config file not setted, please default constructor RepoConfig(string filename)");
                return false;
            }
        }

        /// <summary>
        /// Add a user in settings file
        /// </summary>
        /// <param name="user">UserItem of user (is)</param>
        /// <returns>true if user was added correctly else false</returns>
        public bool AddUser(UserItem user)
        {
            if (!InizializeFile())
            {
                return false;
            }
            if (rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + user.Name + "']") == null)
            {
                XmlElement el = doc.CreateElement(TAG_USER);
                el.SetAttribute(PROPERTY_USER_NAME, user.Name);
                rootNode.AppendChild(el);
                LogSystem.Log("AddUser: user created");
                return WriteChanges();
            }
            else
            {
                LogSystem.Log("AddUser: user already exists");
                return false;
            }

            
        }

        /// <summary>
        /// Add a game in settings file
        /// </summary>
        /// <param name="game">GameItem of the game</param>
        /// <returns>true if game was added correctly else false</returns>
        public bool AddGame(GameItem game )
        {
            if (!InizializeFile())
            {
                return false;
            }

            XmlElement userEl = (XmlElement) rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + game.User.Name + "']");
            if (userEl.SelectSingleNode(TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + game + "']") == null)
            {
                XmlElement gameEl = doc.CreateElement(TAG_GAME);
                gameEl.SetAttribute(PROPERTY_GAME_NAME, game.Name);
                userEl.AppendChild(gameEl);
                LogSystem.Log("AddGame: game created");
                return WriteChanges();
            }
            else
            {
                LogSystem.Log("AddGame: game already exists");
                return false;
            }

        }

        /// <summary>
        /// Remove folder in settings file
        /// </summary>
        /// <param name="gi">GameItem of folder</param>
        /// <param name="folder">FolderItem of folder to remove</param>
        /// <returns>true if folder was removed correctly else false</returns>
        public bool RemoveFolder(GameItem gi, FolderItem folder)
        {
            if (!InizializeFile())
            {
                return false;
            }

            try
            {
                XmlElement game = (XmlElement)rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + gi.User.Name + "']/" +TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + gi.Name + "']");

                LogSystem.Log(TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + gi.Name + "']"+"/"+TAG_FOLDER+"[@"+PROPERTY_FOLDER_TYPE+"='"+folder.Type+"' and text() = '"+folder.Name+"']");
                XmlElement folderEl = (XmlElement)game.SelectSingleNode(
                    TAG_FOLDER+"[@"+PROPERTY_FOLDER_TYPE+"='"+folder.Type+"' and text() = '"+folder.Name+"']");
                if (folderEl != null)
                {
                    game.RemoveChild(folderEl);
                }
                return WriteChanges();
            }
            catch (Exception e)
            {
                //Exception
                LogSystem.LogError(e);
                return false;
            }
        }

        /// <summary>
        /// Remove game in settings file. All folder under this game will removed
        /// </summary>
        /// <param name="gi">GameItem to remove</param>
        /// <returns>true if game was removed correctly else false</returns>
        public bool RemoveGame(GameItem gi)
        {
            if (!InizializeFile())
            {
                return false;
            }

            try
            {
                XmlElement user = (XmlElement)rootNode.SelectSingleNode(TAG_USER+"[@"+PROPERTY_USER_NAME+"='"+gi.User.Name+"']");
                XmlElement game = (XmlElement)user.SelectSingleNode(TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + gi.Name + "']");
                if (game != null)
                {
                    user.RemoveChild(game);
                }
                return WriteChanges();
            }
            catch (Exception e)
            {
                //Exception
                LogSystem.LogError(e);
                return false;
            }
        }

        /// <summary>
        /// Add a folder in settings file
        /// </summary>
        /// <param name="game">GameItem of folder</param>
        /// <param name="folder">FolderItem of folder to add</param>
        /// <returns>true if folder was added correctly else false</returns>
        public bool AddFolder(GameItem game, FolderItem folder){
            if (!InizializeFile())
            {
                return false;
            }

            XmlElement gameEl = (XmlElement)rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + game.User.Name + "']/" + TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + game.Name+ "']");
            if (gameEl.SelectSingleNode(TAG_FOLDER + "[@" + PROPERTY_FOLDER_TYPE + "='" + folder.Type + "' and text() = '" + folder + "']") == null)
            {
                XmlElement folderEl = doc.CreateElement(TAG_FOLDER);

                folderEl.SetAttribute(PROPERTY_FOLDER_TYPE, folder.Type);
                folderEl.SetAttribute(PROPERTY_FOLDER_DESTINATION, folder.DestinationName);
                folderEl.SetAttribute(PROPERTY_FOLDER_ENABLED, folder.Enabled.ToString());

                folderEl.InnerText = folder.Name;
                gameEl.AppendChild(folderEl);
                LogSystem.Log("AddFolder: folder created");
                return WriteChanges();
            }
            else
            {
                LogSystem.Log("AddFolder: folder already exists");
                return false;
            }
        }

        /// <summary>
        /// Get list of users that are in settings file
        /// </summary>
        /// <returns></returns>
        public List<String> GetUsers()
        {
            List<String> users = new List<String>();

            if (!InizializeFile())
            {
                return users;
            }

            try
            {
                foreach (XmlNode node in rootNode.SelectNodes(TAG_USER))
                {
                    users.Add(node.Attributes[PROPERTY_USER_NAME].Value);
                }
            }
            catch(NullReferenceException e)
            {
                //Exception
                LogSystem.LogError(e);
                return new List<string>();
            }

            return users;
        }

        /// <summary>
        /// Get games of a user in settings file
        /// </summary>
        /// <param name="user">UserItem </param>
        /// <returns>dictionary of games of the user</returns>
        public Dictionary<String, GameItem> GetGamesByUser(UserItem user)
        {
            Dictionary<String, GameItem> games = new Dictionary<String, GameItem>();

            if (!InizializeFile())
            {
                return games;
            }
            try
            {
                String query = TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + user.Name + "']/" + TAG_GAME;
                foreach (XmlNode game in rootNode.SelectNodes(query))
                {
                    GameItem item = new GameItem();

                    item.Name = game.Attributes[PROPERTY_GAME_NAME].Value;
                    item.User = user;

                    query = TAG_FOLDER;
                    item.SaveFolders = new Dictionary<String, FolderItem>();
                    item.ConfigFolders = new Dictionary<String, FolderItem>();
                    
                    foreach (XmlNode folder in game.SelectNodes(query))
                    {
                        if(folder.Attributes[PROPERTY_FOLDER_TYPE].Value == FolderItem.FolderType.Save)
                            item.SaveFolders.Add(folder.InnerText, new FolderItem(folder.InnerText, folder.Attributes[PROPERTY_FOLDER_DESTINATION].Value,FolderItem.FolderType.Save, Convert.ToBoolean(folder.Attributes[PROPERTY_FOLDER_ENABLED].Value)));
                        else if (folder.Attributes[PROPERTY_FOLDER_TYPE].Value == FolderItem.FolderType.Config)
                            item.ConfigFolders.Add(folder.InnerText, new FolderItem(folder.InnerText, folder.Attributes[PROPERTY_FOLDER_DESTINATION].Value,FolderItem.FolderType.Config, Convert.ToBoolean(folder.Attributes[PROPERTY_FOLDER_ENABLED].Value)));
                    }

                    games.Add(item.Name, item);
                    
                }
            }
            catch (Exception e)
            {
                //Exception
                LogSystem.LogError(e);
            }

            return games;
            
        }

    }
}
