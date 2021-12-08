using System;
using System.Collections.Generic;

namespace NortonCommander
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> menu = new List<object> { "word1", "word2", "word3" };
            Panel.Panel.PointsInitializer();
            Panel.Panel.PrintFirstRow(menu);


        }
    }
}
