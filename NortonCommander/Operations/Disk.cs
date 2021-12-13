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
        public static string GetFirstDiskPath()
        {
            List<DriveInfo> allDisk = DiskList();
            DriveInfo currentDrive = allDisk[0];

            return currentDrive.Name;
        }
        
        



    }
}
