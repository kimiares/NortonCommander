using NortonCommander.Drawing;
using NortonCommander.Menu;
using System;
using System.Collections.Generic;


namespace NortonCommander
{

    class Program
    {

        public static ConsoleKeyInfo GetKey()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key==0) ;
            return key;
        }
        public static void ArrangeButtons()
        {
            int origWidth = Console.WindowWidth;
            int origHeight = Console.WindowHeight-2;
            int StartPosition = 1;
            int MenuLength = 10;
            int Space = 2;
            string MenuItem = "";
            for (int i = 0; i <= 9; i++)
            {
                MenuItem = SetLength("F" + (i + 1).ToString() + " " + Enum.GetName(typeof(ButtonEnum), i + 1), MenuLength);
                int y = i * (MenuLength + Space) + StartPosition;
                Button.Button MyButton = new Button.Button(MenuItem, y, origHeight, ConsoleColor.Black, ConsoleColor.Blue );
            }
        }

        // Increase or decrease of button size 
        public static string SetLength(string Phrase, int Length)
        {
            string result = Phrase;
            if (Phrase.Length < Length)
            {
                for (int i = Phrase.Length; i < Length; i++)
                {
                    result += " ";
                }


            }
            if (Phrase.Length > Length)
            {
                result = Phrase.Substring(0, Length);//, Phrase.Length-1);
            }


            return result;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<object> menu = new List<object>();
            for (int i = 0; i < 100; i++)
                menu.Add("word"+i.ToString());
            
            Console.ResetColor();
            ArrangeButtons();

            //List<object> Local = Panel.Panel.GetLocalList(menu, 95);

            //Panel.Panel.PanelInitializer(3, @"C:\\",@"D:\\");


            //тест

            Panel.Panel[] MyPanels = new Panel.Panel[2];
            MyPanels[0] = new Panel.Panel(@"C:\\", new Point(0, Console.WindowHeight - 4), new Point(Console.WindowWidth / 2 - 1, 1),3, ConsoleColor.Blue, ConsoleColor.Black, true);
            MyPanels[1] = new Panel.Panel(@"D:\\", new Point((Console.WindowWidth / 2 + 1), Console.WindowHeight - 4), new Point(Console.WindowWidth - 1, 1), 3, ConsoleColor.Blue, ConsoleColor.Black, true);
           
           
            
            
            
         
            ConsoleKey MyKey;

            do
            {

                MyKey = Program.GetKey().Key;

                switch (MyKey)
                {
                    case ConsoleKey.F8:
                        Menu.Menu MyMenu8 = new Menu.Menu("Deleting Files", new Drawing.Point(10, 14), new Drawing.Point(45, 7), 0, "Delete 12 files ?", ConsoleColor.Blue, ConsoleColor.Black);
                        break;
                    case ConsoleKey.F5:
                        Menu.Menu MyMenu5 = new Menu.Menu("Copy Files", new Drawing.Point(10, 14), new Drawing.Point(45, 7), 0, "Copy 12 files ?", ConsoleColor.Blue, ConsoleColor.Black);
                        break;
                    case ConsoleKey.Escape:
                    case ConsoleKey.UpArrow:
                        MyPanels[0].Move(false);
                        MyPanels[0].SetContent();
                    break;
                    case ConsoleKey.DownArrow:
                        MyPanels[0].Move(true);
                        MyPanels[0].SetContent();
                        break;
                    case ConsoleKey.Enter:
                     // Commander.OpenOrRunObject();
                        break;

                }
            }
            while (MyKey != ConsoleKey.Escape);

           



        }
    }
}
