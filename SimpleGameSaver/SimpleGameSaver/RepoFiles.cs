using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DebugSystem.DebugService;

namespace SimpleGameSaver
{
    public class RepoFiles
    {
        private String TAG_USERFOLDER = "%USERPROFILE%";
        private String TAG_SYSTEMDRIVE = "%SYSTEMDRIVE%";

        private static String BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// Backup saves and config folders
        /// </summary>
        /// <param name="config">RepoConfig instance of the settings file</param>
        /// <param name="user">UserItem that will backup</param>
        /// <param name="Folder">name of folder where will saved backups</param>
        /// <returns>tre if alla was executed correctly else false</returns>
        public bool Backup(RepoConfig config, UserItem user,  String Folder = "Backups")
        {
            try
            {
                String ActualDir = BaseDirectory + Folder;
                CreateDirectory(ActualDir);

                ActualDir += @"\" + user.Name;
                CreateDirectory(ActualDir);

                Dictionary<String, GameItem> games = config.GetGamesByUser(user);

                foreach (var gItem in games.Values)
                {
                    String gameDir = ActualDir + "\\" + gItem.Name;
                    CreateDirectory(gameDir);

                    foreach (var fItem in (gItem.SaveFolders.Concat(gItem.ConfigFolders)).ToDictionary(f => f.Key, f=>f.Value).Values)
                    {
                        String fDest = gameDir + "\\" + fItem.DestinationName;
                        String fIni = fItem.Name;

                        if (fIni.Contains(TAG_USERFOLDER))
                        {
                            fIni = fIni.Replace(TAG_USERFOLDER, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                        }

                        if (fIni.Contains(TAG_SYSTEMDRIVE))
                        {
                            fIni = fIni.Replace(TAG_SYSTEMDRIVE, System.IO.DriveInfo.GetDrives()[0].Name.Replace("\\", ""));
                        }

                        CopyDirectory(fIni, fDest);
                    }

                }


                return true;
            }
            catch(Exception e)
            {
                //Exception
                LogSystem.LogError(e);
                return false;
            }

        }

        private bool CreateDirectory(String path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return true;
            }
            catch (Exception e)
            {
                //Exception
                LogSystem.LogError(e);
                return false;
            }
        }

        private bool CopyDirectory(string sourcePath, string destPath)
        {
            try
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }

                foreach (string file in Directory.GetFiles(sourcePath))
                {
                    string dest = Path.Combine(destPath, Path.GetFileName(file));
                    File.Copy(file, dest);
                }

                foreach (string folder in Directory.GetDirectories(sourcePath))
                {
                    string dest = Path.Combine(destPath, Path.GetFileName(folder));
                    CopyDirectory(folder, dest);
                }
                return true;
            }
            catch (Exception e)
            {
                //Exception
                LogSystem.LogError(e);
                return false;
            }
        }

        /// <summary>
        /// Restore saves and config folders
        /// </summary>
        /// <param name="config">RepoConfig instance of the settings file</param>
        /// <param name="user">UserItem that will restore</param>
        /// <param name="Folder">name of folder where was saved backups</param>
        /// <returns></returns>
        public bool Restore(RepoConfig config, UserItem user, String Folder = "Backups")
        {
            String ActualDir = BaseDirectory + Folder;
            if (Directory.Exists(ActualDir + @"\" + user.Name))
            {
                ActualDir += @"\" + user.Name;

                Dictionary<String, GameItem> games = config.GetGamesByUser(user);

                foreach (var gItem in games.Values)
                {
                    String gameDir = ActualDir + "\\" + gItem.Name;

                    foreach (var fItem in (gItem.SaveFolders.Concat(gItem.ConfigFolders)).ToDictionary(f => f.Key, f => f.Value).Values)
                    {
                        String fIni = gameDir + "\\" + fItem.DestinationName;
                        String fDest = fItem.Name;

                        if (fDest.Contains(TAG_USERFOLDER))
                        {
                            fDest = fDest.Replace(TAG_USERFOLDER, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                        }

                        if (fDest.Contains(TAG_SYSTEMDRIVE))
                        {
                            fDest = fDest.Replace(TAG_SYSTEMDRIVE, System.IO.DriveInfo.GetDrives()[0].Name.Replace("\\", ""));
                        }

                        CopyDirectory(fIni, fDest);
                    }

                }
            }


            return true;
        }



    }
}
