using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class CPTTRN6
    {
        public CPTTRN6()
        {
            Init();
        }
        public void Init()
        {
            int entriesCount = 0;
            int.TryParse(Console.ReadLine(), out entriesCount);
            int[] horz = new int[entriesCount];
            int[] vert = new int[entriesCount];
            int[] heights = new int[entriesCount];
            int[] widths = new int[entriesCount];
            for (int i = 0; i < entriesCount; i++)
            {
                string temp = Console.ReadLine();
                int.TryParse(temp.Split(' ')[0], out horz[i]);
                int.TryParse(temp.Split(' ')[1], out vert[i]);
                int.TryParse(temp.Split(' ')[2], out heights[i]);
                int.TryParse(temp.Split(' ')[3], out widths[i]);
                //i++;
            }
            Execute(horz, vert, heights, widths, entriesCount);
        }

        public void Execute(int[] rows, int[] cols, int[] heights, int[] widths, int entriesCount)
        {
            for (int k = 0; k < entriesCount; k++)
            {
                for (int j = 0; j < (heights[k] + 1) * rows[k] + heights[k]; j++)
                {
                    for (int i = 0; i < (widths[k] + 1) * cols[k] + widths[k]; i++)
                    {
                        if ((i + 1) % (widths[k] + 1) != 0 && (j + 1) % (heights[k] + 1) != 0) Console.Write(".");
                        else if ((i + 1) % (widths[k] + 1) == 0 && (j + 1) % (heights[k] + 1) == 0) Console.Write("+");
                        else if ((i + 1) % (widths[k] + 1) == 0 && (j + 1) % (heights[k] + 1) != 0) Console.Write("|");
                        else Console.Write('-');
                    }
                    Console.Write("\n");
                }
                Console.Write("\n \n");
            }

            //Console.ReadLine();
        }
    }
}
