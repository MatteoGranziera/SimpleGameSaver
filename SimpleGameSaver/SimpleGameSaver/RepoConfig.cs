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
        public const String PROPERTY_FOLDER_TYPE_CONFIG = "configFolder";
        public const String PROPERTY_FOLDER_TYPE_SAVE = "saveFolder";

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

            XmlElement userEl = (XmlElement) rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + game.user.Name + "']");
            if (rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + game.user.Name + "']/" + TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + game + "']") == null)
            {
                XmlElement gameEl = doc.CreateElement(TAG_GAME);
                gameEl.SetAttribute(PROPERTY_GAME_NAME, game.name);
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

        public bool RemoveFolder(GameItem gi, String folder, String type)
        {
            if (!InizializeFile())
            {
                return false;
            }

            try
            {
                XmlElement game = (XmlElement)rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + gi.user.Name + "']/" +TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + gi.name + "']");

                LogSystem.Log(TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + gi.name + "']"+"/"+TAG_FOLDER+"[@"+PROPERTY_FOLDER_TYPE+"='"+type+"' and text() = '"+folder+"']");
                XmlElement folderEl = (XmlElement)game.SelectSingleNode(
                    TAG_FOLDER+"[@"+PROPERTY_FOLDER_TYPE+"='"+type+"' and text() = '"+folder+"']");
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
                XmlElement user = (XmlElement)rootNode.SelectSingleNode(TAG_USER+"[@"+PROPERTY_USER_NAME+"='"+gi.user.Name+"']");
                XmlElement game = (XmlElement)user.SelectSingleNode(TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + gi.name + "']");
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

        public bool AddFolder(GameItem game, String folder, String type){
            if (!InizializeFile())
            {
                return false;
            }

            XmlElement gameEl = (XmlElement)rootNode.SelectSingleNode(TAG_USER + "[@" + PROPERTY_USER_NAME + "='" + game.user.Name + "']/" + TAG_GAME + "[@" + PROPERTY_GAME_NAME + "='" + game + "']");
            if (gameEl.SelectSingleNode(TAG_FOLDER + "[@" + PROPERTY_FOLDER_TYPE + "='" + type + "' and text() = '" + folder + "']") == null)
            {
                XmlElement folderEl = doc.CreateElement(TAG_FOLDER);
                folderEl.SetAttribute(PROPERTY_FOLDER_TYPE, type);
                folderEl.InnerText = folder;
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

                    item.name = game.Attributes[PROPERTY_GAME_NAME].Value;
                    item.user = user;

                    query = TAG_FOLDER + "[@" + PROPERTY_FOLDER_TYPE + "='" + PROPERTY_FOLDER_TYPE_SAVE + "']";
                    item.SaveFolders = new List<string>();
                    
                    foreach (XmlNode save in game.SelectNodes(query))
                    {
                        item.SaveFolders.Add(save.InnerText);
                    }

                    query = TAG_FOLDER + "[@" + PROPERTY_FOLDER_TYPE + "='" + PROPERTY_FOLDER_TYPE_CONFIG + "']";
                    item.ConfigFolders = new List<string>();
                    foreach (XmlNode config in game.SelectNodes(query))
                    {
                        item.ConfigFolders.Add(config.InnerText);
                    }

                    games.Add(item.name, item);
                    
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
