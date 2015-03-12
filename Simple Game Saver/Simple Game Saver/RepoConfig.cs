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
        private String PROPERTY_USER_NAME = "name";

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
                return true;
            }
            catch (Exception e)
            {
                //Exception
                LogSystem.Log();
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
                        doc = new XmlDocument();
                        doc.Load(filename);
                        rootNode = doc.ChildNodes[1];
                    }
                    else
                    {
                        doc = new XmlDocument();
                        rootNode = doc.CreateElement("root");
                        doc.AppendChild(rootNode);
                        doc.InsertBefore(doc.CreateXmlDeclaration("1.0", null, null), doc.DocumentElement);
                        return WriteChanges();
                    }
                    return true;
                }
                catch (FileNotFoundException xmlE)
                {
                    //Exception
                    return false;
                }
                catch(Exception e)
                {
                    //Exception
                    return false;
                }
            }
            return false;
        }

        public bool AddUser(string user)
        {
            if (!InizializeFile())
            {
                return false;
            }

            XmlElement el = doc.CreateElement(TAG_USER);
            el.SetAttribute(PROPERTY_USER_NAME, user);
            rootNode.AppendChild(el);

            return WriteChanges();
        }

        public void WriteGame(GameItem gi)
        {

        }

        public void WriteGames(List<GameItem> gis)
        {

        }

        public List<String> GetUsers()
        {
            if (!InizializeFile())
            {
                return null;
            }

            List<String> users = new List<string>();

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
                return null;
            }

            return users;
        }



    }
}
