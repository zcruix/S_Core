using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class MerchantGeneralInformationTestDoingBusinessAsValidationTest : MerchantGeneralInformationTestBase
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
            MerchantGeneralInformation.DoingBusinessAsName = "";
            MerchantGeneralInformation.IsDoingBusinessAsNameSameAsLegalBusinessName = true;
        }

        private void GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSetToFalse()
        {
            MerchantGeneralInformation.IsDoingBusinessAsNameSameAsLegalBusinessName = false;
            MerchantGeneralInformation.DoingBusinessAsName = "";
        }

        private void ThenTheDoingBusinessNameIsSameAsLegalBusinessName()
        {
            Assert.AreEqual(MerchantGeneralInformation.DoingBusinessAsName, MerchantGeneralInformation.LegalBusinessName);
            Assert.IsTrue(IsValidMerchantGeneralInformation);
        }

        private void GivenAMerchantGeneralInformationWithIsDoingBusinessAsNameSameAsLegalBusinessNameSet()
        {
            MerchantGeneralInformation.IsDoingBusinessAsNameSameAsLegalBusinessName = true;            
        }

        private void GivenAMerchantGeneralInformationWithEmptyStringForDBAName()
        {
            MerchantGeneralInformation.DoingBusinessAsName = "";
        }

        private void GivenAMerchantGeneralInformationWithNullForDBAName()
        {
            MerchantGeneralInformation.DoingBusinessAsName = null;
        }
    }
}