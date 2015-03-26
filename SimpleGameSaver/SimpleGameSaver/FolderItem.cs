using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameSaver
{
    
    /// <summary>
    /// Class that represents folder tag in settings file
    /// </summary>
    public class FolderItem
    {
        public static class FolderType
        {
            public const String Save = "Save";
            public const String Config = "Config";
        }
        /// <summary>
        /// set or get relative path of folder
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// set or get name of folder in the backup archive
        /// </summary>
        public String DestinationName { get; set; }
        /// <summary>
        /// set or get if is enabled
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// set or get type of folder
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// Constructor of Folder class
        /// </summary>
        /// <param name="name">relative path of folder</param>
        /// <param name="destinationName">name of folder in the backup archive</param>
        /// <param name="type">type of folder use Folder.FolderType</param>
        /// <param name="enabled">this folder is enabled</param>
        public FolderItem(String name, String destinationName, String type, bool enabled = true)
        {
            this.Name = name;
            this.DestinationName = destinationName;
            this.Enabled = enabled;
            this.Type = type;
        }
    }
}
