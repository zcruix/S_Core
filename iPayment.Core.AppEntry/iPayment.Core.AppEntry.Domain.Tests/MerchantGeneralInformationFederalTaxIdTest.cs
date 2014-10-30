using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class MerchantGeneralInformationFederalTaxIdTest : MerchantGeneralInformationTestBase
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
            MerchantGeneralInformation.FederalTaxID = null;
        }
    }
}
