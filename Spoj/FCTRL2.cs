using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class FCTRL2
    {
        public FCTRL2()
        {
            Init();
        }
        public void Init()
        {
            int entriesCount, number = 0;
            int.TryParse(Console.ReadLine(), out entriesCount);
            for (int i = 0; i < entriesCount; i++)
            {
                string temp = Console.ReadLine();
                int.TryParse(temp, out number);
                BigInteger prod = Execute(number);
                Console.Write(i != entriesCount - 1 ? prod.ToString() + "\n" : prod.ToString());
            }
        }

        public BigInteger Execute(int number)
        {
            BigInteger prod = 1;
            for (int i = 2; i <= number; i++)
            {
                prod *= i;
            }
            return prod;
        }
    }
}
