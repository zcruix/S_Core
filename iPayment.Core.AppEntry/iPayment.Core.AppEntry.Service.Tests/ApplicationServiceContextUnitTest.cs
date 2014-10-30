using System.Collections.Generic;
using System.Linq;
using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Service.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Service.Tests
{
    [TestClass]
    public class ApplicationServiceContextUnitTest
    {
        [TestMethod]
        public void InValid_Context_should_have_errors()
        {
            GivenAnApplicationServiceContextWithInvalidApplicationForm();
            WhenContextDotIsValidIsCalled();
            ThenTheConextIsNotValid();
        }

        [TestMethod]
        public void InValid_Validator_should_return_false()
        {
            GivenAnApplicationServiceContextWithInvalidApplicationForm();
            WhenContextDotIsValidIsCalledWithValidator(_inValidApplicationForm);
            ThenTheConextIsNotValid();
        }

        [TestMethod]
        public void Valid_Validator_should_return_true()
        {
            GivenAnApplicationServiceContextWithValidApplicationForm();
            WhenContextDotIsValidIsCalledWithValidator(new ApplicationForm());
            ThenTheConextIsValid();
        }

        private void ThenTheConextIsValid()
        {
            Assert.IsTrue(_validationResult);
        }

        private void GivenAnApplicationServiceContextWithValidApplicationForm()
        {
            GetApplicationServiceContext(null, null);
            new ApplicationForm();
        }

        private void WhenContextDotIsValidIsCalledWithValidator(IValidator validator)
        {
            GetApplicationServiceContext(null, null);
           _validationResult = _context.IsValid(validator);
        }

        private static void GetApplicationServiceContext(IApplicationFormRepository repository, IApplicationForm applicationForm)
        {
            _context = new ApplicationServiceContext(repository, applicationForm);
        }

        private void ThenTheConextIsNotValid()
        {
            Assert.IsFalse(_validationResult);
            Assert.IsTrue(_context.Errors.Any());            
        }

        private void WhenContextDotIsValidIsCalled()
        {
            _validationResult = _context.IsValid();
        }

        private static void GivenAnApplicationServiceContextWithInvalidApplicationForm()
        {
            _inValidApplicationForm = new ApplicationForm
            {
                Errors = new List<IError>
                {
                    new Error
                    {
                        ErrorMessage = "ErrorMessage",
                        ErrorSeverity = ErrorSeverity.UnKnown,
                        FieldName = "FieldName",
                        FieldValue = "FieldValue",
                        State = "State"
                    }
                }
            };
            GetApplicationServiceContext(null, _inValidApplicationForm);
        }

        private static ApplicationServiceContext _context;
        private bool _validationResult;
        private static ApplicationForm _inValidApplicationForm;
    }
}
