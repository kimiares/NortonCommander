using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Operations
{
    class Folder
    {
        private void Delete(string path)
        {

            
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }



        }
        public void Create(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Create();

        }
        public void Rename()
        {

        }
        public object[] Search(string mask, string path)
        {
           return Directory.GetFiles(path, mask, SearchOption.AllDirectories);
            //print into panel
        }
        public void Copy()
        {

        }
        public string Info(DirectoryInfo directory)
        {
            return $"{directory.Name}{directory.FullName}{directory.CreationTime}";
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
