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
        /// <summary>
        /// Левый нижний угол
        /// </summary>
        public Point A { get; set; }
        /// <summary>
        ///  правый верхний угол
        /// </summary>
        public Point B { get; set; }
        /// <summary>
        /// количество колонок
        /// </summary>
        public int ColCount { get; set; } 
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor BackColor { get; set; }
        public string Name { get; set; }

        public List<Line> LinesInitializer()
        {
            List<Line> lines = new List<Line>()
            {
                new Line(A, new Point(B.X, A.Y)),
                new Line(new Point(B.X, A.Y), B),
                new Line(B, new Point(A.X, B.Y)),
                new Line(new Point(A.X, B.Y), A)
            };
            if (ColCount > 1)
            {
                int ColumnWidth = (B.X - A.X) / ColCount;
                for (int i = 1; i < ColCount; i++)
                {
                    lines.Add(new Line(new Point(A.X + i * ColumnWidth, A.Y), new Point((A.X + i * ColumnWidth), B.Y)));
                }
            }
            return lines;
        }

        public IEnumerable<Point> GetCornersPoint()
        {
            for (int i = 0; i < 4; i++)
                yield return new Point(Lines[i].A.X, Lines[i].A.Y, Corner.Corners.ToArray()[i]);
        }

        public IEnumerable<Point> GetTCornersPoint()
        {
            if (Lines.Count > 4)
                for (int i = 4; i < Lines.Count; i++)
                    yield return new Point(Lines[i][0].X, Lines[i][0].Y);
        }

        public Table(string name, Point a, Point b, int colcount, ConsoleColor textcolor, ConsoleColor backcolor)
        {
            Name = name;
            A = a;
            B = b;
            ColCount = colcount;
            TextColor = textcolor;
            BackColor = backcolor;
            Lines = LinesInitializer();
            Draw();


            Console.ResetColor();
        }
        public virtual void Draw()
        {
            Console.BackgroundColor = BackColor;
            Console.ForegroundColor = TextColor;

            foreach (IDraw line in Lines.Cast<IDraw>()
                                        .Union(GetCornersPoint())
                                        .Union(GetTCornersPoint()))
            {
                line.Draw();
            }
            AddTableName();

        }

        public void AddTableName()
        {
            Console.SetCursorPosition(A.X + (B.X - A.X) / 2 - Name.Length / 2, B.Y);
            Console.Write(Name);
        }

        public void DrawCorners(List<Point> Points)
        {
            foreach (Point point in Points)
            {
                point.Draw();
            }
        }

        public void DrawTCorners(List<Point> Points)
        {
            foreach (Point point in Points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(Corner.TCorners[0]);
                Console.SetCursorPosition(point.X, A.Y);
                Console.Write(Corner.TCorners[1]);

            }
        }
    }
}




