﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander.Drawing
{
    public static class Corner
    {
        public static List<string> Corners = new List<string>() { "╚", "╝", "╗", "╔" };
        public static List<string> TCorners = new List<string>() { "╦", "╩" };
    }
}
