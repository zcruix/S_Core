using System.Linq;
using iPayment.Core.AppEntry.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Domain.Tests
{
    public class MerchantGeneralInformationTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            MerchantGeneralInformation = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();
        }

        protected void WhenMerchantGeneralInformationIsValidated()
        {
            IsValidMerchantGeneralInformation = MerchantGeneralInformation.IsValid();
        }


        protected IMerchantGeneralInformation MerchantGeneralInformation;
        protected bool IsValidMerchantGeneralInformation;

        protected void ThenMerchantGeneralInformationIsValid()
        {
            Assert.IsTrue(IsValidMerchantGeneralInformation);
        }

        protected void ThenTheResultantErrorShouldBe(string someError)
        {
            Assert.IsFalse(IsValidMerchantGeneralInformation);
            Assert.AreEqual(someError, MerchantGeneralInformation.ErrorContext.First().ErrorMessage);
        }
    }
}