using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace SimpleGameSaver
{
    public class RepoConfig
    {
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
                        rootNode = doc.FirstChild;
                    }
                    else
                    {
                        doc = new XmlDocument();
                        doc.AppendChild(doc.CreateElement("root"));
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

            XmlElement el = doc.CreateElement("User");
            el.SetAttribute("name", user);
            rootNode.AppendChild(el);

            return WriteChanges();
        }

        public void WriteGame(GameItem gi)
        {

        }

        public void WriteGames(List<GameItem> gis)
        {

        }

    }
}
