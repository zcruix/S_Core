using System;
using iPayment.Core.AppEntry.DTO.Enums;

namespace iPayment.Core.AppEntry.DTO.Templates
{
    public class Address : IEquatable<Address>
    {       
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string County { get; set; }
        public AddressType AddressType { get; set; }


        public bool Equals(Address other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(AddressLine1, other.AddressLine1) && string.Equals(AddressLine2, other.AddressLine2) && string.Equals(City, other.City) && string.Equals(State, other.State) && string.Equals(Zipcode, other.Zipcode) && string.Equals(County, other.County) && AddressType == other.AddressType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as Address;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AddressLine1 != null ? AddressLine1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AddressLine2 != null ? AddressLine2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Zipcode != null ? Zipcode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (County != null ? County.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)AddressType;
                return hashCode;
            }
        }

        public static bool operator ==(Address left, Address right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Address left, Address right)
        {
            return !Equals(left, right);
        }
    }    
}