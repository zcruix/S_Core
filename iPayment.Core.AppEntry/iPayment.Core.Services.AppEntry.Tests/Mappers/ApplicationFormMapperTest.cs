using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.DTO;
using iPayment.Core.AppEntry.DTO.Requests;
using iPayment.Core.Services.AppEntry.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Mappers
{
    [TestClass]
    public class ApplicationFormMapperTest
    {
        [TestMethod]
        public void ApplicationForm_converts_to_applicationFormDto()
        {
            GivenAnApplicationForm();
            WhenApplicationFormIsConvertedToDto();
            ThenTheApplicationFormDtoIsCreated();
        }

        [TestMethod]
        public void ApplicationFormMapDto_converts_to_applicationForm()
        {
            GivenAnApplicationFormDto();
            WhenApplicationFormDtoIsConvertedToApplicationForm();
            ThenTheApplicationFormIsCreated();
        }

        private void ThenTheApplicationFormIsCreated()
        {
            Assert.IsNotNull(_applicationForm);
            Assert.IsInstanceOfType(_applicationForm, typeof (IApplicationForm));
        }

        private void WhenApplicationFormDtoIsConvertedToApplicationForm()
        {
            _applicationForm = _applicationFormRequestDto.ConvertToApplicationForm();
        }

        private void GivenAnApplicationFormDto()
        {
            _applicationFormRequestDto= new ApplicationFormRequestDto();
        }

        private void ThenTheApplicationFormDtoIsCreated()
        {
            Assert.IsNotNull(_applicationFormResponseDto);
            Assert.IsInstanceOfType(_applicationFormResponseDto, typeof (ApplicationFormResponseDto));
        }

        private void WhenApplicationFormIsConvertedToDto()
        {
            _applicationFormResponseDto = _applicationForm.ConvertToApplicationFormDto();
        }

        private void GivenAnApplicationForm()
        {
            _applicationForm = new ApplicationForm();
        }

        private IApplicationForm _applicationForm;
        private ApplicationFormResponseDto _applicationFormResponseDto;
        private ApplicationFormRequestDto _applicationFormRequestDto;
    }
}