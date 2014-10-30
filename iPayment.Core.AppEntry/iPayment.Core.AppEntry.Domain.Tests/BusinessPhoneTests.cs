using iPayment.Core.AppEntry.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class BusinessPhoneTests : MerchantGeneralInformationTestBase
    {
        [TestMethod]        
        public void BusinessPhone_Cannot_Be_Null()
        {
            GivenAMerchantGeneralInformationWithBusinessPhoneAsNull();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"Business phone number is required.");
        }


        [TestMethod]        
        public void BusinessPhone_PhoneType_Cannot_Be_UnKnown()
        {
            GivenAMerchantGeneralInformationWithInValidBusinessPhone();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"Phone type cannot be UnKnown.");
        }

        [TestMethod]        
        public void BusinessPhone_PhoneType_Should_Be_Business()
        {
            GivenAMerchantGeneralInformationWithBusinessPhoneType();
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }       

        private void GivenAMerchantGeneralInformationWithInValidBusinessPhone()
        {
            MerchantGeneralInformation.BusinessPhone.PhoneType = PhoneType.UnKnown;
        }


        private void GivenAMerchantGeneralInformationWithBusinessPhoneType()
        {
            MerchantGeneralInformation.BusinessPhone.PhoneType = PhoneType.Business;
        }


        private void GivenAMerchantGeneralInformationWithBusinessPhoneAsNull()
        {
            MerchantGeneralInformation.BusinessPhone = null;            
        }
    }
}
