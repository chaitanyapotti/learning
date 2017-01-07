using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCheck
{
    internal class Food
    {

        private readonly string name;

        public string Name => name;

        private readonly FoodGroup group;

        public FoodGroup Group => group;

        public Food(string name, FoodGroup group)
        {
            this.name = name;
            this.group = group;
            
        }

        public override string ToString() => name;

        
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            Food rhs = obj as Food;
            return this.name == rhs.name && this.group == rhs.group;
            //return base.Equals(obj);
        }

        public override int GetHashCode() => this.name.GetHashCode() ^ this.group.GetHashCode();

        public static bool operator ==(Food x, Food y) => object.Equals(x, y);
        public static bool operator !=(Food x, Food y) => !object.Equals(x, y);

    }
}
