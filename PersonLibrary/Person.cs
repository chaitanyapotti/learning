using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public sealed class Person : IEquatable<Person>, IComparable<Person>, IComparable
    {
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public int Rating { get; set; }
        public bool Equals(Person other)
        {
            var reqObj = other;
            if (reqObj != null) return Firstname.Equals(reqObj.Firstname) && LastName.Equals(reqObj.LastName) && StartDate.Equals(reqObj.StartDate) && Rating.Equals(reqObj.Rating);
            return false;
            //throw new NotImplementedException();
        }

        public int CompareTo(Person other) => this.Rating.CompareTo(other?.Rating);

        public override bool Equals(object obj)
        {
            var reqObj = obj as Person;
            if(reqObj != null) return Firstname.Equals(reqObj.Firstname) && LastName.Equals(reqObj.LastName) && StartDate.Equals(reqObj.StartDate) && Rating.Equals(reqObj.Rating);
            return false;
            //return base.Equals(obj);
        }

        public override int GetHashCode() => Firstname.GetHashCode() ^ LastName.GetHashCode() ^ StartDate.GetHashCode() ^ Rating.GetHashCode();
        public int CompareTo(object obj)
        {
            var reqObj = obj as Person;
            if (reqObj != null) return reqObj.Rating.CompareTo(this.Rating);
            return 1;
            //throw new NotImplementedException();
        }

        public static bool operator ==(Person x, Person y) => Equals(x, y);

        public static bool operator !=(Person x, Person y) => !Equals(x, y);

        public static bool operator >(Person x, Person y) => x.Rating > y.Rating;
        public static bool operator <(Person x, Person y) => x.Rating < y.Rating;
        public static bool operator <=(Person x, Person y) => x.Rating <= y.Rating;
        public static bool operator >=(Person x, Person y) => x.Rating >= y.Rating;



    }
}
