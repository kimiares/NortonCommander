using System;
using System.Collections.Generic;
using NortonCommander.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using NortonCommander.Panel;
using NortonCommander.Operations;
using NortonCommander.Panel;

namespace NortonCommander
{
    public class Commander
    {
        
        public Commander()
        {
            //Panel.PanelFunctions panel1 = new Panel.PanelFunctions();
            //Panel.PanelFunctions panel2 = new Panel.PanelFunctions();

        }
        public static void OpenOrRunObject(FileSystemInfo file)
        {
            List<FileSystemInfo> result = new List<FileSystemInfo>();
            if (file is DirectoryInfo)
            {
                result.AddRange(Folder.GetFolders(file.FullName));   
                //PanelFunctions.PrintObject();
            }
            if (file is FileInfo)
            {
                
                result.AddRange(Files.GetFiles(file.FullName));
            }
            Panel.Panel.PrintObjects(result);


        }
        


    }
}
