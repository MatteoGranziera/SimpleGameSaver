using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameSaver
{
    /// <summary>
    /// Class that represents User tag in settings file
    /// </summary>
    public class UserItem
    {
        /// <summary>
        /// get or set name of the user
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Dictionary of games for this user
        /// </summary>
        public Dictionary<String, GameItem> Games { get; set; }
        /// <summary>
        /// Default constructor of UserItem
        /// </summary>
        public UserItem()
        {

        }

        /// <summary>
        /// Constructor of UserItem
        /// </summary>
        /// <param name="name">name of user</param>
        public UserItem(String name)
        {
            this.Name = name;
        }
    }
}
