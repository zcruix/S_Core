using System.Linq;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    [TestClass]
    public class AddressValidationTests
    {
        [TestInitialize]
        public void Initialize()
        {
            _address = new Address
            {
                AddressType = AddressType.Business,
                AddressLine1 = "Address Line 1",
                City = "City",
                Zipcode = "99999-9999",
                State = "State"
            };
        }

        [TestMethod]        
        public void AddressLine1_Cannot_Be_Empty()
        {
            GivenAnAddressWithEmptyAddressLine1();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(Addressline1CannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void AddressLine1_Cannot_Be_Null()
        {
            GivenAnAddressWithAddressLine1AsNull();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(Addressline1CannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void City_Cannot_Be_Empty()
        {
            GivenAnAddressWithEmptyCity();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(CityCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void City_Cannot_Be_Null()
        {
            GivenAnAddressWithCityAsNull();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(CityCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void ZipCode_Cannot_Be_Empty()
        {
            GivenAnAddressWithEmptyZipCode();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(ZipcodeCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void ZipCode_Cannot_Be_Null()
        {
            GivenAnAddressWithZipCodeAsNull();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(ZipcodeCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void ZipCode_Cannot_Have_More_Than_Ten_Digits()
        {
            GivenAnAddressWithZipCodeMoreThanTenDigits();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(@"Zipcode cannot be more than 10 characters.");
        }

        [TestMethod]        
        public void ZipCode_With_Ten_Digits_Should_Have_The_Correct_Format_99999_hyphen_9999()
        {
            GivenAnAddressWithZipCodeWithInCorrectFormat();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(@"Zipcode is not in the correct format. For example ... 99999 or 99999-111.");
        }

        [TestMethod]
        public void ZipCode_Can_Have_Five_Digits()
        {
            GivenAnAddressWithZipCodeOfFiveDigits();
            WhenAddressIsValidated();
            ThenTheAddressIsValid();
        }

        [TestMethod]        
        public void State_Cannot_Be_Empty()
        {
            GivenAnAddressWithEmptyState();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(StateCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void State_Cannot_Be_Null()
        {
            GivenAnAddressWithStateAsNull();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(StateCannotBeEmptyOrNull);
        }

        [TestMethod]        
        public void AddressType_Cannot_Be_UnKnown()
        {
            GivenAnAddressWithUnKnownAddressType();
            WhenAddressIsValidated();
            ThenTheResultantErrorIs(@"AddressType cannot be UnKnown.");
        }

        [TestMethod]
        public void Address_Is_Valid()
        {
            WhenAddressIsValidated();
            ThenTheAddressIsValid();
        }

        private void GivenAnAddressWithZipCodeWithInCorrectFormat()
        {
            _address.Zipcode = @"0123456789";
        }

        private void GivenAnAddressWithUnKnownAddressType()
        {
            _address.AddressType = AddressType.UnKnown;
        }

        private void GivenAnAddressWithZipCodeMoreThanTenDigits()
        {
            _address.Zipcode = "01234-56789";
        }

        private void GivenAnAddressWithZipCodeOfFiveDigits()
        {
            _address.Zipcode = "01234";
        }

        private void ThenTheAddressIsValid()
        {
            Assert.IsTrue(_isValidAddress);
        }

        private void GivenAnAddressWithStateAsNull()
        {
            _address.State = null;
        }

        private void GivenAnAddressWithEmptyState()
        {
            _address.State = string.Empty;
        }

        private void GivenAnAddressWithZipCodeAsNull()
        {
            _address.Zipcode = null;
        }

        private void GivenAnAddressWithEmptyZipCode()
        {
            _address.Zipcode = string.Empty;
        }

        private void GivenAnAddressWithCityAsNull()
        {
            _address.City = null;
        }

        private void GivenAnAddressWithAddressLine1AsNull()
        {
            _address.AddressLine1 = null;
        }

        private void GivenAnAddressWithEmptyCity()
        {
            _address.City = string.Empty;
        }

        private void WhenAddressIsValidated()
        {
            _isValidAddress = _address.IsValid();
        }

        private void GivenAnAddressWithEmptyAddressLine1()
        {
            _address.AddressLine1 = string.Empty;
        }

        private void ThenTheResultantErrorIs(string someError)
        {
            Assert.IsFalse(_isValidAddress);
            Assert.AreEqual(someError, _address.Errors.First().ErrorMessage);
        }

        private IAddress _address;
        private bool _isValidAddress;
        private const string Addressline1CannotBeEmptyOrNull = @"AddressLine1 cannot be empty or null.";
        private const string CityCannotBeEmptyOrNull = @"City cannot be empty or null.";
        private const string ZipcodeCannotBeEmptyOrNull = @"Zipcode cannot be empty or null.";
        private const string StateCannotBeEmptyOrNull = @"State cannot be empty or null.";
    }
}