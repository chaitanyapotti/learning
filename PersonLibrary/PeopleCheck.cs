using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class PersonComparer : Comparer<Person>
    {
        private static readonly PersonComparer _instance = new PersonComparer();

        public static PersonComparer Instance => _instance;
        private PersonComparer()
        {

        }

        public override int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Rating == y.Rating ? 0 : x.Rating > y.Rating ? 1 : -1;

            //throw new NotImplementedException();
        }
    }

    public class PersonEqualityComparer : EqualityComparer<Person>
    {
        public static readonly PersonEqualityComparer _instance = new PersonEqualityComparer();

        public static PersonEqualityComparer Instance => _instance;

        private PersonEqualityComparer()
        {

        }


        public override bool Equals(Person x, Person y) => x.Equals(y);

        public override int GetHashCode(Person obj) => obj.GetHashCode();
    }
}
