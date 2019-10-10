using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class TEST
    {
        public TEST()
        {
            Init();
        }
        public void Init()
        {

            Execute();
        }

        public void Execute()
        {
            while (true)
            {
                string number = Console.ReadLine();
                if (number == "42") break;
                Console.WriteLine(number);
            }
            //Console.ReadLine();
        }
    }
}
