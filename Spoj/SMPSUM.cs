using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class SMPSUM
    {
        public SMPSUM()
        {
            Init();
        }

        public void Init()
        {

            string[] codeArray = Console.ReadLine().Split(' ');
            int x1 = int.Parse(codeArray[0]);
            int y1 = int.Parse(codeArray[1]);
            Execute(x1, y1);

        }

        public void Execute(int x1, int y1)
        {
            Console.WriteLine(y1 * (y1 + 1) * (2 * y1 + 1) / 6 - x1 * (x1 + 1) * (2 * x1 + 1) / 6 + x1 * x1);
        }
    }
}
