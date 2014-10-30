using System;
using iPayment.Core.AppEntry.Data.Enums;

namespace iPayment.Core.AppEntry.Data.Templates
{
    public class FederalTaxId : IEquatable<FederalTaxId>
    {
        public string Number { get; set; }

        public TaxIdType TaxIdType { get; set; }

        public bool Equals(FederalTaxId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Number, other.Number) && TaxIdType == other.TaxIdType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FederalTaxId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Number != null ? Number.GetHashCode() : 0)*397) ^ (int) TaxIdType;
            }
        }

        public static bool operator ==(FederalTaxId left, FederalTaxId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FederalTaxId left, FederalTaxId right)
        {
            return !Equals(left, right);
        }
    }
}