using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Operations
{
    class Disk
    {
        public static List<DriveInfo> DiskList()
        {
            return DriveInfo.GetDrives().ToList();
        }

        
        



    }
}
