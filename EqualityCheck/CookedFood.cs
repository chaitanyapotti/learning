using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCheck
{
    internal sealed class CookedFood : Food, IEquatable<CookedFood>
    {
        private string cookingMethod;

        public string CookingMethod => cookingMethod;

        /// <summary>
        /// Cooked Food Constructor
        /// </summary>
        /// <param name="cookingMethod"></param>
        /// <param name="name"></param>
        /// <param name="group"></param>
        public CookedFood(string cookingMethod, string name, FoodGroup group) : base(name, group)
        {
            this.cookingMethod = cookingMethod;
        }

        public override string ToString()
        {
            return $"{CookingMethod} {Name}";
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            CookedFood rhs = (CookedFood)obj;
            return this.cookingMethod == rhs.cookingMethod;
            //return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.cookingMethod.GetHashCode();
        }

        public bool Equals(CookedFood other)
        {
            if (!base.Equals(other))
                return false;
            return this.CookingMethod == other.CookingMethod;
            //throw new NotImplementedException();
        }
    }
}
