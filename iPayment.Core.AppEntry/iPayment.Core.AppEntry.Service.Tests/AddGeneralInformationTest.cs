using System;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Tests;
using iPayment.Core.AppEntry.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Service.Tests
{
    [TestClass]
    public class AddGeneralInformationTest : GeneralInformationTestBase
    {
        [TestMethod]
        public void ShouldAddMerchantGeneralInformation()
        {
            GivenAMerchantGeneralInformation();
            WhenAddMerchantGeneralInformationIsCalled();
            ThenTheMerchantGeneralInformationShouldBeAdded(_applicationService.Context.ApplicationId);
        }

        private void ThenTheMerchantGeneralInformationShouldBeAdded(Guid applicationId)
        {
            Assert.AreEqual(_someGeneralInformation, _applicationService.GetGeneralInformation(applicationId)); 
        }

        private void WhenAddMerchantGeneralInformationIsCalled()
        {
            _applicationService = new ApplicationService(ServiceContextFactory.GetMockApplicationServiceContextWithGeneralInformation());
            _applicationService.SaveGeneralInformation(_applicationService.Context.ApplicationId, _someGeneralInformation);

        }

        private void GivenAMerchantGeneralInformation()
        {
            _someGeneralInformation = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();
        }

        private IGeneralInformation _someGeneralInformation;
        private IApplicationService _applicationService;
    }
}
