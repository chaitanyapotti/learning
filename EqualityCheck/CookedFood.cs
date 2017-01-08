using System;

namespace EqualityCheck
{
    internal sealed class CookedFood : Food, IEquatable<CookedFood>
    {
        private string cookingMethod;

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

        public string CookingMethod => cookingMethod;

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            CookedFood rhs = (CookedFood)obj;
            return cookingMethod == rhs?.cookingMethod;
            //return base.Equals(obj);
        }

        public bool Equals(CookedFood other)
        {
            if (!base.Equals(other))
                return false;
            return CookingMethod == other.CookingMethod;
            //throw new NotImplementedException();
        }
        public override int GetHashCode() => base.GetHashCode() ^ CookingMethod.GetHashCode();

        public override string ToString() => $"{CookingMethod} {Name}";
    }
}
