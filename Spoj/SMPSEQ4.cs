using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class SMPSEQ4
    {
        public SMPSEQ4()
        {
            Init();
        }
        public void Init()
        {
            int array1Count = int.Parse(Console.ReadLine());
            var array1 = Console.ReadLine().Split(' ').Select(int.Parse);
            int array2Count = int.Parse(Console.ReadLine());
            var array2 = Console.ReadLine().Split(' ').Select(int.Parse);
            Execute(array1.ToArray(), array2.ToArray());

        }

        public void Execute(int[] array1, int[] array2)
        {
            foreach (var item in array1)
            {
                if (Find(array2, item)) Console.Write(item + " ");
            }
            //Console.ReadLine();
        }

        private bool Find(int[] array, int item)
        {
            int lo = 0;
            int hi = array.Length - 1;
            if (array[lo] > item) return false;
            if (array[hi] < item) return false;

            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                if (array[mid] > item) hi = mid - 1;
                else if (array[mid] < item) lo = mid + 1;
                else return true;
            }
            return false;
        }


    }
}
