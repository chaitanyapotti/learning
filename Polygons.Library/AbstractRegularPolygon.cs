using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons.Library
{
    public abstract class AbstractRegularPolygon
    {
        public int NumberOfSides { get; set; }

        public int SideLength { get; set; }

        protected AbstractRegularPolygon(int sides, int length)
        {
            NumberOfSides = sides;
            SideLength = length;
        }

        public double GetPerimeter() => NumberOfSides * SideLength;

        public abstract double GetArea();
    }
}
