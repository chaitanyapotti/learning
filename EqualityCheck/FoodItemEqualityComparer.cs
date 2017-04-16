using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCheck
{
    internal class FoodItemEqualityComparer : EqualityComparer<FoodItem>
    {

        private static readonly FoodItemEqualityComparer instance = new FoodItemEqualityComparer();

        public static FoodItemEqualityComparer Instance => instance;

        private FoodItemEqualityComparer()
        {

        }

        public override bool Equals(FoodItem x, FoodItem y) => x.Name.ToUpperInvariant() == y.Name.ToUpperInvariant() && x.Group.ToString() == y.Group.ToString();
        public override int GetHashCode(FoodItem obj) => obj.Name.ToUpperInvariant().GetHashCode() ^ obj.Group.GetHashCode();
    }
}
