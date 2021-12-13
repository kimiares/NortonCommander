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
     class Panel:Table
    {

        public static int PanelHeight = Console.WindowHeight;
        public static int PanelWidth = Console.WindowWidth;
        public static int maxObjectsPanel = PanelHeight - 6;
        public static int columnWidth = PanelWidth / 6; //ширина консоли/колво панелей/колво столбцов
        public static Point columnFirstStart;// = new Point(2, 2);
        //public static Point columnSecondPoint;
        //public static Point columnThirdPoint;

        public static int selectedObjectIndex = 0;
       
        public int firstObjectIndex = 0;
        
        public bool Active { get; set; }
        // отрисовка
        public Panel(string name, Point a, Point b, int colcount, ConsoleColor textColor, ConsoleColor backColor, bool active) 
            : base(name, a, b, colcount,  textColor,  backColor)
        {
            columnFirstStart = new Point(a.X + 2, 2);  
            this.Active = active;
            SetContent();
            // начальная инициализация контента
        }

        //все, что выводится в панели
        List<FileSystemInfo> objects = new List<FileSystemInfo>();

        public void Move(bool direction)
        {
            if (direction) selectedObjectIndex++;
            else
                selectedObjectIndex--;
        }

        // инициализация с первого диска 
        public void SetContent()
        {
            if (this.Active)
            {
                //Console.Clear();
                string path = Disk.GetFirstDiskPath();
                this.objects.Clear();
                this.objects.AddRange(Folder.GetFolders(path));
                this.objects.AddRange(Files.GetFiles(path));
                //Panel.PrintFirstRow(this.objects);
               
                PrintObjects(this.objects);
            }
        }


       
        //если меньше чем максимум - просто выводим
        public static void PrintObjects(List<FileSystemInfo> list)
        {
           
            int sdvig = 0;
            if (selectedObjectIndex == -1) selectedObjectIndex =  list.Count - 1;

            if (selectedObjectIndex >= maxObjectsPanel)
            {
                
                sdvig = Math.Abs(selectedObjectIndex - maxObjectsPanel);
            }
            if (selectedObjectIndex == list.Count)
                selectedObjectIndex = 0;

                for (int i = 0; i < (list.Count < maxObjectsPanel ? list.Count:maxObjectsPanel); i++)
                {
                    Console.SetCursorPosition(columnFirstStart.X, columnFirstStart.Y + i);
                    if (i == selectedObjectIndex-sdvig)
                    {
                        var tmp = Console.BackgroundColor;
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = tmp;
                        Console.SetCursorPosition(columnFirstStart.X, columnFirstStart.Y + i);
                        Console.WriteLine(CutName(list[i+sdvig].Name, columnWidth-4));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(CutName(list[i+sdvig].Name, columnWidth-4));
                        Console.SetCursorPosition(columnFirstStart.X + columnWidth, columnFirstStart.Y + i);
                        Console.Write(list[i+sdvig].CreationTime.ToShortDateString());
                        Console.SetCursorPosition(columnFirstStart.X + columnWidth*2, columnFirstStart.Y + i);
                        Console.Write(list[i+sdvig].CreationTime.ToShortTimeString());
                }


                    //if (selectedObjectIndex == maxObjectsPanel)
                    //{
                    //    temp = list.Skip(maxObjectsPanel).ToList();
                    //    PrintObjects(temp);
                    //}
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
                Console.SetCursorPosition(columnFirstStart.X, columnFirstStart.Y);
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
        public static string CutName(string name, int length)
        {
            if (name.Length > length)
            {
                name = name.Substring(0, length);
            }
            return name;
        }








    }
}
