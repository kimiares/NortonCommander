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
    public class Panel
    {

        //points initializer
        public static int ConsoleHeight = Console.WindowHeight;
        public static int ConsoleWidth = Console.WindowWidth;

       
        public static void PanelInitializer(int colcount)
        {
            //Console.SetWindowSize(120, 30);
            //Console.SetBufferSize(120, 30);
            Point firstStart = new Point(0, ConsoleHeight-4);
            Point firstFinish = new Point(ConsoleWidth / 2 - 1, 1);

            Point secondStart = new Point((ConsoleWidth / 2 + 1), firstStart.Y);
            Point secondFinish = new Point(ConsoleWidth-1, firstFinish.Y);
            
            Table firstTable = new Table(firstStart, firstFinish, colcount);
            Table secondTable = new Table(secondStart, secondFinish, colcount);
         }
        
        public static void PrintFirstRow(List<object> list)
        {

            //from menu
            ListInColumn consoleMenu = new ListInColumn(list, 1,2);
            ConsoleKeyInfo arrow;
            do
            {
                arrow = Console.ReadKey(true);
                switch (arrow.Key)
                {
                    case ConsoleKey.UpArrow:
                        consoleMenu.SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        consoleMenu.SelectedIndex++;
                        break;
                case ConsoleKey.Enter:
                    //DoAction(SelectedIndex);
                    break;
                default:
                        break;
               }
            } while (arrow.Key != ConsoleKey.Enter);
            Console.Clear();

        }
        

         

        
        public void PrintThirdRow(List<object> list)
        {
            foreach (var l in list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    Console.SetCursorPosition(((ConsoleWidth / 2) - 20) + 1, 2 + i);
                    Console.WriteLine(l);
                }

            }

        }
        public void PrintFourthRow(List<object> list)
        {
            foreach (var l in list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    Console.SetCursorPosition((ConsoleWidth / 2) + 1, 2 + i);
                    Console.WriteLine(l);
                }

            }

        }
        public void PrintFifthRow(List<object> list)
        {
            foreach (var l in list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    Console.SetCursorPosition((ConsoleWidth - 40) + 1, 2 + i);
                    Console.WriteLine(l);
                }

            }

        }
        public void PrintSixthRow(List<object> list)
        {
            foreach (var l in list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    Console.SetCursorPosition((ConsoleWidth - 20) + 1, 2 + i);
                    Console.WriteLine(l);
                }

            }

        }


        





    }
    public class Panel1
    {
        public static int PanelHeight = Console.WindowHeight;
        public static int PanelWidth = Console.WindowWidth;
        public int colCount;
        public string Name { get; set; }
        public ConsoleColor textColor { get; set; }
        public ConsoleColor backColor { get; set; }
        public int selectedObjectIndex = 0;
        public int firstObjectIndex = 0;
        public int maxObjectsPanel = PanelHeight - 1;
        public bool Active { get; set; }
        
        
        // отрисовка
        public Panel1(Point a, Point b, int ColCount)
        {
            new Table(a,b,ColCount);

            // начальная инициализация контента
            
        }

        //все, что выводится в панели
        List<FileSystemInfo> objects = new List<FileSystemInfo>();

        //начальная иницализация, можно диски закинуть, можно все файлы с первого диска(проще)
        public void SetContentInitial()
        {

            //this.objects.Add(Disk.DiskList());
        }


        // инициализация с путем
        public void SetContent(string path) // адрес диска
        {
            //запихнуть в файлы/папки
            DirectoryInfo dir = new DirectoryInfo(path);
            
            DirectoryInfo[] folders = dir.GetDirectories();
            foreach (DirectoryInfo fol in folders)
            {
                this.objects.Add(dir);
            }

            FileInfo[] files = dir.GetFiles();
            
            foreach (FileInfo file in files)
            {
                this.objects.Add(file);
            }

        }


        public void PrintObjects(List<FileSystemInfo> list)
        {
            foreach(FileSystemInfo f in this.objects)
            {
                //выводим
            }
        }

        //обновить данные в панели или саму панель?
        public void RefreshPanel()
        {
            //если меню было и нет
        }

        //при изменении объектов в колонке нужно закрасить действующие, а потом выводить
        
        
        //перенести в тейбл
        public void RefreshContent()
        {
            for (int i = 1; i < maxObjectsPanel; i++)
            {
              //  Console.SetCursorPosition(//начало колонки, там где текст);
              //  Console.Write(new String(' ', //ширина колонки);
            }

        }

        public void SwitchPanel()
        {
            if (this.Active)
            {

            }
        }

        //при нажатии энтера мы либо открываем, либо запускаем*
        
        // в класс повыше
        public void OpenOrRunObject(FileSystemInfo file)
        {
            
            
            if(file is DirectoryInfo)
            {
                Directory.GetDirectories(file.FullName);
                //PrintObjects();
            }
            if(file is FileInfo)
            {
                Process.Start(file.FullName);
            }
        }








    }
}
