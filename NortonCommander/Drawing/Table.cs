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

       
        public List<Line> LinesInitializer(Point a, Point b)
        {
            List<Line> lines = new List<Line>()
            {
                new Line(a, new Point(b.X, a.Y)),
                new Line(new Point(b.X, a.Y), b),
                new Line(b, new Point(a.X, b.Y)),
                new Line(new Point(a.X, b.Y), a),
                new Line(new Point(b.X - 20, a.Y), new Point((b.X - 20), b.Y)),
                new Line(new Point(b.X - 40, a.Y), new Point((b.X - 40), b.Y))



            };
            return lines;
        }
        
        
        public Table(Point a, Point b)
        {
            Lines = LinesInitializer(a, b);
            
            Draw();
            DrawCorners(a, b);


        }
        public virtual void Draw()
        {
            foreach (Line line in Lines)
            {
                line.Draw();
            }
            
        }

        public void DrawCorners(Point A, Point B)
        {
            Console.SetCursorPosition(A.X, A.Y);
            Console.Write(Corner.GetDescription(CornersEnum.bottomLeft));
            Console.SetCursorPosition(B.X, A.Y);
            Console.Write(Corner.GetDescription(CornersEnum.bottomRight));
            Console.SetCursorPosition(A.X, B.Y);
            Console.Write(Corner.GetDescription(CornersEnum.topLeft));
            Console.SetCursorPosition(B.X, B.Y);
            Console.Write(Corner.GetDescription(CornersEnum.topRight));
            Console.SetCursorPosition(B.X - 20, A.Y);
            Console.Write(Corner.GetDescription(CornersEnum.bottomTtype));
            Console.SetCursorPosition(B.X - 40, A.Y);
            Console.Write(Corner.GetDescription(CornersEnum.bottomTtype));
            Console.SetCursorPosition(B.X - 20, B.Y);
            Console.Write(Corner.GetDescription(CornersEnum.topTtype));
            Console.SetCursorPosition(B.X - 40, B.Y);
            Console.Write(Corner.GetDescription(CornersEnum.topTtype));

        }


    }

    

}

   
    

