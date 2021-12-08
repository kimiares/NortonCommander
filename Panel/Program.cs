using Panel.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panel
{
    class Program
    {
        static void Main(string[] args)
        {

            List<object> menu = new List<object> { "word1", "word2", "word3" };

            Panel.PointsInitializer();

            Panel.PrintFirstRow(menu);
            //Panel.PrintSecondRow(menu);


            //ConsoleMenu consoleMenu = new ConsoleMenu(menu);
            //ConsoleKeyInfo arrow;
            //do
            //{
            //    arrow = Console.ReadKey(true);
            //    switch (arrow.Key)
            //    {
            //        case ConsoleKey.UpArrow:
            //            consoleMenu.SelectedIndex--;
            //            break;
            //        case ConsoleKey.DownArrow:
            //            consoleMenu.SelectedIndex++;
            //            break;
            //        default:
            //            break;
            //    }
            //} while (arrow.Key != ConsoleKey.Enter);
            //Console.Clear();

            Console.ReadKey();
        }
       
    }
}
        
    

