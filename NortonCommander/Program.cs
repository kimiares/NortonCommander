using NortonCommander.Menu;
using System;
using System.Collections.Generic;


namespace NortonCommander
{

    class Program
    {

       
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
            List<object> menu = new List<object>();
            for (int i = 0; i < 100; i++)
                menu.Add("word"+i.ToString());
            
            Console.ResetColor();
            ArrangeButtons();

            List<object> Local = Panel.Panel.GetLocalList(menu, 95);

            Panel.Panel.PanelInitializer(3, @"C:\\",@"D:\\");

          //  Panel.Panel.PrintFirstRow (Local);

            Menu.Menu MyMenu = new Menu.Menu("Deleting Files",new Drawing.Point(10,14),new Drawing.Point (45,7),0, "Delete 12 files ?") ;
            Console.ReadKey();
            MyMenu.EraseMenu();
            //MyMenu.Draw( );


           

            Console.ReadKey();


        }
    }
}
