using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class SMPDIV
    {
        public SMPDIV()
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
                int maxNum = int.Parse(codeArray[0]);
                int x = int.Parse(codeArray[1]);
                int y = int.Parse(codeArray[2]);
                Execute(maxNum, x, y);
            }
        }

        public void Execute(int maxNum, int x, int y)
        {
            for (int i = x; i < maxNum; i += x)
            {
                if (i % y != 0) Console.Write(i + " ");
            }
            Console.Write("\n");
        }
    }
}
