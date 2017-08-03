using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class SMPWOW
    {
        public SMPWOW()
        {
            Init();
        }

        public void Init()
        {
            string codeInput = Console.ReadLine();
            int x;
            int.TryParse(codeInput, out x);
            Execute(x);
        }

        public void Execute(int x)
        {
            Console.Write("W");
            for (int i = 0; i < x; i++)
            {
                Console.Write("o");
            }
            Console.Write("w");
        }
    }
}
