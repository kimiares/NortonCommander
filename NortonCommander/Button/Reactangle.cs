using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Button
{
    public class Reactangle
    {
       
        public Reactangle(string text, int x, int y, ConsoleColor textcolor, ConsoleColor backcolor)
        {
            Text = text;
            X = x;
            Y = y;
            TextColor = textcolor;
            BackColor = backcolor;
            Draw();
        }
        public int Size { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor BackColor { get; set; }
        public void Draw()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.BackgroundColor = this.BackColor;
            Console.ForegroundColor = this.TextColor;
            Console.Write(this.Text);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
