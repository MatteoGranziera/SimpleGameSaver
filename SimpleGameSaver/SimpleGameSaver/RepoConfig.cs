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
    public class RepoConfig
    {
        public const String TAG_USER = "User";
        public const String TAG_GAME = "Game";
        public const String TAG_FOLDER = "Folder";
        public const String PROPERTY_USER_NAME = "name";
        public const String PROPERTY_GAME_NAME = "name";
        public const String PROPERTY_FOLDER_TYPE = "type";
        /*public const String PROPERTY_FOLDER_TYPE_CONFIG = "configFolder";
        public const String PROPERTY_FOLDER_TYPE_SAVE = "saveFolder";*/
        public const String PROPERTY_FOLDER_DESTINATION = "destFolder";
        public const String PROPERTY_FOLDER_ENABLED = "enaFolder";

        private XmlDocument doc = null;
        private XmlNode rootNode = null;
        public string filename{
            get; set;
        }

        public RepoConfig(string filename)
        {
            this.filename = filename;
        }

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

        public bool RemoveFolder(GameItem gi, Folder folder)
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

        public bool AddFolder(GameItem game, Folder folder){
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
                    item.SaveFolders = new List<Folder>();
                    item.ConfigFolders = new List<Folder>();
                    
                    foreach (XmlNode folder in game.SelectNodes(query))
                    {
                        if(folder.Attributes[PROPERTY_FOLDER_TYPE].Value == Folder.FolderType.Save)
                            item.SaveFolders.Add(new Folder(folder.InnerText, folder.Attributes[PROPERTY_FOLDER_DESTINATION].Value,Folder.FolderType.Save, Convert.ToBoolean(folder.Attributes[PROPERTY_FOLDER_ENABLED].Value)));
                        else if (folder.Attributes[PROPERTY_FOLDER_TYPE].Value == Folder.FolderType.Config)
                            item.ConfigFolders.Add(new Folder(folder.InnerText, folder.Attributes[PROPERTY_FOLDER_DESTINATION].Value,Folder.FolderType.Config, Convert.ToBoolean(folder.Attributes[PROPERTY_FOLDER_ENABLED].Value)));
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
