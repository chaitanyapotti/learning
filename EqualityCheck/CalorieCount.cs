using System;

namespace EqualityCheck
{
    internal struct CalorieCount : IComparable<CalorieCount>, IEquatable<CalorieCount>, IComparable
    {
        private float value;
        private const double Tolerance = 1e-6;

        public CalorieCount(float value)
        {
            this.value = value;
        }

        public float Value => value;

        public static bool operator !=(CalorieCount x, CalorieCount y) => Math.Abs(x.Value - y.value) > Tolerance;

        public static bool operator <(CalorieCount x, CalorieCount y) => x.Value < y.value;

        public static bool operator <=(CalorieCount x, CalorieCount y) => x.Value <= y.value;

        public static bool operator ==(CalorieCount x, CalorieCount y) => Math.Abs(x.Value - y.value) < Tolerance;

        public static bool operator >(CalorieCount x, CalorieCount y) => x.Value > y.value;

        public static bool operator >=(CalorieCount x, CalorieCount y) => x.Value >= y.value;

        public int CompareTo(CalorieCount other) => Value.CompareTo(other.Value);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => value + " cal";

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is CalorieCount)) return false;
            return Value == ((CalorieCount)obj).Value;
            //return base.Equals(obj);
        }

        public bool Equals(CalorieCount other) => Value == other.Value;

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is CalorieCount)) throw new ArgumentException("Expected CalorieCount Instance", nameof(obj));
            return CompareTo((CalorieCount)obj);
            //throw new NotImplementedException();
        }
    }
}
