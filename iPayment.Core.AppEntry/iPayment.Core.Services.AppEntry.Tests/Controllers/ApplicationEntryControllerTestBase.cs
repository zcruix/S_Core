using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iPayment.Core.AppEntry.Domain.Tests;
using iPayment.Core.AppEntry.DTO;
using iPayment.Core.AppEntry.DTO.Requests;
using iPayment.Core.AppEntry.Service;
using iPayment.Core.AppEntry.Service.Context;
using iPayment.Core.AppEntry.Service.Tests;
using iPayment.Core.Services.AppEntry.Context;
using iPayment.Core.Services.AppEntry.Controllers;
using iPayment.Core.Services.AppEntry.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Controllers
{
    public class ApplicationEntryControllerTestBase
    {     
        [TestInitialize]
        public virtual void Initialize()
        {
            SomeApplicationFormRequestDto = new ApplicationFormRequestDto();
            MockApplicationServiceContext = ServiceContextFactory.GetMockApplicationServiceContext();
            _applicationService = new ApplicationService(MockApplicationServiceContext);
            ApplicationEntryControllerContext = new ApplicationEntryControllerContext(_applicationService);
            ApplicationEntryController = new ApplicationEntryController(ApplicationEntryControllerContext) { Request = new HttpRequestMessage() };
            ApplicationEntryController.Request.SetConfiguration(new HttpConfiguration());                        
        }

        protected void ThenTheHttpResponseMessageShouldContainError()
        {
            Assert.IsNotNull(Result);
            Assert.IsTrue(Result.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, Result.StatusCode);
            const int expectedErrorCount = 2;
            var generalInformationDto = Result.Content.ReadAsAsync<GeneralInformationDto>().Result;            
            var errors = generalInformationDto.Errors.ToList();
            Assert.AreEqual(expectedErrorCount, errors.Count);
            Assert.AreEqual(@"Doing Business As Name is required.", errors.Find(x => x.FieldName == "DoingBusinessAsName").ErrorMessage);
            Assert.AreEqual(@"Legal Business Name is required.", errors.Find(x => x.FieldName == "LegalBusinessName").ErrorMessage);
        }

        protected void GivenAGeneralInformationDtoWithInvalidInformation()
        {
            var someMerchant = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();
            someMerchant.LegalBusinessName = String.Empty;
            someMerchant.DoingBusinessAsName = String.Empty;
            GeneralInfoDto = someMerchant.ConvertToGeneralInfoDto();
        }

        protected void ThenTheHttpResponseMessageShouldBeCreated()
        {
            Assert.IsNotNull(Result);
            Assert.IsTrue(Result.IsSuccessStatusCode);      
            Assert.AreEqual(HttpStatusCode.Created, Result.StatusCode);
        }

        protected void WhenPostGeneralInformationIsInvoked()
        {
            Result = ApplicationEntryController.GeneralInformation(MockApplicationServiceContext.ApplicationId,GeneralInfoDto);
        }

        protected void GivenAGeneralInformationDto()
        {
            GeneralInfoDto = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation().ConvertToGeneralInfoDto();
        }

        protected void ThenTheHttpResponseMessageIsValidMerchantGeneralInformationDto()
        {
            Assert.IsNotNull(Result);
            Assert.IsTrue(Result.IsSuccessStatusCode);
            Assert.IsInstanceOfType(Result.Content.ReadAsAsync<GeneralInformationDto>().Result,
                typeof (GeneralInformationDto));
        }

        protected void WhenGetGeneralInformationIsInvoked()
        {
            Result = ApplicationEntryController.GeneralInformation(MockApplicationServiceContext.ApplicationId);
        }

        protected ApplicationFormRequestDto SomeApplicationFormRequestDto;      
        protected ApplicationEntryController ApplicationEntryController;
        protected HttpResponseMessage Result;        
        protected GeneralInformationDto GeneralInfoDto;
        protected ApplicationServiceContext MockApplicationServiceContext;
        private ApplicationService _applicationService;
        protected ApplicationEntryControllerContext ApplicationEntryControllerContext;
    }
}