using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicArrayOps
{
    class StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) => x.ToUpperInvariant() == y.ToUpperInvariant();

        public int GetHashCode(string obj)
        {
            return obj.ToUpperInvariant().GetHashCode();
        }
    }
}
