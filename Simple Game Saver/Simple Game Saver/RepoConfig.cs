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
        private String TAG_USER = "User";
        private String TAG_GAME = "Game";
        private String TAG_FOLDER = "Folder";
        private String PROPERTY_USER_NAME = "name";
        private String PROPERTY_GAME_NAME = "name";
        private String PROPERTY_FOLDER_TYPE = "type";
        private String PROPERTY_FOLDER_PATH = "path";
        private String PROPERTY_FOLDER_TYPE_CONFIG = "configFolder";
        private String PROPERTY_FOLDER_TYPE_SAVE = "SaveFolder";

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

        public bool AddUser(string user)
        {
            if (!InizializeFile())
            {
                return false;
            }
            if (rootNode.SelectSingleNode(TAG_USER + "[" + PROPERTY_USER_NAME + "=" + user + "]") == null)
            {
                XmlElement el = doc.CreateElement(TAG_USER);
                el.SetAttribute(PROPERTY_USER_NAME, user);
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

        public bool WriteGame(GameItem gi)
        {
            if (!InizializeFile())
            {
                return false;
            }

            try
            {
                XmlNode user = rootNode.SelectSingleNode(TAG_USER);

                user.RemoveAll();
                XmlElement game = doc.CreateElement(TAG_GAME);
                user.AppendChild(game);
                foreach (string paths in gi.SaveFolders)
                {
                    XmlElement save = doc.CreateElement(TAG_FOLDER);
                    save.SetAttribute(PROPERTY_FOLDER_TYPE, PROPERTY_FOLDER_TYPE_SAVE);
                    game.AppendChild(save);
                }

                foreach (string paths in gi.ConfigFolders)
                {
                    XmlElement config = doc.CreateElement(TAG_FOLDER);
                    config.SetAttribute(PROPERTY_FOLDER_TYPE, PROPERTY_FOLDER_TYPE_CONFIG);
                    game.AppendChild(config);
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

        public bool WriteGames(List<GameItem> gis)
        {
            bool ok = true;
            foreach (var gi in gis)
            {
                if(ok)
                    ok = WriteGame(gi);
            }

            return ok;
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

        public List<GameItem> GetGamesByUser(string user)
        {
            List<GameItem> games = new List<GameItem>();

            if (!InizializeFile())
            {
                return games;
            }
            try
            {
                foreach (XmlNode game in rootNode.SelectNodes(TAG_USER + "[" + PROPERTY_USER_NAME + "=" + user + "]/" + TAG_GAME))
                {
                    //5games.Add(game.Attributes[PROPERTY_GAME_NAME].Value);
                }
            }
            catch (Exception e)
            {

            }

            return games;
            
        }



    }
}
