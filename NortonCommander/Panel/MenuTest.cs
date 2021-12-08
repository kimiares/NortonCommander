using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panel
{
    class ConsoleMenu
    {
        public IList<object> Items;
        internal int selectedIndex;
        public int startX;
        public int startY;


        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                value = Math.Abs(value % Items.Count);
                selectedIndex = value;
                Draw(this.startX, this.startY);
            }
        }

        public object SelectedItem
        {
            get
            {
                return Items[selectedIndex];
            }
        }


        public ConsoleMenu(IList<object> items, int x, int y)
        {
            this.Items = items;
            this.startX = x;
            this.startY = y;
        }
        private void Draw(int x, int y)
        {
            //Console.Clear();
            for (int i = 0; i < Items.Count; i++)
            {
                Console.SetCursorPosition(x, y+i);
                if (i == selectedIndex)
                {
                    var tmp = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = tmp;
                    Console.WriteLine(Items[i]);
                    Console.ForegroundColor = Console.BackgroundColor;
                    Console.BackgroundColor = tmp;
                }
                else
                {
                    Console.WriteLine(Items[i]);
                }
            }
        }
        private void ManageMenu(ConsoleKeyInfo Key)
        {

        }
    }
}
