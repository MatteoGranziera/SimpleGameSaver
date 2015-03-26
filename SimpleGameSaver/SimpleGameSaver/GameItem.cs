using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameSaver
{
    /// <summary>
    /// Class that reperents Game tag in settings file
    /// </summary>
    public class GameItem
    {
        /// <summary>
        /// set or get name of game
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// set or get user of this game
        /// </summary>
        public UserItem User { get; set; }
        /// <summary>
        /// list of saves folders
        /// </summary>
        public List<FolderItem> SaveFolders { get; set; }
        /// <summary>
        /// list of config folders
        /// </summary>
        public List<FolderItem> ConfigFolders { get; set; }

        /// <summary>
        /// Cosntructor of GameItem
        /// </summary>
        /// <param name="name">name of the game</param>
        /// <param name="user">user of the game</param>
        public GameItem(string name, UserItem user)
        {
            this.Name = name;
            this.User = user;
        }

        //Default constructor of GameItem
        public GameItem()
        {

        }
    }
}
