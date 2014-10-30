using System;
using iPayment.Core.AppEntry.Data.Exceptions;
using iPayment.Core.AppEntry.Data.Mappers;
using iPayment.Core.AppEntry.Data.Model;
using iPayment.Core.AppEntry.Data.Store;
using iPayment.Core.AppEntry.Domain.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Data.Tests
{
    [TestClass]
    public class GeneralInformationDataTests
    {
        [TestMethod]
        public void can_add_general_information_to_the_data_store()
        {
            GivenAGeneralInformationSection();
            WhenGeneralInformationSectionIsAdded();
            ThenTheGeneralInformationIsSaved();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationFormNotFoundException))]
        public void cannot_add_general_information_to_the_data_store_due_to_invalid_applicationId()
        {
            GivenAGeneralInformationSection();
            WhenGeneralInformationSectionIsAddedWithInvalidApplicationId();            
        }

        [TestMethod]
        public void cannot_get_general_information_as_generalinformation_was_never_added()
        {
            GivenAnApplicationFormId(_applicationForm.ApplicationId);
            WhenGeneralInformationSectionIsRetrieved();
            ThenTheGeneralInformationIsNull();
        }

        [TestInitialize]
        public void Initialize()
        {
            _dataStore = new ApplicationFormDataStore();
            _applicationForm = _dataStore.CreateApplicationForm();
        }

        private void ThenTheGeneralInformationIsNull()
        {
            Assert.IsNull(_generalInfoData);
        }

        private void WhenGeneralInformationSectionIsRetrieved()
        {
            _generalInfoData = _dataStore.GetGeneralInformation(_applicationId);
        }

        private void GivenAnApplicationFormId(Guid applicationId)
        {
            _applicationId = applicationId;
        }

        private void WhenGeneralInformationSectionIsAddedWithInvalidApplicationId()
        {
            AddGeneralInformation(Guid.NewGuid());
        }

        private void ThenTheGeneralInformationIsSaved()
        {
            Assert.IsTrue(_result);
        }

        private void WhenGeneralInformationSectionIsAdded()
        {
            AddGeneralInformation(_applicationForm.ApplicationId);
        }

        private void AddGeneralInformation(Guid applicationId)
        {
            _result = _dataStore.AddOrUpdateGeneralInformation(applicationId, _generalInfoData);
        }

        private void GivenAGeneralInformationSection()
        {
            var generalInformation = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();
            _generalInfoData =  generalInformation.ConvertToGeneralInfoDataModel();
        }

        private ApplicationFormDataStore _dataStore;
        private ApplicationFormDataModel _applicationForm;
        private GeneralInformationDataModel _generalInfoData;
        private bool _result;
        private Guid _applicationId
            ;
    }
}