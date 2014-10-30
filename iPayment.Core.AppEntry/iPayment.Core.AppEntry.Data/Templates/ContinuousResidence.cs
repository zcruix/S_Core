using System;

namespace iPayment.Core.AppEntry.Data.Templates
{
    public class ContinuousResidence : IEquatable<ContinuousResidence>
    {
        public int Years { get; set; }

        public int Months { get; set; }

        public bool Equals(ContinuousResidence other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Years == other.Years && Months == other.Months;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ContinuousResidence) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Years*397) ^ Months;
            }
        }

        public static bool operator ==(ContinuousResidence left, ContinuousResidence right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContinuousResidence left, ContinuousResidence right)
        {
            return !Equals(left, right);
        }
    }
}