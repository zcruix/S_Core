using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class GeneralInformationBusinessAddressTests : GeneralInformationTestBase
    {
        [TestMethod]        
        public void BusinessAddress_Cannot_Be_Null()
        {
            GivenAMerchantGeneralInformationThatHasBusinessAddressAsNull();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"Business address is required.");
        }

        [TestMethod]        
        public void BusinessAddress_Cannot_Be_InValid()
        {
            GivenAMerchantGeneralInformationThatHasInValidBusinessAddress();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"AddressLine1 cannot be empty or null.");
        }

        [TestMethod]        
        public void MerchantGeneralInformation_Is_Valid_When_BusinessAddress_Same_As_MailingAddress_And_BusinessAddress_Is_Null()
        {
            GivenAMerchantGeneralInformationThatHasBusinessAddressAsNullAndMailingAddressValidWithIsBusinessAdddressSameAsMailingAddressSetToTrue();
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        private void GivenAMerchantGeneralInformationThatHasInValidBusinessAddress()
        {
            GeneralInformation.BusinessAddress = new Address {AddressLine1 = string.Empty};
        }

        private void GivenAMerchantGeneralInformationThatHasBusinessAddressAsNullAndMailingAddressValidWithIsBusinessAdddressSameAsMailingAddressSetToTrue()
        {
            GeneralInformation.IsMailingAddressSameAsBusinessAddress = true;
            GeneralInformation.BusinessAddress = null;
        }

        private void GivenAMerchantGeneralInformationThatHasBusinessAddressAsNull()
        {
            GeneralInformation.BusinessAddress = null;
        }      
    }
}
