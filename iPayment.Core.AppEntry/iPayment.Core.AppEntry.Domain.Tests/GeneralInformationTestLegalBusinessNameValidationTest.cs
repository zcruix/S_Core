using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class GeneralInformationTestLegalBusinessNameValidationTest : GeneralInformationTestBase
    {
        private const string LegalBusinessNameIsRequired = @"Legal Business Name is required.";

        [TestMethod]        
        public void Validate_MerchantGeneralInformation_LegalBusinessName_Input_Null()
        {
            GivenAMerchantGeneralInformationWithNullForLegalBusinessName();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(LegalBusinessNameIsRequired);
        }

        [TestMethod]        
        public void Validate_MerchantGeneralInformation_LegalBusinessName_Input_Empty()
        {
            GivenAMerchantGeneralInformationWithEmptyStringForLegalBusinessName();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(LegalBusinessNameIsRequired);
        }

        [TestMethod]
        public void Validate_MerchantGeneralInformation_LegalBusinessName_Same_As_DoingBusinessAs_When_IsDoingBusinessAsNameSameAsLegalBusinessName_Is_Set()
        {
            GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSet();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheDoingBusinessNameIsSameAsLegalBusinessName();
        }

        [TestMethod]        
        public void Validate_MerchantGeneralInformation_LegalBusinessName_When_IsDoingBusinessAsNameSameAsLegalBusinessName_Is_Not_Set()
        {
            GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSetToFalse();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(LegalBusinessNameIsRequired);
        }

        [TestMethod]
        public void Validate_LegalBusinessName_When_IsDoingBusinessAsNameSameAsLegalBusinessName_Is_Set_And_LegalBusinessNameNotEmpty_And_DoingBusinessName_Empty()
        {
            GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSetToTrueWhileDoingBusinessAsNameIsEmpty();
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        private void GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSetToTrueWhileDoingBusinessAsNameIsEmpty()
        {
            GeneralInformation.DoingBusinessAsName = "";
            GeneralInformation.IsDoingBusinessAsNameSameAsLegalBusinessName = true;
        }

        private void GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSetToFalse()
        {
            GeneralInformation.IsDoingBusinessAsNameSameAsLegalBusinessName = false;
            GeneralInformation.LegalBusinessName = "";
        }

        private void ThenTheDoingBusinessNameIsSameAsLegalBusinessName()
        {
            Assert.AreEqual(GeneralInformation.DoingBusinessAsName, GeneralInformation.LegalBusinessName);
            Assert.IsTrue(IsValidMerchantGeneralInformation);
        }

         private void GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSet()
        {
            GeneralInformation.IsDoingBusinessAsNameSameAsLegalBusinessName = true;
        }


        private void GivenAMerchantGeneralInformationWithEmptyStringForLegalBusinessName()
        {
            GeneralInformation.LegalBusinessName = "";
        }

        private void GivenAMerchantGeneralInformationWithNullForLegalBusinessName()
        {
            GeneralInformation.LegalBusinessName = null;
        }
    }
}