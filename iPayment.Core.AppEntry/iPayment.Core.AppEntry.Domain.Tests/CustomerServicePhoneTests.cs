using iPayment.Core.AppEntry.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class CustomerServicePhoneTests : GeneralInformationTestBase
    {
        [TestMethod]        
        public void CustomerServicePhone_Cannot_Be_Null()
        {
            GivenAMerchantGeneralInformationWithCustomerServicePhoneAsNull();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"Customer service phone number is required.");
        }

        [TestMethod]
        public void CustomerServicePhone_PhoneType_Should_Be_CustomerService()
        {
            GivenAMerchantGeneralInformationWithCustomerServicePhoneType();
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        [TestMethod]        
        public void CustomerServicePhone_PhoneType_Cannot_Be_UnKnown()
        {
            GivenAMerchantGeneralInformationWithInValidCustomerServicePhone();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"Phone type cannot be UnKnown.");
        }

        private void GivenAMerchantGeneralInformationWithInValidCustomerServicePhone()
        {
            GeneralInformation.CustomerServicePhone.PhoneType = PhoneType.UnKnown;
        }

        private void GivenAMerchantGeneralInformationWithCustomerServicePhoneType()
        {
            GeneralInformation.CustomerServicePhone.PhoneType = PhoneType.CustomerService;
        }

        private void GivenAMerchantGeneralInformationWithCustomerServicePhoneAsNull()
        {
            GeneralInformation.CustomerServicePhone = null;
        }       
    }
}