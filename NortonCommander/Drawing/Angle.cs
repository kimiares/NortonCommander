using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Drawing
{
    static class Angle
    {
        public static class MyEnumExtensions
        {
            public static string ToDescriptionString(AngleEnum val)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                   .GetType()
                   .GetField(val.ToString())
                   .GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            }
        }
    }
}
