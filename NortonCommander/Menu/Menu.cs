using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Menu
{
    class Menu
    {
        public string Text { get; set; }

        public int Ax { get; set; }
        public int Ay { get; set; }
        public int Bx { get; set; }
        public int By { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor BackColor { get; set; }
        public bool OpStatus { get; set; }

        public void Draw()
        {

        }

        public void AddButtons()
        {


        }

        public void ChangeOpStatus()
        {
            OpStatus = !OpStatus;
        }

        public void DoOperation()
        {

        }
    }
}
