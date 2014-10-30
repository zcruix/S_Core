using System;
using iPayment.Core.AppEntry.Data.Enums;

namespace iPayment.Core.AppEntry.Data.Templates
{
    public class Phone : IEquatable<Phone>
    {
        public string Number { get; set; }

        public PhoneType PhoneType { get; set; }

        public bool Equals(Phone other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Number, other.Number) && PhoneType == other.PhoneType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Phone)) return false;
            return Equals((Phone) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Number != null ? Number.GetHashCode() : 0)*397) ^ (int) PhoneType;
            }
        }

        public static bool operator ==(Phone left, Phone right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Phone left, Phone right)
        {
            return !Equals(left, right);
        }
    }
}