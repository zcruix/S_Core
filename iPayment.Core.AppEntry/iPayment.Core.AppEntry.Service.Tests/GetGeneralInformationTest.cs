using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Service.Tests
{
    [TestClass]
    public class GetGeneralInformationTest : GeneralInformationTestBase
    {
        [TestMethod]
        public void Can_get_general_information()
        {            
            WhenGetGeneralInformationInvoked();
            ThenTheGeneralInformationIsReturned();
        }

        private void ThenTheGeneralInformationIsReturned()
        {
            Assert.IsNotNull(_generalInformation);
        }

        private void WhenGetGeneralInformationInvoked()
        {
            _applicationService = new ApplicationService(ServiceContextFactory.GetMockApplicationServiceContextWithGeneralInformation());
            _generalInformation =  _applicationService.GetGeneralInformation(_applicationService.Context.ApplicationId);
        }
        
        private IGeneralInformation _generalInformation;
        private IApplicationService _applicationService;
    }
}