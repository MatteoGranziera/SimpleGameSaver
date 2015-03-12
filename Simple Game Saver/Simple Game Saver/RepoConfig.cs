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
                XmlTextWriter writer = new XmlTextWriter(filename, null);
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
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
                    if(!File.Exists(filename))
                    {
                        doc = new XmlDocument();
                        doc.Load(filename);
                    }
                    return true;
                }
                catch (FileNotFoundException xmlE)
                {
                    //Exception
                    try
                    {
                        XmlTextWriter writer = new XmlTextWriter(filename, null);
                        writer.Formatting = Formatting.Indented;
                        doc.Save(writer);
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
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
            el.SetAttribute("id", user);
            if((XmlNodeList as doc).SelectSingleNode("User[name='"+user+"']"))
            doc.AppendChild(el);

            return true;
        }

        public void WriteGame(GameItem gi)
        {

        }

        public void WriteGames(List<GameItem> gis)
        {

        }

    }
}
