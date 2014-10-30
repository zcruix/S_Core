using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Controllers
{
    [TestClass]
    public class ApplicationEntryControllerGeneralInformationTests : ApplicationEntryControllerTestBase
    {
        [TestMethod]
        public void get_general_information_returns_valid_merchantgeneralinfo_dto()
        {
            WhenGetGeneralInformationIsInvoked();

            ThenTheHttpResponseMessageIsValidMerchantGeneralInformationDto();
        }

        [TestMethod]
        public void post_add_general_information_dto_returns_success()
        {
            GivenAGeneralInformationDto();

            WhenPostGeneralInformationIsInvoked();

            ThenTheHttpResponseMessageShouldBeCreated();
        }

        [TestMethod]
        public void post_invalid_general_information_dto_should_return_error()
        {
            GivenAGeneralInformationDtoWithInvalidInformation();

            WhenPostGeneralInformationIsInvoked();

            ThenTheHttpResponseMessageShouldContainError();
        }
    }   
}