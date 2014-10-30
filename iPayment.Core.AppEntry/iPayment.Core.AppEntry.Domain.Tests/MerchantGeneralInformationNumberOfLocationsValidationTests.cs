using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class MerchantGeneralInformationNumberOfLocationsValidationTests : MerchantGeneralInformationTestBase
    {        
        [TestMethod]
        public void A_business_can_have_number_of_locations_between_0_and_99999()
        {
            GivenAMerchantGeneralInformationDotNumberOfLocationsWith(1);
            WhenMerchantGeneralInformationIsValidated();
            ThenMerchantGeneralInformationIsValid();
        }

        [TestMethod]
        public void A_business_cannot_have_negative_number_of_locations()
        {
            GivenAMerchantGeneralInformationDotNumberOfLocationsWith(-1);
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(NumberOfLocationsValidationMessage);
        }
        
        [TestMethod]
        public void A_business_cannot_have_more_than_99999_number_of_locations()
        {
            GivenAMerchantGeneralInformationDotNumberOfLocationsWith(1000000);
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(NumberOfLocationsValidationMessage);
        }

        private void GivenAMerchantGeneralInformationDotNumberOfLocationsWith(int someNumberOfLocations)
        {
            MerchantGeneralInformation.NumberOfLocations = someNumberOfLocations;
        }

        private const string NumberOfLocationsValidationMessage = @"Number of locations has to be a valid number between 0 and 99999.";
    }
}
