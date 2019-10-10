using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class SumOfDigits
    {
        public SumOfDigits()
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
                //i++;
            }
            Execute(entries);
        }

        public void Execute(string[] entries)
        {
            foreach (string entry in entries)
            {
                int sum = 0;
                string temp = entry;
                foreach (char c in temp)
                {
                    int value = 0;
                    int.TryParse(c.ToString(), out value);
                    sum += value;
                }
                Console.WriteLine(sum);
            }
            //Console.ReadLine();
        }
    }
}
