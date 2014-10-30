using System;
using iPayment.Core.AppEntry.Data.Exceptions;
using iPayment.Core.AppEntry.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Service.Tests
{
    [TestClass]
    public class ApplicationFormUnitTests
    {
        [TestMethod]
        public void Can_get_application_form()
        {
            GivenAnApplicationService(NewApplicationId());            
            WhenGetApplicationFormInvoked(_applicationId );
            ThenTheApplicationFormIdNotNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationFormNotFoundException))]
        public void Cannot_find_application_form()
        {
            GivenAnApplicationService(NewApplicationId());
            WhenGetApplicationFormInvoked(NewApplicationId());
        }

        private void ThenTheApplicationFormIdNotNull()
        {
            Assert.IsNotNull(_applicationForm);
        }

        private void WhenGetApplicationFormInvoked(Guid applicationId)
        {
            _applicationForm = _applicationService.GetApplicationForm(applicationId);
        }

        private void GivenAnApplicationService(Guid applicationId)
        {
            _applicationService =
                new ApplicationService(ServiceContextFactory.GetMockApplicationServiceContextWithGeneralInformation());
            _applicationService.CreateApplicationForm(applicationId);
        }


        private static Guid NewApplicationId()
        {

            _applicationId =  Guid.NewGuid();
            return _applicationId;
        }

        private ApplicationService _applicationService;
        private static Guid _applicationId;
        private IApplicationForm _applicationForm;
    }
}