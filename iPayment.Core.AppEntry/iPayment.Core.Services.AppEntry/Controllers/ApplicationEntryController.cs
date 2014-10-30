using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iPayment.Core.AppEntry.Data.Exceptions;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.DTO;
using iPayment.Core.AppEntry.DTO.Requests;
using iPayment.Core.AppEntry.Service.Enums;
using iPayment.Core.AppEntry.Service.Interfaces;
using iPayment.Core.Services.AppEntry.Context;
using iPayment.Core.Services.AppEntry.Factories;
using iPayment.Core.Services.AppEntry.Mappers;

namespace iPayment.Core.Services.AppEntry.Controllers
{
    public class ApplicationEntryController : ApiController
    {
        private readonly IApplicationService _appEntryService;

        public ApplicationEntryController() : this(null){}

        public ApplicationEntryController(ApplicationEntryControllerContext applicationEntryControllerContext = null)
        {
            var controllerContext = applicationEntryControllerContext ?? new ApplicationEntryControllerContext();
            _appEntryService = controllerContext.AppService;
        }

        /// <summary>
        /// Retrieves application form for a given application id.
        /// </summary>
        /// <param name="applicationId">System.Guid</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]                
        public HttpResponseMessage ApplicationForm(Guid applicationId)
        {
            IApplicationForm applicationForm;
            try
            {
                applicationForm = _appEntryService.GetApplicationForm(applicationId);
            }
            catch (ApplicationFormNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, applicationId);
            }

            return Request.CreateResponse(HttpStatusCode.OK, applicationForm.ConvertToApplicationFormDto());
        }

        /// <summary>
        /// Creates a new application form.
        /// </summary>
        /// <param name="applicationFormRequestDto">ApplicationFormDto</param>
        /// <returns>HttpResponseMessage containing application form</returns>
        [HttpPost]
        public HttpResponseMessage ApplicationForm(ApplicationFormRequestDto applicationFormRequestDto)
        {
            var applicationForm = applicationFormRequestDto.ConvertToApplicationForm();
            _appEntryService.CreateApplicationForm(Guid.NewGuid());

            //TODO: Create correct response
            return Request.CreateResponse(HttpStatusCode.Created, applicationFormRequestDto);
        }

        /// <summary>
        /// Gets merchant general application form for a given application id.
        /// </summary>
        /// <param name="applicationId">System.Guid</param>
        /// <returns>HttpResponseMessage containing general information.</returns>
        [HttpGet]
        public HttpResponseMessage GeneralInformation(Guid applicationId)
        {         
            var generalInformation = _appEntryService.GetGeneralInformation(applicationId);
            var generalInformationDto = generalInformation.ConvertToGeneralInfoDto();

            //TODO: Create correct response
            return Request.CreateResponse(HttpStatusCode.OK, generalInformationDto);
        }

        /// <summary>
        /// Created or updates the general information for a given application id.
        /// </summary>
        /// <param name="applicationId">System.Guid</param>
        /// <param name="generalInformationDto">New or modified general information.</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        public HttpResponseMessage GeneralInformation(Guid applicationId, GeneralInformationDto generalInformationDto)
        {
            var generalInfo = generalInformationDto.ConvertToGeneralInfo();
            var appEntryService = _appEntryService;
            appEntryService.SaveGeneralInformation(applicationId, generalInfo);
                
            var serviceContext = _appEntryService.Context;            

            //TODO: Create or use response factory to construct messages
            return !serviceContext.IsValid()
                ? Request.CreateResponse(HttpStatusCode.OK, serviceContext.ErrorDto())
                : Request.CreateResponse(
                    serviceContext.Status == Status.Created ? HttpStatusCode.Created : HttpStatusCode.OK,
                    serviceContext.SuccessDto());
        }
    }
}