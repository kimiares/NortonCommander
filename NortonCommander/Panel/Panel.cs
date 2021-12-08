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

        //points initializer
        int wh = Console.WindowHeight - 4;
        public int ww = Console.WindowWidth;
        public static void PointsInitializer()
        {
            Console.SetWindowSize(120, 30);
            Console.SetBufferSize(200, 200);
            var wh = Console.WindowHeight - 4;
            var ww = Console.WindowWidth;
            Point firstStart = new Point(0, wh);
            Point firstFinish = new Point((ww / 2) - 1, 1);
            Point secondStart = new Point((ww / 2 + 1), wh);
            Point secondFinish = new Point(119, 1);
            Table firstTable = new Table(firstStart, firstFinish);
            Table secondTable = new Table(secondStart, secondFinish);
            
            firstTable.Draw();
            secondTable.Draw();
            
            Console.SetCursorPosition(0, 1);
            Console.Write("╔");
            Console.SetCursorPosition((ww / 2) - 1, 1);
            Console.Write("╗");
            Console.SetCursorPosition(0, wh);
            Console.Write("╚");
            Console.SetCursorPosition((ww / 2) - 1, wh);
            Console.Write("╝");
            Console.SetCursorPosition((ww / 2) - 21, 1);
            Console.Write("═");
            Console.SetCursorPosition((ww / 2) - 41, 1);
            Console.Write("═");
            Console.SetCursorPosition((ww / 2) - 21, wh);
            Console.Write("═");
            Console.SetCursorPosition((ww / 2) - 41, wh);
            Console.Write("═");

            Console.SetCursorPosition((ww / 2 + 1), 1);
            Console.Write("╔");
            Console.SetCursorPosition(ww - 1, 1);
            Console.Write("╗");
            Console.SetCursorPosition((ww / 2 + 1), wh);
            Console.Write("╚");
            Console.SetCursorPosition(ww - 1, wh);
            Console.Write("╝");

            Console.SetCursorPosition((ww - 21), 1);
            Console.Write("═");
            Console.SetCursorPosition((ww - 41), 1);
            Console.Write("═");
            Console.SetCursorPosition((ww - 21), wh);
            Console.Write("═");
            Console.SetCursorPosition((ww - 41), wh);
            Console.Write("═");
            //Console.BackgroundColor = ConsoleColor.Cyan;

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
        public static void PrintSecondRow(List<object> list)
        {

            


            //foreach (var l in list)
            //{
            //    for (var i = 0; i < list.Count; i++)
            //    {
            //        Console.SetCursorPosition(((ww/2)-40)+1,2+i);
            //        Console.WriteLine(l);
            //    }

            //}

        }
        public void PrintThirdRow(List<object> list)
        {
            foreach (var l in list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    Console.SetCursorPosition(((ww / 2) - 20) + 1, 2 + i);
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
                    Console.SetCursorPosition((ww / 2) + 1, 2 + i);
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
                    Console.SetCursorPosition((ww - 40) + 1, 2 + i);
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
                    Console.SetCursorPosition((ww - 20) + 1, 2 + i);
                    Console.WriteLine(l);
                }

            }

        }


        





    }
}
