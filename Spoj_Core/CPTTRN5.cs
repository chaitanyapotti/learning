using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class CPTTRN5
    {
        public CPTTRN5()
        {
            Init();
        }
        public void Init()
        {
            int entriesCount = 0;
            int.TryParse(Console.ReadLine(), out entriesCount);
            int[] rows = new int[entriesCount];
            int[] cols = new int[entriesCount];
            int[] sizes = new int[entriesCount];
            for (int i = 0; i < entriesCount; i++)
            {
                string temp = Console.ReadLine();
                int.TryParse(temp.Split(' ')[0], out rows[i]);
                int.TryParse(temp.Split(' ')[1], out cols[i]);
                int.TryParse(temp.Split(' ')[2], out sizes[i]);
                //i++;
            }
            Execute(rows, cols, sizes, entriesCount);
        }

        public void Execute(int[] rows, int[] cols, int[] sizes, int entriesCount)
        {
            for (int k = 0; k < entriesCount; k++)
            {
                for (int j = 0; j < (sizes[k] + 1) * rows[k] + 1; j++)
                {
                    for (int i = 0; i < (sizes[k] + 1) * cols[k] + 1; i++)
                    {
                        if (i % (sizes[k] + 1) == 0 || j % (sizes[k] + 1) == 0) Console.Write("*");
                        else
                        {
                            if ((j / (sizes[k] + 1) + i / (sizes[k] + 1)) % 2 == 0) Console.Write(i % (sizes[k] + 1) == j % (sizes[k] + 1) ? '\\' : '.');
                            else Console.Write(i % (sizes[k] + 1) == (sizes[k] + 1) - j % (sizes[k] + 1) ? '/' : '.');
                        }
                    }
                    Console.Write("\n");
                }
                Console.Write("\n \n");
            }

            //Console.ReadLine();
        }
    }
}
