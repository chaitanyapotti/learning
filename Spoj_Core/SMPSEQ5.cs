using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class SMPSEQ5
    {
        public SMPSEQ5()
        {
            Init();
        }
        public void Init()
        {
            int array1Count = int.Parse(Console.ReadLine());
            var array1 = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            int array2Count = int.Parse(Console.ReadLine());
            var array2 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            Execute(array1.ToArray(), array2.ToArray());

        }

        public void Execute(int[] array1, int[] array2)
        {
            int length = array1.Length < array2.Length ? array1.Length : array2.Length;
            for (int index = 0; index < length; index++)
            {
                if (array2[index] == array1[index]) Console.Write(index + 1 + " ");
            }
            //Console.ReadLine();
        }

    }
}
