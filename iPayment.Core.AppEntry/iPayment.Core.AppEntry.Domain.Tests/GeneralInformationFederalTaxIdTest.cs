using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class GeneralInformationFederalTaxIdTest : GeneralInformationTestBase
    {
        [TestMethod]        
        public void FedealTaxId_Cannot_Be_Null()
        {
            GivenAMerchantGeneralInformationThatHasFederalTaxIDAsNull();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheResultantErrorShouldBe(@"Federal Tax Id is required.");
        }

        private void GivenAMerchantGeneralInformationThatHasFederalTaxIDAsNull()
        {
            GeneralInformation.FederalTaxID = null;
        }
    }
}
