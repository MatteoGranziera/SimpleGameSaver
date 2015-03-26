using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameSaver
{
    public class GameItem
    {
        public string Name { get; set; }
        public UserItem User { get; set; }
        public List<Folder> SaveFolders { get; set; }
        public List<Folder> ConfigFolders { get; set; }

        public GameItem(string name, UserItem user)
        {
            this.Name = name;
            this.User = user;
        }

        public GameItem()
        {

        }
    }
}
