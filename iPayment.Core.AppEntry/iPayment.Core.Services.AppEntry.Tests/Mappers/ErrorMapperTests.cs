using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.DTO;
using iPayment.Core.Services.AppEntry.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.Services.AppEntry.Tests.Mappers
{
    [TestClass]
    public class ErrorMapperTests
    {        
        [TestMethod]
        public void MapErrorDto_converts_error_to_errorDto()
        {
            GivenAnError();
            WhenErrorIsMappedToDto();
            ThenTheErrorShouldBeCorrectlyMapped();
        }

        private void ThenTheErrorShouldBeCorrectlyMapped()
        {
            Assert.IsNotNull(_result);
            Assert.IsInstanceOfType(_result, typeof (ErrorDto));
        }

        private void WhenErrorIsMappedToDto()
        {
            _result = ErrorMapper.MapErrorDto(_error);
        }

        private void GivenAnError()
        {
            _error = new Error();
        }

        private IError _error;
        private ErrorDto _result;
    }
}
