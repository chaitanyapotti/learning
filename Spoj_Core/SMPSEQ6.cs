using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class SMPSEQ6
    {
        public SMPSEQ6()
        {
            Init();
        }
        public void Init()
        {
            int yVar = int.Parse(Console.ReadLine().Split(' ')[1]);
            var array1 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var array2 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            Execute(array1.ToArray(), array2.ToArray(), yVar);

        }

        public void Execute(int[] array1, int[] array2, int yVar)
        {
            int length = array1.Length;
            for (int index = 0; index < length; index++)
            {
                if (Match(array1, array2, index, yVar)) Console.Write(index + 1 + " ");
            }
            Console.ReadLine();
        }

        private static bool Match(int[] array1, int[] array2, int index, int yVar)
        {
            for (int i = -yVar; i <= yVar; i++)
            {
                if (index + i >= 0 && index + i < array2.Length && array1[index] == array2[index + i]) return true;
            }
            return false;
        }
    }
}
