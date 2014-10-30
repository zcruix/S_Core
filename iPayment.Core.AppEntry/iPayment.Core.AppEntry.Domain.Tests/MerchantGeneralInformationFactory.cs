using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    public class MerchantGeneralInformationFactory
    {
        public static IMerchantGeneralInformation CreateMerchantGeneralInformation()
        {
            return new MerchantGeneralInformation
            {
                IsDoingBusinessAsNameSameAsLegalBusinessName = false,
                IsMailingAddressSameAsBusinessAddress = false,

                ContactFirstName = @"FirstName",
                ContactLastName = @"LastName",
                LegalBusinessName = @"LegalBusinessName",
                DoingBusinessAsName = @"DoingBusinessName",
                BusinessFax = new Phone {Number = @"8888888888", PhoneType = PhoneType.Fax},
                BusinessPhone = new Phone {Number = @"9999999999", PhoneType = PhoneType.Business},
                BusinessEmail = @"email@business.com",
                BusinessWebsiteUrl = @"http://www.Business.com",
                FederalTaxID = new FederalTaxId{Number = @"888888888", TaxIdType = TaxIdType.SSN},
                BusinessOperatingHours = @"from hours and minutes to hours and minutes",
                CustomerServicePhone = new Phone {Number = @"8008888888", PhoneType = PhoneType.CustomerService},
                NumberOfLocations = 1,
                ContinuousResidenceAtTheBusinessAddress = new ContinuousResidence {Years = 5, Months = 8},
                BusinessAddress = new Address
                {
                    AddressLine1 = @"Business Address Line 1",
                    AddressLine2 = @"Business Address Line 2",
                    City = @"Business City",
                    State = @"Business State",
                    County = @"Business County",
                    Zipcode = @"99999-9999"
                },
                MailingAddress = new Address
                {
                    AddressLine1 = @"Mailing Address Line 1",
                    AddressLine2 = @"Mailing Address Line 2",
                    City = @"Mailing City",
                    State = @"Mailing State",
                    County = @"Mailing County",
                    Zipcode = @"99999-9999"
                }
            };
        }
    }
}