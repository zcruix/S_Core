using System.Linq;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class PhoneValidationTests 
    {        
        [TestInitialize]
        public void Initialize()
        {
            _phone = new Phone {Number = "9999999999", PhoneType = PhoneType.Home};
        }

        [TestMethod]        
        public void PhoneNumber_Cannot_Have_Characters()
        {
            GivenAPhoneNumberThatHasNonNumericCharacters();
            WhenPhoneNumberIsValidated();
            ThenTheResultantErrorShouldBe(@"Phone number cannot have non numeric characters.");
        }

        [TestMethod]        
        public void PhoneNumber_Cannot_Have_Less_Than_Ten_Digits()
        {
            GivenAPhoneNumberThatHasLessThanTenDigits();
            WhenPhoneNumberIsValidated();
            ThenTheResultantErrorShouldBe(PhoneNumberHasToBeTenDigitsInLength);
        }

        [TestMethod]        
        public void PhoneNumber_Cannot_Have_More_Than_Ten_Digits()
        {
            GivenAPhoneNumberThatHasMoreThanTenDigits();
            WhenPhoneNumberIsValidated();
            ThenTheResultantErrorShouldBe(PhoneNumberHasToBeTenDigitsInLength);
        }


        [TestMethod]        
        public void PhoneType_Cannot_Be_UnKnown()
        {
            GivenAPhoneThatHasPhoneTypeUnknown();
            WhenPhoneNumberIsValidated();
            ThenTheResultantErrorShouldBe(@"Phone type cannot be UnKnown.");
        }
        
        [TestMethod]        
        public void PhoneNumber_Cannot_Be_Empty()
        {
            GivenAPhoneThatHasPhoneNumberEmpty();
            WhenPhoneNumberIsValidated();
            ThenTheResultantErrorShouldBe(PhoneNumberCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void PhoneNumber_Cannot_Be_Null()
        {
            GivenAPhoneThatHasPhoneNumberAsNull();
            WhenPhoneNumberIsValidated();
            ThenTheResultantErrorShouldBe(PhoneNumberCannotBeEmptyOrNull);
        }


        [TestMethod]
        public void PhoneNumber_Should_Have_Exactly_Ten_Digits()
        {
            GivenAPhoneNumberThatHasExactTenNumericDigits();
            WhenPhoneNumberIsValidated();
            TheThePhoneNumberIsValid();
        }

        private void ThenTheResultantErrorShouldBe(string someError)
        {
            Assert.IsFalse(_isValidPhone);
            Assert.AreEqual(someError, _phone.Errors.First().ErrorMessage);
        }

        private void GivenAPhoneThatHasPhoneNumberAsNull()
        {
            _phone.Number = null;
        }

        private void GivenAPhoneThatHasPhoneNumberEmpty()
        {
            _phone.Number = string.Empty;
        }

        private void GivenAPhoneThatHasPhoneTypeUnknown()
        {
            _phone.PhoneType = PhoneType.UnKnown;
        }

        private void TheThePhoneNumberIsValid()
        {
            Assert.IsTrue(_isValidPhone);
        }

        private void GivenAPhoneNumberThatHasExactTenNumericDigits()
        {
            _phone.Number = "8008889999";
        }

        private void GivenAPhoneNumberThatHasLessThanTenDigits()
        {
            _phone.Number = "2224444";
        }

        private void GivenAPhoneNumberThatHasMoreThanTenDigits()
        {
            _phone.Number = "12223334444";
        }

        private void WhenPhoneNumberIsValidated()
        {
            _isValidPhone = _phone.IsValid();
        }

        private void GivenAPhoneNumberThatHasNonNumericCharacters()
        {
            _phone.Number = "1800ABCDEFG";
        }

        private IPhone _phone;
        private bool _isValidPhone;
        private const string PhoneNumberCannotBeEmptyOrNull = @"Phone Number cannot be empty or null.";
        private const string PhoneNumberHasToBeTenDigitsInLength = @"Phone Number has to be 10 digits in length.";
    }
}