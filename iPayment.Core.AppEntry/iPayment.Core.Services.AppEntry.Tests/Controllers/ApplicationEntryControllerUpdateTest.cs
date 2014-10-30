using System.Linq;
using System.Net;
using System.Net.Http;
using iPayment.Core.AppEntry.Domain.Tests;
using iPayment.Core.AppEntry.DTO;
using iPayment.Core.AppEntry.DTO.Enums;
using iPayment.Core.AppEntry.DTO.Templates;
using iPayment.Core.Services.AppEntry.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Controllers
{
    [TestClass]
    public class ApplicationEntryControllerUpdateTest : ApplicationEntryControllerTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            GeneralInfoDto = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation().ConvertToGeneralInfoDto();
            ApplicationEntryController.GeneralInformation(MockApplicationServiceContext.ApplicationId , GeneralInfoDto);                        
        }

        [TestMethod]
        public void post_updated_general_info_should_be_successful()
        {
            GivenAnUpdatedGeneralInfoDto();
            WhenPostGeneralInformationIsInvoked();
            ThenTheGeneralInfoShouldBeUpdated();
        }

        [TestMethod]
        public void post_invalid_general_info_should_return_error()
        {
            GivenAnUpdatedGeneralInfoDtoWithInValidDoingBusinessAsName();
            WhenPostGeneralInformationIsInvoked();
            ThenTheResultHasError();
        }

        private void ThenTheResultHasError()
        {
            Assert.IsNotNull(Result);
            Assert.IsTrue(Result.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, Result.StatusCode);
            var dtoFromService = Result.Content.ReadAsAsync<GeneralInformationDto>().Result;
            Assert.IsTrue(dtoFromService.Errors.Any());          

        }

        private void GivenAnUpdatedGeneralInfoDtoWithInValidDoingBusinessAsName()
        {
            GeneralInfoDto.DoingBusinessAsName = null;
        }

        private void ThenTheGeneralInfoShouldBeUpdated()
        {
            Assert.IsNotNull(Result);
            Assert.IsTrue(Result.IsSuccessStatusCode);            
            Assert.AreEqual(HttpStatusCode.OK, Result.StatusCode);
            var dtoFromService = Result.Content.ReadAsAsync<GeneralInformationDto>().Result;
            Assert.IsTrue(!dtoFromService.Errors.Any());          
            Assert.AreEqual(GeneralInfoDto.BusinessAddress, dtoFromService.BusinessAddress);
        }

        private void GivenAnUpdatedGeneralInfoDto()
        {
            GeneralInfoDto.BusinessAddress = new Address
            {
                AddressLine1 = @"New Address Line 1",
                AddressLine2 = @"New Address Line 2",
                AddressType = AddressType.Business,
                City = "New City",
                County = "New County",
                State = "New State",
                Zipcode = "99999"
            };
        }
    }
}