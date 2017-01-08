using System;
using System.Collections;
using System.Collections.Generic;

namespace EqualityCheck
{
    internal class Food : IEnumerable
    {
        private readonly List<string> types = new List<string> { "Banana", "Pear", "Apple" };

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
            return name == rhs.name && group == rhs.group;
            //return base.Equals(obj);
        }

        public override int GetHashCode() => name.GetHashCode() ^ group.GetHashCode();

        public static bool operator ==(Food x, Food y) => Equals(x, y);
        public static bool operator !=(Food x, Food y) => !Equals(x, y);
        public IEnumerator GetEnumerator()
        {
            return types.GetEnumerator();
            //throw new System.NotImplementedException();
        }
    }
}
