using System.Net;
using System.Net.Http;
using System.Web.Http;
using iPayment.Core.AppEntry.Service;
using iPayment.Core.AppEntry.Service.Interfaces;

namespace iPayment.Core.Services.AppEntry.Context
{
    public class ApplicationEntryControllerContext : IApplicationEntryControllerContext
    {
        public string ErrorResponse { get; set; }

        public IApplicationService AppService { get; private set; }

        public ApplicationEntryControllerContext(IApplicationService applicationService = null)
        {
            AppService = applicationService ?? new ApplicationService();
        }        

        public HttpResponseMessage CreateErrorResponse(ApiController controller, string errorResponse)
        {
            return controller.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorResponse);
        }
    }
}