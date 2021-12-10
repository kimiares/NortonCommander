using NortonCommander.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Panel
{
    public class Panel
    {
        public static int ConsoleHeight = Console.WindowHeight;
        public static int ConsoleWidth = Console.WindowWidth;
        public static int CountVerticalLines = ConsoleHeight - 6;
        public int SelectedIndex;

        public ConsoleColor TextColor { get; set; }
        public ConsoleColor BackColor { get; set; }

        public static void PanelInitializer(int colcount, string Panel1Name, string Panel2Name)
        {
            //Console.SetWindowSize(120, 30);
            //Console.SetBufferSize(120, 30);
            Point firstStart = new Point(0, ConsoleHeight-4);
            Point firstFinish = new Point(ConsoleWidth / 2 - 1, 1);

            Point secondStart = new Point((ConsoleWidth / 2 + 1), firstStart.Y);
            Point secondFinish = new Point(ConsoleWidth-1, firstFinish.Y);
            
            Table firstTable = new Table(Panel1Name, firstStart, firstFinish, colcount, ConsoleColor.Blue, ConsoleColor.Black);
            Table secondTable = new Table(Panel2Name,secondStart, secondFinish, colcount, ConsoleColor.Blue, ConsoleColor.Black);
         }


        public static List<object> GetLocalList(List<object> InfoLIst, int CurrentIndex)
        {
            List<object> myList = new List<object>();
            if ((CurrentIndex + CountVerticalLines) > InfoLIst.Count)
            { CurrentIndex = InfoLIst.Count - CountVerticalLines; }
            
            for (int i = CurrentIndex; i < CurrentIndex + CountVerticalLines; i++)
            {
                myList.Add(InfoLIst[i]);
            }
            return myList;
        }

        public static void PrintFirstRow(List<object> list)
        {
            //from menu
            ListInColumn consoleMenu = new ListInColumn(list, 2,2);
            
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
     }
}
