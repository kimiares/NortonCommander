using System;
using System.Collections.Generic;
using NortonCommander.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
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

                if (file is DirectoryInfo)
                {
                    Directory.GetDirectories(file.FullName);
                    //PanelFunctions.PrintObject();
                }
                if (file is FileInfo)
                {
                    Process.Start(file.FullName);
                }
            
            
        }
    }
}
