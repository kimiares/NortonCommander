using NortonCommander.Drawing;
using NortonCommander.Operations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Panel
{
     class PanelFunctions:Table
    {

        public static int PanelHeight = Console.WindowHeight;
        public static int PanelWidth = Console.WindowWidth;
        public static int maxObjectsPanel = PanelHeight - 6;
        public static int columnWidth;
        public static Point columnStartPoint;

        public int selectedObjectIndex = 0;
        public int firstObjectIndex = 0;
        
        public bool Active { get; set; }


        // отрисовка
        public PanelFunctions(string name, Point a, Point b, int colcount, ConsoleColor textColor, ConsoleColor backColor) 
            : base(name, a, b, colcount,  textColor,  backColor)
        {

            //this.textColor = textColor;
            //this.backColor = backColor;
            SetContent();

            // начальная инициализация контента

        }

        //все, что выводится в панели
        List<FileSystemInfo> objects = new List<FileSystemInfo>();




        // инициализация с первого диска 
        public void SetContent()
        {
            string path = Disk.GetFirstDiskPath();
            this.objects.AddRange(Folder.GetFolders(path));
            this.objects.AddRange(Files.GetFiles(path));
            PrintObjects(this.objects);

        }

        //если меньше чем максимум - просто выводим, если больше - выводим 
        public void PrintObjects(List<FileSystemInfo> list)
        {

            List<FileSystemInfo> temp = new();
            for (int i = 0; i < list.Count; i++)
                {
                Console.SetCursorPosition(columnStartPoint.X, columnStartPoint.Y + i);
                    if (i == selectedObjectIndex)
                    {
                        var tmp = Console.BackgroundColor;
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = tmp;
                        Console.WriteLine(list[i].Name);
                        Console.ForegroundColor = Console.BackgroundColor;
                        Console.BackgroundColor = tmp;
                    }
                Console.WriteLine(list[i].Name);
                if (i == maxObjectsPanel)
                {
                    temp = list.Skip(maxObjectsPanel).ToList();
                    PrintObjects(temp);
                }
                }
            
            
        }
        public static List<FileSystemInfo> GetLocalList(List<FileSystemInfo> list, int currentIndex)
        {
            List<FileSystemInfo> resultList = new List<FileSystemInfo>();
            if ((currentIndex + maxObjectsPanel) > list.Count)
            { currentIndex = list.Count - maxObjectsPanel; }

            for (int i = currentIndex; i < currentIndex + maxObjectsPanel; i++)
            {
                resultList.Add(list[i]);
            }
            return resultList;
        }

        //обновить данные в панели или саму панель?
        public void RefreshPanel()
        {
            //если меню было и нет
        }

        //при изменении объектов в колонке нужно закрасить действующие, а потом выводить


        //перенести в тейбл?
        //заливает все строки столбца пробелами
        public void RefreshContent()
        {
            for (int i = 1; i < maxObjectsPanel; i++)
            {
                Console.SetCursorPosition(columnStartPoint.X, columnStartPoint.Y);
                Console.Write(new String(' ', columnWidth));
            }

        }

        public void SwitchPanel()
        {
            if (this.Active)
            {
                this.Active = !Active;
            }
        }

       
       





    }
}
