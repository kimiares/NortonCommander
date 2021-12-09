using NortonCommander.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Drawing
{
    class Table
    {

        internal List<Line> Lines;

       
        public List<Line> LinesInitializer(Point a, Point b, int ColCount)
        {
            List<Line> lines = new List<Line>()
            {
                new Line(a, new Point(b.X, a.Y)),
                new Line(new Point(b.X, a.Y), b),
                new Line(b, new Point(a.X, b.Y)),
                new Line(new Point(a.X, b.Y), a)
            };
            if (ColCount > 1)
            {
                int ColumnWidth = (b.X - a.X) / ColCount;
                for (int i = 1; i < ColCount; i++)
                {
                    lines.Add(new Line(new Point(a.X + i*ColumnWidth, a.Y), new Point((a.X + i*ColumnWidth), b.Y)));
                }
            }
            return lines;
        }

        public List<Point> GetCornersPoint()
        {
            List<Point> PointForCorners = new List<Point>();
            for (int i=0;i<4;i++)
                PointForCorners.Add(new Point(Lines[i].A.X, Lines[i].A.Y));
            return PointForCorners;

        }
        public List<Point> GetTCornersPoint()
        {
            List<Point> PointForTCorners = new List<Point>();
            if (Lines.Count > 4)
            {
                for (int i=4; i<Lines.Count;i++)
                    PointForTCorners.Add(new Point(Lines[i][0].X, Lines[i][0].Y));
            }
            return PointForTCorners;
        }

        public Table(Point a, Point b, int colcount)
        {
            Lines = LinesInitializer(a, b, colcount);
            Draw();
            DrawCorners(GetCornersPoint());
            DrawTCorners(GetTCornersPoint(), a.Y);

        }
        public virtual void Draw()
        {
            foreach (Line line in Lines)
            {
                line.Draw();
            }
         }

        public void DrawCorners(List<Point> Points)
        {
            foreach (Point point in Points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(Corner.Corners[Points.IndexOf(point)]);
            }
        }

        public void DrawTCorners(List<Point> Points, int Height)
        {
            foreach (Point point in Points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(Corner.TCorners[0]);
                Console.SetCursorPosition(point.X, Height);
                Console.Write(Corner.TCorners[1]);

            }
        }
    }
}

   
    

