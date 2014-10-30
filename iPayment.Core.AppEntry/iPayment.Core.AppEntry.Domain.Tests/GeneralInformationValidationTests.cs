using System.Linq;
using iPayment.Core.AppEntry.Domain.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class GeneralInformationValidationTests
    {
        [TestMethod]
        public void GeneralInformation_With_InValid_Data_Should_Fail()
        {
            GivenAGeneralInformationWithInvalidData();
            WhenMerchantGeneralInformationIsValidated();
            ThenTheValidationResultIsFalse();
        }

        private void ThenTheValidationResultIsFalse()
        {
            Assert.IsFalse(_isValid);
            Assert.IsTrue(_generalInformation.Errors.Any());            
            var error = _generalInformation.Errors.FirstOrDefault();
            Assert.IsTrue(error != null && !string.IsNullOrEmpty(error.ErrorMessage));
        }

        private void WhenMerchantGeneralInformationIsValidated()
        {
            _isValid = _generalInformation.IsValid();
        }

        private void GivenAGeneralInformationWithInvalidData()
        {
            _generalInformation = new GeneralInformation(new GeneralInformationValidator());
        }

        private GeneralInformation _generalInformation;
        private bool _isValid;
    }
}
