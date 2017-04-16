using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCheck
{
    internal class FoodNameComparer : Comparer<Food>
    {
        public static FoodNameComparer Instance { get; } = new FoodNameComparer();

        private FoodNameComparer()
        {

        }
        public override int Compare(Food x, Food y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);
        }
    }
}
