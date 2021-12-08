using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panel
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
        //private void CheckObject(int index)
        //{
        //    int offsetY = this.selectObjIndex - this.firstObjIndex;
        //    Console.SetCursorPosition(this.left + 1, this.top + offsetY + 1);

        //    Console.ForegroundColor = ConsoleColor.Black;
        //    Console.BackgroundColor = ConsoleColor.White;

        //    this.PrintObject(index);

        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.BackgroundColor = ConsoleColor.Black;
        //}

        //private void UncheckObject(int index)
        //{
        //    int offsetY = this.selectObjIndex - this.firstObjIndex;
        //    Console.SetCursorPosition(this.left + 1, this.top + offsetY + 1);

        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.BackgroundColor = ConsoleColor.Black;

        //    this.PrintObject(index);
        //}


        ////keys
        //public void Keys(ConsoleKeyInfo key)
        //{
        //    switch (key.Key)
        //    {
        //        case ConsoleKey.UpArrow:
        //            this.Up();
        //            break;
        //        case ConsoleKey.DownArrow:
        //            this.Down();
        //            break;
        //        case ConsoleKey.Home:
        //            this.Begin();
        //            break;
        //        case ConsoleKey.End:
        //            this.End();
        //            break;
        //        case ConsoleKey.PageUp:
        //            this.PageUp();
        //            break;
        //        case ConsoleKey.PageDown:
        //            this.PageDown();
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //private void Down()
        //{
        //    if (this.selectObjIndex >= this.firstObjIndex + this.maxObjectCount - 1)
        //    {
        //        this.firstObjIndex += 1;
        //        if (this.firstObjIndex + this.maxObjectCount >= this.objects.Count)
        //        {
        //            this.firstObjIndex = this.objects.Count - this.maxObjectCount;
        //        }
        //        this.selectObjIndex = this.firstObjIndex + this.maxObjectCount - 1;
        //        //refresh page
        //        //this.UpdateContent(false);
        //    }

        //    else
        //    {
        //        if (this.selectObjIndex >= this.objects.Count - 1)
        //        {
        //            return;
        //        }
        //        this.DeactivateObject(this.selectObjIndex);
        //        this.selectObjIndex++;
        //        this.CheckObject(this.selectObjIndex);
        //    }
        //}




        //private void PrintListObj()
        //{
        //    if (this.objects.Count == 0)
        //    {
        //        return;
        //    }
        //    int count = 0;

        //    int lastElement = this.firstObjIndex + this.maxObjectCount;
        //    if (lastElement > this.objects.Count)
        //    {
        //        lastElement = this.objects.Count;
        //    }


        //    if (this.selectObjIndex >= this.objects.Count)
        //    {
        //        selectObjIndex = 0;
        //    }

        //    for (int i = this.firstObjIndex; i < lastElement; i++)
        //    {
        //        Console.SetCursorPosition(this.left + 1, this.top + count + 1);

        //        if (i == this.selectObjIndex && this.active == true)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Black;
        //            Console.BackgroundColor = ConsoleColor.White;
        //        }
        //        this.PrintObject(i);
        //        Console.ForegroundColor = ConsoleColor.White;
        //        Console.BackgroundColor = ConsoleColor.Black;
        //        count++;
        //    }
        //}


    }
}
