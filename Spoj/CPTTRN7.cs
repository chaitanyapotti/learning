using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj
{
    class CPTTRN7
    {
        public CPTTRN7()
        {
            Init();
        }
        public void Init()
        {
            int entriesCount = 0;
            int.TryParse(Console.ReadLine(), out entriesCount);
            int[] horz = new int[entriesCount];
            int[] vert = new int[entriesCount];
            int[] sizes = new int[entriesCount];
            int[] widths = new int[entriesCount];
            for (int i = 0; i < entriesCount; i++)
            {
                string temp = Console.ReadLine();
                int.TryParse(temp.Split(' ')[0], out horz[i]);
                int.TryParse(temp.Split(' ')[1], out vert[i]);
                int.TryParse(temp.Split(' ')[2], out sizes[i]);
                //i++;
            }
            Execute(horz, vert, sizes, entriesCount);
        }

        public void Execute(int[] rows, int[] cols, int[] sizes, int entriesCount)
        {
            for (int k = 0; k < entriesCount; k++)
            {
                for (int j = 0; j < 2 * rows[k] * sizes[k]; j++)
                {
                    for (int i = 0; i < 2 * cols[k] * sizes[k]; i++)
                    {
                        int s = sizes[k];
                        int h = j % s;
                        int w = i % s;
                        int hi = j / s;
                        int wi = i / s;
                        if ((hi % 2 == 0 && wi % 2 == 0) || (hi % 2 != 0 && wi % 2 != 0))
                        {
                            Console.Write(h + w == s - 1 ? "/" : ".");
                        }
                        else
                        {
                            Console.Write(h == w ? "\\" : ".");
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
