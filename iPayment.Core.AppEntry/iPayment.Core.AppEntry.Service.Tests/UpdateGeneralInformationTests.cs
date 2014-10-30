using System;
using iPayment.Core.AppEntry.Data.Repositories;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Tests;
using iPayment.Core.AppEntry.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Service.Tests
{
    [TestClass]
    public class UpdateGeneralInformationTests
    {
        [TestInitialize]
        public void Init()
        {
            _someGeneralInformation = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();            
            _service = new ApplicationService(ServiceContextFactory.GetMockApplicationServiceContext());            
            _service.SaveGeneralInformation(_service.Context.ApplicationId, _someGeneralInformation);
        }

        [TestMethod]
        public void ShouldUpdateMerchantGeneralInformation()
        {
            GivenAnUpdatedMerchantGeneralInformation();
            WhenUpdateMerchantGeneralInformationIsCalled();
            ThenTheMerchantGeneralInformationShouldBeUpdated(_service.Context.ApplicationId);
        }

        private void GivenAnUpdatedMerchantGeneralInformation()
        {
            _someGeneralInformation.ContactFirstName = "Updated First Name";
        }

        private void ThenTheMerchantGeneralInformationShouldBeUpdated(Guid applicationId)
        {
            Assert.AreEqual(_someGeneralInformation, _service.GetGeneralInformation(applicationId)); 
        }

        private void WhenUpdateMerchantGeneralInformationIsCalled()
        {
            _service.SaveGeneralInformation(_service.Context.ApplicationId, _someGeneralInformation);
        }

        private IGeneralInformation _someGeneralInformation;
        private IApplicationService _service;
    }
}