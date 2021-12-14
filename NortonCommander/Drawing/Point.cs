using System;


namespace NortonCommander.Drawing
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symb { get; }

        public Point(int x, int y) : this(x, y, ' ') { }
        
        public Point(int x, int y, char symb)
        {
            this.X = x;
            this.Y = y;
            this.Symb = symb;

        }

        public void Draw() => Draw(Symb);

        public void Draw(char symb)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(symb);

        }
    }
}
