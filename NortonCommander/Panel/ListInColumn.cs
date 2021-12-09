using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Panel
{
    class ListInColumn
    {
        public IList<object> Items;
        public int selectedIndex=0;
        public int maxCountList = 24;
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


        public ListInColumn(IList<object> items, int x, int y)
        {
            this.Items = items;
            this.startX = x;
            this.startY = y;
        }
        private void Draw(int x, int y)
        {
            Console.ResetColor();
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
        public List<object> Check(List<object> list)
        {
            
            if(list.Count> maxCountList)
            {
                return list.Skip(maxCountList).ToList();
            }
            else
            {
                return list;
            }

        }
        
    }
}
