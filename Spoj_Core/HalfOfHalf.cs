using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class HalfOfHalf
    {
        public HalfOfHalf()
        {
            Init();
        }

        public void Init()
        {
            int entriesCount = 0;
            int.TryParse(Console.ReadLine(), out entriesCount);
            string[] entries = new string[entriesCount];
            for (int i = 0; i < entriesCount; i++)
            {
                string temp = Console.ReadLine();
                entries[i] = temp;
            }
            Execute(entries);
        }

        public void Execute(string[] entries)
        {
            foreach (string entry in entries)
            {
                StringBuilder sb = new StringBuilder();
                for (int index = 0; index < entry.Length / 2; index += 2)
                {
                    sb.Append(entry[index]);
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
