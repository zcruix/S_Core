using System.Collections.Generic;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class ApplicationFormUnitTests
    {
        [TestMethod]
        public void ApplicationForm_can_be_created()
        {
            WhenApplicationFormIsInstantiated();
            ThenTheApplicationFormIsNotNull();
        }

        [TestMethod]
        public void ApplicationForm_with_errors_is_not_valid()
        {
            GivenAnErrorContext();
            WhenApplicationFormIsInstantiatedWithErrorContext();
            ThenTheApplicationFormIsInValid();
        }

        private void WhenApplicationFormIsInstantiatedWithErrorContext()
        {
            _applicationForm = new ApplicationForm(_errors);            
        }

        private void ThenTheApplicationFormIsInValid()
        {
            Assert.IsFalse(_applicationForm.IsValid());
        }

        private void WhenApplicationFormIsInstantiated()
        {
            _applicationForm = new ApplicationForm();            
        }

        private void ThenTheApplicationFormIsNotNull()
        {
            Assert.IsNotNull(_applicationForm);
        }

        private void GivenAnErrorContext()
        {
            _errors = new List<IError>
            {
                new Error
                {
                    ErrorMessage = "ErrorMessage",
                    ErrorSeverity = ErrorSeverity.UnKnown,
                    FieldName = "FieldName",
                    FieldValue = "FieldValue",
                    State = "SomeState"
                }
            };
        }

        private List<IError> _errors;
        private IApplicationForm _applicationForm;
    }
}
