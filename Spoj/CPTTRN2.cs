using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class CPTTRN2
    {
        public CPTTRN2()
        {
            Init();
        }
        public void Init()
        {
            int entriesCount = 0;
            int.TryParse(Console.ReadLine(), out entriesCount);
            int[] rows = new int[entriesCount];
            int[] cols = new int[entriesCount];
            for (int i = 0; i < entriesCount; i++)
            {
                string temp = Console.ReadLine();
                int.TryParse(temp.Split(' ')[0], out rows[i]);
                int.TryParse(temp.Split(' ')[1], out cols[i]);
                //i++;
            }
            Execute(rows, cols, entriesCount);
        }

        public void Execute(int[] rows, int[] cols, int entriesCount)
        {
            for (int k = 0; k < entriesCount; k++)
            {
                for (int j = 0; j < rows[k]; j++)
                {
                    for (int i = 0; i < cols[k]; i++)
                    {
                        if (j == 0 || j == rows[k] - 1 || i == 0 || i == cols[k] - 1) Console.Write('*');
                        else Console.Write('.');
                    }
                    Console.Write("\n");
                }
                Console.Write("\n \n");
            }

            //Console.ReadLine();
        }
    }
}
