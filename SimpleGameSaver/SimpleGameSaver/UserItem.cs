using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameSaver
{
    public class UserItem
    {
        public String Name { get; set; }
        public List<GameItem> Games { get; set; }
        public UserItem()
        {

        }

        public UserItem(String name)
        {
            this.Name = name;
        }
    }
}
