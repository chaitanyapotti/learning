using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class CPTTRN4
    {
        public CPTTRN4()
        {
            Init();
        }
        public void Init()
        {
            int entriesCount = 0;
            int.TryParse(Console.ReadLine(), out entriesCount);
            int[] rows = new int[entriesCount];
            int[] cols = new int[entriesCount];
            int[] widths = new int[entriesCount];
            int[] heights = new int[entriesCount];
            for (int i = 0; i < entriesCount; i++)
            {
                string temp = Console.ReadLine();
                int.TryParse(temp.Split(' ')[0], out rows[i]);
                int.TryParse(temp.Split(' ')[1], out cols[i]);
                int.TryParse(temp.Split(' ')[3], out widths[i]);
                int.TryParse(temp.Split(' ')[2], out heights[i]);
                //i++;
            }
            Execute(rows, cols, widths, heights, entriesCount);
        }

        public void Execute(int[] rows, int[] cols, int[] widths, int[] heights, int entriesCount)
        {
            for (int k = 0; k < entriesCount; k++)
            {
                for (int j = 0; j < (heights[k] + 1) * rows[k] + 1; j++)
                {
                    for (int i = 0; i < (widths[k] + 1) * cols[k] + 1; i++)
                    {
                        if (i % (widths[k] + 1) == 0 || j % (heights[k] + 1) == 0) Console.Write("*");
                        else Console.Write(".");
                    }
                    Console.Write("\n");
                }
                Console.Write("\n \n");
            }

            //Console.ReadLine();
        }
    }
}
