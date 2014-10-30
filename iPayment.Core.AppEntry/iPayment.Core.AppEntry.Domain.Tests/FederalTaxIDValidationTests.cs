using System.Linq;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class FederalTaxIDValidationTests 
    {
        [TestInitialize]
        public void Initialize()
        {
            _federalTaxId = new FederalTaxId {Number = "999999999", TaxIdType = TaxIdType.SSN};
        }

        [TestMethod]        
        public void FederalTaxIDNumber_Cannot_Be_Empty()
        {
            GivenAFederalTaxIDNumberThatIsEmpty();
            WhenFederalTaxIdIsValidated();
            ThenTheResultantErrorIs(TaxIdNumberCannotBeEmptyOrNull);
        }

        [TestMethod]       
        public void FederalTaxID_Cannot_Be_Null()
        {
            GivenAFederalTaxIDWithNumberAsNull();
            WhenFederalTaxIdIsValidated();
            ThenTheResultantErrorIs(TaxIdNumberCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void FederalTaxID_Cannot_Have_Less_Than_Nine_Characters()
        {
            GivenAFederalTaxIDWithLessThanNineCharacters();
            WhenFederalTaxIdIsValidated();
            ThenTheResultantErrorIs(FederalTaxIdShouldBeExactlyNumericDigits);
        }

        [TestMethod]        
        public void FederalTaxID_Cannot_Have_More_Than_Nine_Characters()
        {
            GivenAFederalTaxIDWithMoreThanNineCharacters();
            WhenFederalTaxIdIsValidated();
            ThenTheResultantErrorIs(FederalTaxIdShouldBeExactlyNumericDigits);
        }

        [TestMethod]        
        public void FederalTaxID_Cannot_Be_Non_Numeric()
        {
            GivenAFederalTaxIDWithNonNumericCharacters();
            WhenFederalTaxIdIsValidated();
            ThenTheResultantErrorIs(@"Taxid has non numeric digits.");
        }

        [TestMethod]                
        public void FederalTaxID_TaxIdType__cannot_Be_UnKnown()
        {
            GivenAFederalTaxIDWithUnknownTaxIdType();
            WhenFederalTaxIdIsValidated();
            ThenTheResultantErrorIs(@"TaxIdType cannot be UnKnown.");
        }

        [TestMethod]        
        public void FederalTaxID_Should__Have_Exactly_Nine_Numeric_Digits()
        {
            GivenAFederalTaxIDWithExactlyNineCharacters();
            WhenFederalTaxIdIsValidated();
            ThenFederalTaxIdIsValid();
        }

        private void GivenAFederalTaxIDWithUnknownTaxIdType()
        {
            _federalTaxId.TaxIdType = TaxIdType.UnKnown;
        }

        private void GivenAFederalTaxIDWithNonNumericCharacters()
        {
            _federalTaxId.Number = "ABC124567";
        }

        private void GivenAFederalTaxIDWithLessThanNineCharacters()
        {
            _federalTaxId.Number = "12";
        }

        private void GivenAFederalTaxIDWithMoreThanNineCharacters()
        {
            _federalTaxId.Number = "1234567890123";
        }

        private void GivenAFederalTaxIDWithExactlyNineCharacters()
        {
            _federalTaxId.Number = "123456789";
        }

        private void WhenFederalTaxIdIsValidated()
        {
            _isFederalTaxIdValid = _federalTaxId.IsValid();
        }

        private void GivenAFederalTaxIDNumberThatIsEmpty()
        {
            _federalTaxId.Number = string.Empty;
        }

        private void GivenAFederalTaxIDWithNumberAsNull()
        {
            _federalTaxId.Number = null;
        }

        private void ThenTheResultantErrorIs(string someError)
        {
            Assert.IsFalse(_isFederalTaxIdValid);
            Assert.AreEqual(someError, _federalTaxId.ErrorContext.First().ErrorMessage);
        }

        private void ThenFederalTaxIdIsValid()
        {
            Assert.IsTrue(_isFederalTaxIdValid);
        }

        private IFederalTaxId _federalTaxId;

        private bool _isFederalTaxIdValid;
        private const string TaxIdNumberCannotBeEmptyOrNull = @"Tax Id Number cannot be empty or null.";
        private const string FederalTaxIdShouldBeExactlyNumericDigits = @"Federal Tax Id should be exactly 9 numeric digits.";
    }
}
