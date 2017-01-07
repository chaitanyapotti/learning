using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCheck
{
    public enum FoodGroup { Meat, Fruit, Vegetables, Sweets}
    internal struct FoodItem : IEquatable<FoodItem>
    {
        private readonly string name;

        public string Name => name;

        private readonly FoodGroup group;

        public FoodGroup Group => group;

        public FoodItem(string name, FoodGroup group) : this()
        {
            this.name = name;
            this.group = group;
        }

        public override string ToString()
        {
            return name;
        }

        public bool Equals(FoodItem other) => this.Name == other.Name && this.Group == other.Group;

        public override bool Equals(object obj) => (obj is FoodItem) ? Equals((FoodItem)obj) : false;

        public static bool operator ==(FoodItem lhs, FoodItem rhs) => lhs.Equals(rhs);

        public static bool operator !=(FoodItem lhs, FoodItem rhs) => !lhs.Equals(rhs);

        public override int GetHashCode() => name.GetHashCode() ^ group.GetHashCode();
    }
}
