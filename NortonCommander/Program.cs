using NortonCommander.Drawing;
using NortonCommander.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using NortonCommander.Operations;

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
                StringBuilder menuItemtest = new StringBuilder();
                //MenuItem = SetLength("F" + (i + 1).ToString() + " " + Enum.GetName(typeof(ButtonEnum), i + 1), MenuLength);
                menuItemtest = menuItemtest.Append('F')
                    .Append((i + 1)
                    .ToString())
                    .Append(' ')
                    .Append(Enum.GetName(typeof(ButtonEnum),i+1));
                MenuItem = SetLength(menuItemtest.ToString(), MenuLength);
                int y = i * (MenuLength + Space) + StartPosition;
                Button.Reactangle MyButton = new Button.Reactangle(MenuItem.ToString(), y, origHeight, ConsoleColor.Black, ConsoleColor.Blue );
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
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;        
            Console.ResetColor();
            ArrangeButtons();
            //тест

        
            Panel.Panel[] MyPanels = new Panel.Panel[2];

          

            MyPanels[0] = new Panel.Panel(@"C:\", new Point(0, Console.WindowHeight - 4), new Point(Console.WindowWidth / 2 - 1, 1),3, ConsoleColor.Blue, ConsoleColor.Black);
            MyPanels[1] = new Panel.Panel(@"C:\Windows", new Point((Console.WindowWidth / 2 + 1), Console.WindowHeight - 4), new Point(Console.WindowWidth - 1, 1), 3, ConsoleColor.Blue, ConsoleColor.Black);

            //bool i = false;
            //Panel.Panel activePanel = MyPanels[i ? 0 : 1];
            
            int my = 0;
            bool i = false;
            ConsoleKey MyKey;
            do
            {
                MyKey = Program.GetKey().Key;
                
                Panel.Panel activePanel = MyPanels[i ? 0 : 1];


                switch (MyKey)
                {
                    
                    case ConsoleKey.F1:
                        
                    case ConsoleKey.F2:
                    case ConsoleKey.F3:
                        my = activePanel.A.X;
                    Menu.Menu MyMenu8 = new Menu.Menu("Deleting Files",
                        new Point(activePanel.A.X+10, 14), 
                        new Point(activePanel.A.X+45, 7), 
                        0, 
                        "Delete 12 files ?",
                        ConsoleColor.Blue, 
                        ConsoleColor.Black);

                        activePanel.SetContent();
                        activePanel.Draw();
                        break;
                    case ConsoleKey.F8:
                        Files.DeleteFilesAndFolders();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.UpArrow:
                        activePanel.Move(false);
                        activePanel.SetContent();
                    break;
                    case ConsoleKey.DownArrow:
                        activePanel.Move(true);
                        activePanel.SetContent();
                        break;
                    case ConsoleKey.Enter:
                        activePanel.OpenOrRunObject();
                        activePanel.SetContent();
                        break;
                    case ConsoleKey.Tab:
                        i = !i;
                        break;


                }
            }
            while (MyKey != ConsoleKey.Escape);

           



        }
    }
}
