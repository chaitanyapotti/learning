using System;

namespace Spoj
{
    public class HS12MBR
    {
        public HS12MBR()
        {
            Init();
        }
        public void Init()
        {
            int casesCount = 0;
            int.TryParse(Console.ReadLine(), out casesCount);
            for (int i = 0; i < casesCount; i++)
            {
                int objectCount = 0;
                int.TryParse(Console.ReadLine(), out objectCount);
                Shape[] shapeArray = new Shape[objectCount];
                for (int j = 0; j < objectCount; j++)
                {
                    string[] objectLine = Console.ReadLine().Split(' ');
                    shapeArray[j] = new Shape();
                    if (objectLine.Length > 0) shapeArray[j].ShapeType = objectLine[0] == "p" ? ShapeType.Point : objectLine[0] == "c" ? ShapeType.Circle : ShapeType.Line;
                    switch (shapeArray[j].ShapeType)
                    {
                        case ShapeType.Circle:
                            shapeArray[j].Point1 = new Point(double.Parse(objectLine[1]), double.Parse(objectLine[2]));
                            shapeArray[j].Radius = double.Parse(objectLine[3]);
                            break;
                        case ShapeType.Point:
                            shapeArray[j].Point1 = new Point(double.Parse(objectLine[1]), double.Parse(objectLine[2]));
                            break;
                        case ShapeType.Line:
                            shapeArray[j].Point1 = new Point(double.Parse(objectLine[1]), double.Parse(objectLine[2]));
                            shapeArray[j].Point2 = new Point(double.Parse(objectLine[3]), double.Parse(objectLine[4]));
                            break;
                    }
                }
                Execute(shapeArray);
            }
        }

        public void Execute(Shape[] shapeArray)
        {
            var mbr = new Shape
            {
                ShapeType = ShapeType.Rectangle,
                Point1 = new Point(0, 0),
                Point2 = new Point(0, 0)
            };
            foreach (var shape in shapeArray)
            {
                switch (shape.ShapeType)
                {
                    case ShapeType.Point:
                        if (ComparePoints(shape.Point1, mbr.Point1) == -1) mbr.Point1 = shape.Point1;
                        if (ComparePoints(shape.Point1, mbr.Point2) == 1) mbr.Point2 = shape.Point1;
                        break;
                    case ShapeType.Line:
                        if (ComparePoints(shape.Point1, mbr.Point1) == -1) mbr.Point1 = shape.Point1;
                        if (ComparePoints(shape.Point2, mbr.Point2) == 1) mbr.Point2 = shape.Point2;
                        break;
                    case ShapeType.Circle:
                        if (ComparePoints(new Point(shape.Point1.X - shape.Radius, shape.Point1.Y - shape.Radius), mbr.Point1) == -1) mbr.Point1 = new Point(shape.Point1.X - shape.Radius, shape.Point1.Y - shape.Radius);
                        if (ComparePoints(new Point(shape.Point1.X + shape.Radius, shape.Point1.Y + shape.Radius), mbr.Point1) == 1) mbr.Point2 = new Point(shape.Point1.X + shape.Radius, shape.Point1.Y + shape.Radius);
                        break;
                }

            }
            Console.WriteLine(mbr.Point1.X + " " + mbr.Point1.Y + " " + mbr.Point2.X + " " + mbr.Point2.Y);
        }

        private int ComparePoints(Point point1, Point point2)
        {
            if (point1.X >= point2.X && point1.Y >= point2.Y) return 1;
            if (point1.X < point2.X && point1.Y < point2.Y) return -1;
            return 0;
        }
    }

    public struct Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x; Y = y;
        }
    }

    public class Shape
    {
        public ShapeType ShapeType { get; set; }

        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public double Radius { get; set; }
    }

    public enum ShapeType
    {
        Point, Circle, Line, Rectangle
    }
}
