using System.Linq;
using iPayment.Core.AppEntry.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    public class GeneralInformationTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            GeneralInformation = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();
        }

        protected void WhenMerchantGeneralInformationIsValidated()
        {
            IsValidMerchantGeneralInformation = GeneralInformation.IsValid();
        }


        protected IGeneralInformation GeneralInformation;
        protected bool IsValidMerchantGeneralInformation;

        protected void ThenMerchantGeneralInformationIsValid()
        {
            Assert.IsTrue(IsValidMerchantGeneralInformation);
        }

        protected void ThenTheResultantErrorShouldBe(string someError)
        {
            Assert.IsFalse(IsValidMerchantGeneralInformation);
            Assert.AreEqual(someError, GeneralInformation.Errors.First().ErrorMessage);
        }
    }
}