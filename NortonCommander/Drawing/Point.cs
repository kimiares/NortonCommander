using System;


namespace NortonCommander.Drawing
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;

        }

        public void Draw(string symb)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(symb);

        }
    }
}
