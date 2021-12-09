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
}
