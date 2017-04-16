using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicArrayOps
{
    class PrimeMinistersByYearDictionary : KeyedCollection<int,PrimeMinister>
    {
        protected override int GetKeyForItem(PrimeMinister item) => item.ElectedYear;
    }
}
