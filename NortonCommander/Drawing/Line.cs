using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Drawing
{
    class Line: List<Point>
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Line(Point a, Point b)
        {
            this.A = a;
            this.B = b;
            Dots(this.A, this.B);

        }
        public bool isVertical(Point A, Point B)
        {
            bool result = false;
            if (A.Y == B.Y)
            {
                return true;
            }
            return result;
        }
        public bool isGorisontal(Point A, Point B)
        {
            bool result = false;
            if (A.X == B.X)
            {
                return true;
            }
            return result;
        }
        internal void DotsOnLineVertical(Point start, Point finish)
        {
            for (int i = Math.Min(start.X, finish.X); i < Math.Max(start.X, finish.X); i++)
            {

                this.Add(new Point(i, start.Y));

            }
        }
        internal void DotsOnLineHorizontal(Point start, Point finish)
        {
            for (int y = Math.Min(start.Y, finish.Y); y <= Math.Max(start.Y, finish.Y); y++)
            {

                this.Add(new Point(start.X, y));

            }


        }
        internal void Draw()
        {

            if (isGorisontal(this[0], this[1]))
            {
                foreach (Point point in this)
                {
                    point.Draw("║");
                }
            }
            else
            {
                foreach (Point point in this)
                {
                    point.Draw("═");
                }

            }


        }
        internal void Dots(Point a, Point b)
        {
            if (isVertical(a, b))
            {
                DotsOnLineVertical(a, b);
            }
            else if (isGorisontal(a, b))
            {
                DotsOnLineHorizontal(a, b);
            }

        }

    }
}

