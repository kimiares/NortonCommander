using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panel
{
    class ListItems
    {
        private List<object> items;
        private int selected;
        private int startX;
        private int startY;


        public ListItems(List<object> MenuItems, int x, int y, int Index = 0 )
        {
            this.items = MenuItems;
            this.selected = Index;
            this.startX = x;
            this.startY = y;
        }

        //show in console
        public int Show(int startX, int startY)
        {

            
            for(var i = 0; i<items.Count; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                if (items.IndexOf(i) == selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    //Console.SetCursorPosition(startX, startY + i);
                    Console.WriteLine(items.IndexOf(i));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(items.IndexOf(i));
                }
            }

            Console.SetCursorPosition(startX, startY);
            ConsoleKeyInfo pressed = Console.ReadKey();
            ManageMenu(pressed.Key);
            return selected;
        }
        //take a choise
        private void ManageMenu(ConsoleKey Key)
        {

            //for (int i = 0; i < items.Count + 2; i++)
            //{
            //    Console.SetCursorPosition(0, Console.CursorTop - 1);
            //    Console.Write(new string(' ', Console.WindowWidth));
            //}
            if (Key == ConsoleKey.DownArrow && selected + 1 < items.Count)
            {
                selected += 1;
            }

            if (Key == ConsoleKey.UpArrow && selected - 1 >= 0)
            {
                selected -= 1;
            }
            if (Key == ConsoleKey.Enter) return;
            Show(startX, startY);
        }
    }
}
