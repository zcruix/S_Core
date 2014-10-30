using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class ContactNameValidationTests : GeneralInformationTestBase
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
            GeneralInformation.ContactFirstName = null;
        }

        private void GivenAMerchantGeneralInformationWithContactFirstNameEmpty()
        {
            GeneralInformation.ContactFirstName = String.Empty;
        }

        private void GivenAMerchantGeneralInformationWithContactLastNameAsNull()
        {
            GeneralInformation.ContactLastName = null;
        }

        private void GivenAMerchantGeneralInformationWithContactLastNameEmpty()
        {
            GeneralInformation.ContactLastName = String.Empty;
        }

        private const string FirstNameIsRequired = "First Name is required.";
        private const string LastNameIsRequired = "Last Name is required.";
    }
}