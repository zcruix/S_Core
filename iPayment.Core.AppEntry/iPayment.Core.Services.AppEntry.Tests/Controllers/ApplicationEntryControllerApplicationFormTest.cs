using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Controllers
{
    [TestClass]
    public class ApplicationEntryControllerApplicationFormGetTests : ApplicationEntryControllerTestBase
    {
        [TestMethod]
        public void get_applicationForm_with_nonExisting_applicationId_should_return_content_not_found_error()
        {
            GivenAnApplicationID(Guid.NewGuid());

            WhenGetApplicationFormIsInvoked();

            ThenTheHttpResponseMessageShouldReturnNoContent();
        }

        [TestMethod]
        public void get_applicationForm_with_existing_applicationId_should_return_application_form_dto()
        {
            GivenAnApplicationID(MockApplicationServiceContext.ApplicationId);

            WhenGetApplicationFormIsInvoked();

            ThenTheHttpResponseMessageShouldReturnApplicationFormDto();
        }

        private void ThenTheHttpResponseMessageShouldReturnApplicationFormDto()
        {
            Assert.IsTrue(Result.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, Result.StatusCode);
        }

        private void ThenTheHttpResponseMessageShouldReturnNoContent()
        {
            Assert.IsTrue(Result.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.NoContent, Result.StatusCode);
        }

        private void WhenGetApplicationFormIsInvoked()
        {
            Result = ApplicationEntryController.ApplicationForm(_someApplicationId);
        }

        private void GivenAnApplicationID(Guid applicationId)
        {
            _someApplicationId = applicationId;
        }

       private Guid _someApplicationId;
    }
}