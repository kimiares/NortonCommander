using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NortonCommander.Operations
{
    class Files
    {
        //search files and directories?
        public static List<FileSystemInfo> Search(string mask, string disk)
        {
            Regex regMask = TransformMaskToRegex(mask);
            List<FileSystemInfo> resultFiles = new List<FileSystemInfo>();
            
            DirectoryInfo directory = new DirectoryInfo(disk);
            
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach(DirectoryInfo di in directories)
            {
                if (regMask.IsMatch(di.Name))
                {
                    resultFiles.Add(di);
                }
            }
            
            FileInfo[] files = directory.GetFiles();
            foreach(FileInfo f in files)
            {
                if (regMask.IsMatch(f.Name))
                {
                    resultFiles.Add(f);
                }
            }
            return resultFiles;


        }
        public void Compare(string path)
        {

        }
        public static List<string> Info(FileSystemInfo file)
        {
            List<string> result = new List<string>();
            if (File.Exists(file.FullName))
            {
                result.Add(file.Name);
                result.Add(file.CreationTime.ToString());
                result.Add(file.LastWriteTime.ToString());
                result.Add(file.LastAccessTime.ToString());
                
            }
            return result;

        }

        public static void Rename(FileSystemInfo file, string newName)
        {

            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("New name cannot be null or blank", newName);
            }
            else
            {
                if (File.Exists(file.Name))
                {
                    File.Move(file.Name, newName);
                }
                else
                {
                    throw new Exception("file not found");
                }

            }
 
                
        }
        public static void CopyFile(FileSystemInfo file, string pathToCopy)
        {
            if (File.Exists(file.Name))
            {
                File.Copy(file.Name, Path.Combine(pathToCopy, file.Name));
            }
            else
            {
                throw new Exception("file not found");
            }
        }
        

        //delete files and directories
        public static void DeleteFilesAndFolders(params FileSystemInfo[] filesToDelete)
        {
            if(filesToDelete.Length!=0)
            {
                foreach (FileSystemInfo file in filesToDelete)
                {
                    if(file is FileInfo)
                    {
                        if (File.Exists(file.FullName))
                        {
                            File.Delete(file.FullName);

                        }
                    }
                    if(file is DirectoryInfo)
                    {

                        Folder.Delete(file);
                        
                    }
                    
                }
            }
            
        }

        public static Regex TransformMaskToRegex(string mask)
        {
            mask = mask.Replace(".", @"\.");
            mask = mask.Replace("?", ".");
            mask = mask.Replace("*", ".*");
            mask = "^" + mask + "$";

            Regex regMask = new Regex(mask, RegexOptions.IgnoreCase);
            return regMask;

        }



        public static List<FileSystemInfo> GetFiles(string path)
        {
            List<FileSystemInfo> result = new List<FileSystemInfo>();
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                result.Add(file);
            }
            return result;
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
