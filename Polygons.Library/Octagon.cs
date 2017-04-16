﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons.Library
{
    public class Octagon : IRegularPolygon
    {
        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }
        public double GetPerimeter() => NumberOfSides * SideLength;
        public double GetArea() => SideLength * SideLength * (2 + 2 * Math.Sqrt(2));

        public Octagon(int length)
        {
            NumberOfSides = 8;
            SideLength = length;
        }
    }
}
