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

        //public Table(Point a, Point b) : base(
        //    new Line(a, new Point(b.X, a.Y)),
        //    new Line(new Point(b.X, a.Y), b),
        //    new Line(b, new Point(a.X, b.Y)),
        //    new Line(new Point(a.X, b.Y), a),
        //    new Line(new Point(b.X - 20, a.Y), new Point((b.X - 20), b.Y)),
        //    new Line(new Point(b.X - 40, a.Y), new Point((b.X - 40), b.Y))
        //    )
        //{
        //    //Check(a, b);
        //}

        //Lines initializer:

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
            
        }
        public virtual void Draw()
        {
            foreach (Line line in Lines)
            {
                line.Draw();
            }
        }


    }

    

}

   
    

