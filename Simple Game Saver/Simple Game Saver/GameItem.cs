using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameSaver
{
    public class GameItem
    {
        public string name { get; set; }
        public string user { get; set; }
        public List<string> SaveFolders { get; set; }
        public List<string> ConfigFolders { get; set; }

        public GameItem(string name, string user)
        {
            this.name = name;
            this.user = user;
        }
    }
}
