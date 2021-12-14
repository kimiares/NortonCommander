using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NortonCommander.Operations
{
    class Folder
    {
        public static void Delete(params FileSystemInfo[] directory)
        {

            if (directory.Length != 0)
            {
                foreach(var d in directory)
                {
                    if (Directory.Exists(d.FullName))
                    {
                        Directory.Delete(d.FullName, true);
                    }
                }
            }
            
        }
        public static void Create(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Create();

        }
        public static void Rename(FileSystemInfo directory, string newName)
        {
            if (Directory.Exists(directory.Name))
            {
                Directory.Move(directory.Name, newName);
            }
        }
       
        public void CopyFolder(FileSystemInfo directory, string pathToCopy)
        {
            if (!Directory.Exists(pathToCopy))
            {
                Directory.CreateDirectory(pathToCopy);

            }
                
            string[] files = Directory.GetFiles(directory.FullName);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(pathToCopy, name);
                File.Copy(file, dest);
            }


            DirectoryInfo di = new DirectoryInfo(directory.FullName);
            DirectoryInfo[] folders = di.GetDirectories();
            foreach (DirectoryInfo folder in folders)
            {
                string name = Path.GetFileName(folder.Name);
                string dest = Path.Combine(pathToCopy, name);
                CopyFolder(folder, dest);
            }
        }
        public List<string> Info(FileSystemInfo directory)
        {
            List<string> result = new List<string>();
            if (
                Directory.Exists(directory.FullName))
            {
                result.Add(directory.Name);
                result.Add(directory.CreationTime.ToString());
                result.Add(directory.LastWriteTime.ToString());
                result.Add(directory.LastAccessTime.ToString());

            }
            return result;
        }

        public static List<FileSystemInfo> GetFolders(string path)
        {
            List<FileSystemInfo> result = new List<FileSystemInfo>();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] folders = dir.GetDirectories();
                foreach (DirectoryInfo fol in folders)
                {
                    result.Add(fol);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
           
        }


        /*Search,
    Compare,
    Info,
    Copy,
    RenMov,
    MkDir,
    Delete,
    DiskInfo,
    Quit*/
    }
}
