using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class SMPSEQ7
    {
        public SMPSEQ7()
        {
            Init();
        }
        public void Init()
        {
            int yVar = int.Parse(Console.ReadLine());
            var array1 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            Execute(array1.ToArray(), yVar);
        }

        public void Execute(int[] array1, int length)
        {
            bool flag = true;
            int falseCount = 0;
            for (int index = 0; index < length - 1; index++)
            {
                int variable = flag ? index : index + 1;
                int var2 = flag ? index + 1 : index;
                if (array1[variable] > array1[var2]) { continue; }
                flag = false;
                falseCount++;
            }
            Console.WriteLine(!flag && falseCount == 1 ? "Yes" : "No");
            //Console.ReadLine();
        }
    }
}
