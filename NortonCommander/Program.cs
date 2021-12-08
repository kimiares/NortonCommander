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
                MenuItem = SetLength("F" + (i + 1).ToString() + " " + Enum.GetName(typeof(Buttons), i + 1), MenuLength);
                int y = i * (MenuLength + Space) + StartPosition;
                Button.Button MyButton = new Button.Button(MenuItem, y, origHeight, ConsoleColor.Black, ConsoleColor.Blue);
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
            List<object> menu = new List<object> { "word1", "word2", "word3" };
            ArrangeButtons();
            Panel.Panel.PointsInitializer();
            Panel.Panel.PrintFirstRow(menu);


        }
    }
}
