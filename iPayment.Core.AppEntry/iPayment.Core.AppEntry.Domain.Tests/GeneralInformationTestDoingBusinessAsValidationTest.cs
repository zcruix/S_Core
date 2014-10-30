using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class GeneralInformationTestDoingBusinessAsValidationTest : GeneralInformationTestBase
    {
        private const string DoingBusinessAsNameIsRequired = @"Doing Business As Name is required.";

        [TestMethod]        
        public void Validate_MerchantGeneralInformation_DoingBusinessAs_Input_Null()
        {
            GivenAMerchantGeneralInformationWithNullForDBAName();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(DoingBusinessAsNameIsRequired);
        }

        [TestMethod]        
        public void Validate_MerchantGeneralInformation_DoingBusinessAs_Input_Empty()
        {
            GivenAMerchantGeneralInformationWithEmptyStringForDBAName();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(DoingBusinessAsNameIsRequired);
        }

        [TestMethod]
        public void Validate_MerchantGeneralInformation_DoingBusinessAs_Same_As_LegalBusinessName_When_IsDoingBusinessAsNameSameAsLegalBusinessName_Is_Set()
        {
            GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSet();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheDoingBusinessNameIsSameAsLegalBusinessName();
        }

        [TestMethod]        
        public void Validate_MerchantGeneralInformation_DoingBusinessAs_When_IsDoingBusinessAsNameSameAsLegalBusinessName_Is_Not_Set()
        {
            GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSetToFalse();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(DoingBusinessAsNameIsRequired);
        }


        [TestMethod]        
        public void Validate_DoingBusinessAs_When_IsDoingBusinessAsNameSameAsLegalBusinessName_Is_Set_And_LegalBusinessNameNotEmpty_And_DoingBusinessAs_Empty()
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
            GeneralInformation.DoingBusinessAsName = "";
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

        private void GivenAMerchantGeneralInformationWithEmptyStringForDBAName()
        {
            GeneralInformation.DoingBusinessAsName = "";
        }

        private void GivenAMerchantGeneralInformationWithNullForDBAName()
        {
            GeneralInformation.DoingBusinessAsName = null;
        }
    }
}