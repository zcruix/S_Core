using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class BusinessBusinessEmailValidationTests : GeneralInformationTestBase  
    {
        private const string InValidEmailErrorMessage = @"Business Email address has to be a valid email address.";

        [TestMethod]
        public void BusinessEmail_Should_Be_Valid()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test@test.com");
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        [TestMethod]
        public void BusinessEmail_Cannot_Be_Valid_With_IP_Host()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test@1.0.0.127");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }
        
        [TestMethod]
        public void BusinessEmail_Cannot_Not_Have_Domain()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }   
        
        [TestMethod]
        public void BusinessEmail_Domain_Cannot_Be_Empty()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test@");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }
        
        [TestMethod]
        public void BusinessEmail_DomainName_Cannot_Be_Empty()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test@com");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }

        [TestMethod]
        public void BusinessEmail_Host_Extension_Cannot_Have_More_Than_One_Period()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test@test..com");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }

        [TestMethod]
        public void BusinessEmail_Cannot_Not_Have_The_Name_Portion()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"@test.com");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }

        [TestMethod]
        public void BusinessEmail_Can_Have_Plus()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test+test@Test.com");
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        [TestMethod]
        public void BusinessEmail_Can_Have_Period_In_The_Name_Portion()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"test.something@test.com");
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        [TestMethod]
        public void BusinessEmail_Cannot_Have_BackSlash_In_The_Name_Portion()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"me\@test.com");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }

        [TestMethod]
        public void BusinessEmail_Cannot_Start_With_Period_In_The_Name_Portion()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@".me@test.com");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }
        
        [TestMethod]
        public void BusinessEmail_Cannot_Have_Special_Charcaters()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"!#$%&'+-/=.?^`{|}~@[1.0.0.127]");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }

        [TestMethod]
        public void Name_Portion_of_The_BusinessEmail_Cannot_End_With_Period()
        {
            GivenAnMerchantGeneralInformationWithBusinessEmail(@"me.@test.com");
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(InValidEmailErrorMessage);
        }

        private void GivenAnMerchantGeneralInformationWithBusinessEmail(string someBusinessEmail)
        {
            GeneralInformation.BusinessEmail = someBusinessEmail;
        }
    }
}
