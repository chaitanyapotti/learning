using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class BSCXOR
    {
        public BSCXOR()
        {
            Init();
        }
        public void Init()
        {
            var array1 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            Execute(array1.ToArray());
        }

        public void Execute(int[] array1)
        {
            int var = array1[0];
            for (int index = 1; index < array1.Length; index++)
            {
                var ^= array1[index];
            }
            Console.WriteLine(var);
            //Console.ReadLine();
        }
    }
}
