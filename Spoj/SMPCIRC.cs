using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class SMPCIRC
    {
        public SMPCIRC()
        {
            Init();
        }

        public void Init()
        {
            int casesCount = 0;
            int.TryParse(Console.ReadLine(), out casesCount);
            for (int i = 0; i < casesCount; i++)
            {
                string[] codeArray = Console.ReadLine().Split(' ');
                double x1 = double.Parse(codeArray[0]);
                double y1 = double.Parse(codeArray[1]);
                double r1 = double.Parse(codeArray[2]);
                double x2 = double.Parse(codeArray[3]);
                double y2 = double.Parse(codeArray[4]);
                double r2 = double.Parse(codeArray[5]);
                Execute(x1, y1, r1, x2, y2, r2);
            }
        }

        public void Execute(double x1, double y1, double r1, double x2, double y2, double r2)
        {
            double c1c2 = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            if (c1c2.Equals(Math.Abs(r1 - r2))) Console.WriteLine("E");
            else if (c1c2 < Math.Abs(r1 - r2)) Console.WriteLine("I");
            else Console.WriteLine("O");

            Console.Write("\n");
        }
    }
}
