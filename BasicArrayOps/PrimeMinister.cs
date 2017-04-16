using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicArrayOps
{
    internal class PrimeMinister
    {
        public PrimeMinister(int electedYear, string name)
        {
            ElectedYear = electedYear;
            Name = name;
        }

        public string Name { get; private set; }

        public int ElectedYear { get; private set; }

        public override string ToString()
        {
            return $"{Name}, elected: {ElectedYear}";
            //return base.ToString();
        }
    }
}
