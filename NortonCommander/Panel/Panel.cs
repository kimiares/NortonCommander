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
        static public  int PanelHeight = Console.WindowHeight;
        static public  int PanelWidth  = Console.WindowWidth;
        static public  int maxObjectsPanel = PanelHeight - 6;
        public int ColumnWidth { get; set; } //ширина консоли/колво панелей/колво столбцов
        public Point ColumnFirstStart { get; set; } 
        public int SelectedObjectIndex { get; set; }
     //   public int firstObjectIndex = 0;
        public string Path { get; set; }
        public Panel(string name, Point a, Point b, int colcount, ConsoleColor textColor, ConsoleColor backColor)//, bool active) 
            : base(name, a, b, colcount,  textColor,  backColor)
        {
            SelectedObjectIndex = 0;
            ColumnWidth = PanelWidth / 6;
            ColumnFirstStart = new Point(a.X + 2, 2);
            //   this.Active = active;
            Path = name;
            SetContent();
            // начальная инициализация контента
        }

        //все, что выводится в панели
       public  List<FileSystemInfo> objects = new List<FileSystemInfo>();

        public void Move(bool direction)
        {
            if (direction) SelectedObjectIndex++;
            else
                SelectedObjectIndex--;
        }
         public void SetContent()
        {
                RefreshContent();
                this.objects.Clear();
                this.objects.AddRange(Folder.GetFolders(Path));
                this.objects.AddRange(Files.GetFiles(Path));
                PrintObjects(this.objects);
        }
       
        //если меньше чем максимум - просто выводим
        public void PrintObjects(List<FileSystemInfo> list)
        {
            int sdvig = 0;
            if (SelectedObjectIndex == -1) SelectedObjectIndex =  list.Count - 1;
            if (SelectedObjectIndex >= maxObjectsPanel)
            {
                sdvig = Math.Abs(SelectedObjectIndex - maxObjectsPanel)+1;
            }
            if (SelectedObjectIndex == list.Count)
            {
                SelectedObjectIndex = 0;
                sdvig = 0;
            }
                for (int i = 0; i < (list.Count < maxObjectsPanel ? list.Count:maxObjectsPanel); i++)
                {
                    Console.SetCursorPosition(ColumnFirstStart.X, ColumnFirstStart.Y + i);
               
                if (i == SelectedObjectIndex - sdvig)
                {
                    var tmp = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = tmp;
                }
                        Console.SetCursorPosition(ColumnFirstStart.X, ColumnFirstStart.Y + i);
                        Console.WriteLine(CutName(list[i+sdvig].Name, ColumnWidth-4));
                        Console.ResetColor();
                        Console.SetCursorPosition(ColumnFirstStart.X + ColumnWidth, ColumnFirstStart.Y + i);
                        Console.Write(list[i + sdvig].CreationTime.ToShortDateString());
                        Console.SetCursorPosition(ColumnFirstStart.X + ColumnWidth * 2, ColumnFirstStart.Y + i);
                        Console.Write(list[i + sdvig].CreationTime.ToShortTimeString());
                }
         }

        internal void OpenOrRunObject()
        {
            throw new NotImplementedException();
        }

        public void RefreshContent()
        {
            for (int i = 0; i < maxObjectsPanel; i++)
            {
                Console.SetCursorPosition(ColumnFirstStart.X, ColumnFirstStart.Y+i);
                Console.Write(new String(' ', ColumnWidth-3));
                Console.SetCursorPosition(ColumnFirstStart.X + ColumnWidth, ColumnFirstStart.Y + i);
                Console.Write(new String(' ', ColumnWidth - 4));
                Console.SetCursorPosition(ColumnFirstStart.X + ColumnWidth * 2, ColumnFirstStart.Y + i);
                Console.Write(new String(' ', ColumnWidth - 5));
            }
        }

        public static string CutName(string name, int length)
        {
            if (name.Length > length)
                name = name.Substring(0, length);
             return name;
        }
    }
}
