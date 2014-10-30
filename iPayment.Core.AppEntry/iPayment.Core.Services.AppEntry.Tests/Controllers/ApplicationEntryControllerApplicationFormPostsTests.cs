using iPayment.Core.AppEntry.DTO;
using iPayment.Core.AppEntry.DTO.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Controllers
{
    [TestClass]
    public class ApplicationEntryControllerApplicationFormPostsTests : ApplicationEntryControllerTestBase
    {
        [TestMethod]
        public void post_applicationForm_with_new_applicationFormDto_should_create_new_application_form()
        {
            GivenAnApplicationFormRequestDto(new ApplicationFormRequestDto());

            WhenPostApplicationFormIsInvoked();

            ThenTheHttpResponseMessageShouldBeCreated();
        }

        private void WhenPostApplicationFormIsInvoked()
        {
            Result = ApplicationEntryController.ApplicationForm(SomeApplicationFormRequestDto);
        }

        private void GivenAnApplicationFormRequestDto(ApplicationFormRequestDto applicationFormRequestDto)
        {
            SomeApplicationFormRequestDto = applicationFormRequestDto;
        }        
    }
}