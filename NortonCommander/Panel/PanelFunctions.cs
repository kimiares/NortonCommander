using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Panel
{
    public class PanelFunctions
    {

        private int selectObjIndex = 0;
        private int firstObjIndex = 0;
        private int maxObjectCount = 28;


        List<FileSystemInfo> objects = new List<FileSystemInfo>();




        public FileSystemInfo GetSelectObject()
        {
            if (this.objects != null && this.objects.Count != 0)
            {
                return this.objects[this.selectObjIndex];
            }
            else
            {
                throw new Exception("There is no objects");
            }

        }

        //public void TestPrint(IList<object> list)
        //{



        //    for(int i=0; i < list.Count; i++)
        //    {


        //        Console.WriteLine(i);
        //        if (i == maxObjectCount)
        //        {
        //            for(int j = i+1; j<list.Count; j++)
        //            {
        //                Console.WriteLine(j);
        //                if (j == maxObjectCount)
        //                {
        //                    // и так далее
        //                }
        //            }
        //        }
        //    }
    

       
        
    }
}
