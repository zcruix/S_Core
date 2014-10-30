using System.Net.Http;
using System.Web.Http;
using iPayment.Core.AppEntry.Service.Interfaces;

namespace iPayment.Core.Services.AppEntry.Context
{
    public interface IApplicationEntryControllerContext
    {
        string ErrorResponse { get; set; }
        IApplicationService AppService { get; }
        HttpResponseMessage CreateErrorResponse(ApiController controller, string errorResponse);
    }
}