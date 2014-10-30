using System.Net.Http;
using System.Web.Http;
using iPayment.Core.Services.AppEntry.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Controllers
{
    [TestClass]
    public class ApplicationEntryControllerTest : ApplicationEntryControllerTestBase
    {
        [TestMethod]
        public void can_create_applicationEntryController_with_empty_constructor()
        {
            GivenAnApplicationEntryController();
            ThenTheControllerIsNotNull();
        }

        private static void ThenTheControllerIsNotNull()
        {
            Assert.IsNotNull(_controller);
        }

        [TestMethod]
        public void Context_can_create_error_response()
        {
            GivenAnApplicationEntryController();
            WhenErrorResponseIsCreated();
            Assert.IsNotNull(_errorResponse);
            Assert.IsInstanceOfType(_errorResponse, (typeof(HttpResponseMessage)));
        }

        private void WhenErrorResponseIsCreated()
        {
            _errorResponse = ApplicationEntryControllerContext.CreateErrorResponse(_controller, "error");
        }

        private static void GivenAnApplicationEntryController()
        {
            _controller = new ApplicationEntryController {Request = new HttpRequestMessage()};            
        }

        private static ApiController _controller;
        private HttpResponseMessage _errorResponse;
    }
}