using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Address = iPayment.Core.AppEntry.Data.Templates.Address;
using ContinuousResidence = iPayment.Core.AppEntry.Data.Templates.ContinuousResidence;
using FederalTaxId = iPayment.Core.AppEntry.Data.Templates.FederalTaxId;
using Phone = iPayment.Core.AppEntry.Data.Templates.Phone;

namespace iPayment.Core.AppEntry.Data.Model
{
    [Table("GeneralInformations")]
    public class GeneralInformationDataModel : ApplicationFormSectionBase, IEquatable<GeneralInformationDataModel>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeneralInformationKey { get; set; }

        public string DoingBusinessAsName { get; set; }

        public string LegalBusinessName { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string BusinessEmail { get; set; }

        public string BusinessWebsiteUrl { get; set; }

        public string BusinessOperatingHours { get; set; }

        public int NumberOfLocations { get; set; }

        public Phone BusinessPhone { get; set; }

        public Phone BusinessFax { get; set; }

        public Phone CustomerServicePhone { get; set; }

        public Address BusinessAddress { get; set; }

        public Address MailingAddress { get; set; }

        public ContinuousResidence ContinuousResidenceAtTheBusinessAddress { get; set; }

        public FederalTaxId FederalTaxID { get; set; }

        public bool IsMailingAddressSameAsBusinessAddress { get; set; }

        public bool IsDoingBusinessAsNameSameAsLegalBusinessName { get; set; }

        public bool Equals(GeneralInformationDataModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(DoingBusinessAsName, other.DoingBusinessAsName) && string.Equals(LegalBusinessName, other.LegalBusinessName) && string.Equals(ContactFirstName, other.ContactFirstName) && string.Equals(ContactLastName, other.ContactLastName) && string.Equals(BusinessEmail, other.BusinessEmail) && string.Equals(BusinessWebsiteUrl, other.BusinessWebsiteUrl) && string.Equals(BusinessOperatingHours, other.BusinessOperatingHours) && NumberOfLocations == other.NumberOfLocations && Equals(BusinessPhone, other.BusinessPhone) && Equals(BusinessFax, other.BusinessFax) && Equals(CustomerServicePhone, other.CustomerServicePhone) && Equals(BusinessAddress, other.BusinessAddress) && Equals(MailingAddress, other.MailingAddress) && Equals(ContinuousResidenceAtTheBusinessAddress, other.ContinuousResidenceAtTheBusinessAddress) && Equals(FederalTaxID, other.FederalTaxID) && IsMailingAddressSameAsBusinessAddress.Equals(other.IsMailingAddressSameAsBusinessAddress) && IsDoingBusinessAsNameSameAsLegalBusinessName.Equals(other.IsDoingBusinessAsNameSameAsLegalBusinessName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as GeneralInformationDataModel;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (DoingBusinessAsName != null ? DoingBusinessAsName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LegalBusinessName != null ? LegalBusinessName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ContactFirstName != null ? ContactFirstName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ContactLastName != null ? ContactLastName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BusinessEmail != null ? BusinessEmail.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BusinessWebsiteUrl != null ? BusinessWebsiteUrl.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BusinessOperatingHours != null ? BusinessOperatingHours.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ NumberOfLocations;
                hashCode = (hashCode*397) ^ (BusinessPhone != null ? BusinessPhone.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BusinessFax != null ? BusinessFax.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CustomerServicePhone != null ? CustomerServicePhone.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BusinessAddress != null ? BusinessAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (MailingAddress != null ? MailingAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ContinuousResidenceAtTheBusinessAddress != null ? ContinuousResidenceAtTheBusinessAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FederalTaxID != null ? FederalTaxID.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IsMailingAddressSameAsBusinessAddress.GetHashCode();
                hashCode = (hashCode*397) ^ IsDoingBusinessAsNameSameAsLegalBusinessName.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(GeneralInformationDataModel left, GeneralInformationDataModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GeneralInformationDataModel left, GeneralInformationDataModel right)
        {
            return !Equals(left, right);
        }
    }
}