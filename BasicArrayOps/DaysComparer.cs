using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicArrayOps
{
    internal class DaysComparer : Comparer<string>
    {
        private static readonly DaysComparer _instance;

        public static DaysComparer Instance => _instance;

        private DaysComparer()
        { }

        public override int Compare(string x, string y)
        {
            return (x?.Length >= y?.Length) ? 1 : -1;
        }
    }
}
