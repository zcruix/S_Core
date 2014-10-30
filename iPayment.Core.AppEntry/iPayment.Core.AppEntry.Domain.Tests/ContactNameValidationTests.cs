using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class ContactNameValidationTests : MerchantGeneralInformationTestBase
    {
        [TestMethod]        
        public void ContactFirstName_Cannot_Be_Empty()
        {
            GivenAMerchantGeneralInformationWithContactFirstNameEmpty();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(FirstNameIsRequired);
        }
        
        [TestMethod]        
        public void ContactFirstName_Cannot_Be_Null()
        {
            GivenAMerchantGeneralInformationWithContactFirstNameAsNull();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(FirstNameIsRequired);
        }

        [TestMethod]        
        public void ContactLastName_Cannot_Be_Empty()
        {
            GivenAMerchantGeneralInformationWithContactLastNameEmpty();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(LastNameIsRequired);
        }

        [TestMethod]        
        public void ContactLastName_Cannot_Be_Null()
        {
            GivenAMerchantGeneralInformationWithContactLastNameAsNull();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(LastNameIsRequired);
        }

        private void GivenAMerchantGeneralInformationWithContactFirstNameAsNull()
        {
            MerchantGeneralInformation.ContactFirstName = null;
        }

        private void GivenAMerchantGeneralInformationWithContactFirstNameEmpty()
        {
            MerchantGeneralInformation.ContactFirstName = String.Empty;
        }

        private void GivenAMerchantGeneralInformationWithContactLastNameAsNull()
        {
            MerchantGeneralInformation.ContactLastName = null;
        }

        private void GivenAMerchantGeneralInformationWithContactLastNameEmpty()
        {
            MerchantGeneralInformation.ContactLastName = String.Empty;
        }

        private const string FirstNameIsRequired = "First Name is required.";
        private const string LastNameIsRequired = "Last Name is required.";
    }
}