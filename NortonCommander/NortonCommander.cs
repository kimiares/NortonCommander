using System;
using System.Collections.Generic;
using NortonCommander.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NortonCommander
{
    class NortonCommander
    {
        
        public NortonCommander()
        {
            //Panel.PanelFunctions panel1 = new Panel.PanelFunctions();
            //Panel.PanelFunctions panel2 = new Panel.PanelFunctions();

        }
        public void OpenOrRunObject(FileSystemInfo file)
        {


            if (file is DirectoryInfo)
            {
                Directory.GetDirectories(file.FullName);
                //PrintObjects();
            }
            if (file is FileInfo)
            {
                Process.Start(file.FullName);
            }
        }
    }
}
