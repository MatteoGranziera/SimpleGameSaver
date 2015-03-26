using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameSaver
{
    

    public class Folder
    {
        public static class FolderType
        {
            public const String Save = "Save";
            public const String Config = "Config";
        }
        public String Name { get; set; }
        public String DestinationName { get; set; }
        public bool Enabled { get; set; }
        public String Type { get; set; }

        public Folder(String name, String destinationName, String type, bool enabled = true)
        {
            this.Name = name;
            this.DestinationName = destinationName;
            this.Enabled = enabled;
            this.Type = type;
        }
    }
}
