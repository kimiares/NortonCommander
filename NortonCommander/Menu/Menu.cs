using NortonCommander.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Menu
{
     class Menu : Table
    {
        public string Text { get; set; }
        public bool ActiveButton { get; set; }
        public bool GetKey { get; private set; }

        public Menu(string name, Point a, Point b,int colcount, string text, ConsoleColor textcolor, ConsoleColor backcolor) :base(name, a,b,colcount, textcolor,backcolor)
        {
            Text = text;
            ActiveButton = false;
            ClearMenuField();
            AddButtons();
            Do();
        }

        public void AddButtons()
        {
            Button.Reactangle ButtonYes = new Button.Reactangle("Yes",A.X+5 ,A.Y-1, ConsoleColor.Red, ActiveButton ? ConsoleColor.Blue: ConsoleColor.White);
            Button.Reactangle ButtonNO = new Button.Reactangle("No", B.X - 10, A.Y - 1, ConsoleColor.Red, ActiveButton ? ConsoleColor.White : ConsoleColor.Blue);
            ButtonYes.Draw();
            ButtonNO.Draw();
            Console.ResetColor();
        }

        public void ClearMenuField()
        {
            Console.ResetColor();
            for (int x = A.X+1; x < B.X; x++)
               for (int y = B.Y+1; y < A.Y; y++)
               {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
        }
        public void EraseMenu()
        {
            Console.ResetColor();
            for (int x = A.X; x <= B.X; x++)
                for (int y = B.Y; y <= A.Y; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
        }

        public void ChangeActiveButton()
        {
            ActiveButton = !ActiveButton;
            AddButtons();
        }

        public void Do()
        {
            ConsoleKey MyKey;
            do
            {
                MyKey = Program.GetKey().Key;
                switch (MyKey)
                {
                    case ConsoleKey.Tab:
                    ChangeActiveButton();
                    break;
                    case ConsoleKey.Escape:
                        ActiveButton = false;
                        MyKey = ConsoleKey.Enter;
                        break;
                    
                }
            }
            while (MyKey != ConsoleKey.Enter);

            if (ActiveButton)
            { 
            // Выполнить операцию  !
            
            }
            //Ничего не делаем, выход из меню


            EraseMenu();
        }
    }
}
