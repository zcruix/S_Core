using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class MerchantGeneralInformationMailingAddressTests : MerchantGeneralInformationTestBase
    {
        [TestMethod]        
        public void MailingAddress_Cannot_Be_Null()
        {
            GivenAMerchantGeneralInformationThatHasMailingAddressAsNull();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe("Mailing address is required.");
        }

        [TestMethod]        
        public void MerchantGeneralInformation_Is_Valid_When_MailingAddress_Same_As_BusinessAddress_And_MailingAddress_Is_Null()
        {
            GivenAMerchantGeneralInformationThatHasMailingAddressAsNullAndBusinessAddressValidWithIsMailingAdddressSameAsMailingAddressSetToTrue();
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        [TestMethod]        
        public void MailingAddress_Cannot_Be_InValid()
        {
            GivenAMerchantGeneralInformationThatHasInValidMailingAddress();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"AddressLine1 cannot be empty or null.");
        }

        private void GivenAMerchantGeneralInformationThatHasInValidMailingAddress()
        {
            MerchantGeneralInformation.BusinessAddress = new Address { AddressLine1 = string.Empty };
        }
        private void GivenAMerchantGeneralInformationThatHasMailingAddressAsNullAndBusinessAddressValidWithIsMailingAdddressSameAsMailingAddressSetToTrue()
        {
            MerchantGeneralInformation.IsMailingAddressSameAsBusinessAddress = true;
            MerchantGeneralInformation.MailingAddress = null;
        }

        private void GivenAMerchantGeneralInformationThatHasMailingAddressAsNull()
        {
            MerchantGeneralInformation.MailingAddress = null;
        }
    }
}