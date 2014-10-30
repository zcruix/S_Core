using System;
using iPayment.Core.AppEntry.Data.Mappers;
using iPayment.Core.AppEntry.Data.Model;
using iPayment.Core.AppEntry.Data.Store;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Data.Tests
{
    [TestClass]
    public class GeneralInformationManipulationTests
    {
        [TestMethod]
        public void can_update_general_information_in_the_data_store()
        {
            GivenAnUpdatedGeneralInformationSection();
            WhenGeneralInformationSectionIsUpdated();
            ThenTheGeneralInformationIsSameAsInitialized(true);
        }

        [TestMethod]
        public void can_get_general_information_in_the_data_store()
        {
            GivenAnApplicationFormId(_applicationId);
            WhenGeneralInformationSectionIsRetrieved();
            ThenTheGeneralInformationIsSameAsInitialized(false);
        }
        
        [TestMethod]
        public void can_remove_general_information_in_the_data_store()
        {
            GivenAnApplicationFormId(_applicationId);
            WhenGeneralInformationSectionIsRemoved();
            ThenTheGeneralInformationShouldBeNull();
        }

        [TestInitialize]
        public void Initialize()
        {
            _dataStore = new ApplicationFormDataStore();
            _applicationForm = _dataStore.CreateApplicationForm();
            _applicationId = _applicationForm.ApplicationId;
            _generalInformation = MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();
            _generalInfoData = _generalInformation.ConvertToGeneralInfoDataModel();
            _dataStore.AddOrUpdateGeneralInformation(_applicationForm.ApplicationId, _generalInfoData);
        }

        [TestCleanup]
        public void Cleanup()
        {
            WhenGeneralInformationSectionIsRetrieved();
            if(_returnedGeneralInfoData != null)
                WhenGeneralInformationSectionIsRemoved();
        }

        private void WhenGeneralInformationSectionIsRetrieved()
        {
            _returnedGeneralInfoData = _dataStore.GetGeneralInformation(_applicationId);
        }

        private void ThenTheGeneralInformationShouldBeNull()
        {
            _generalInfoData = _dataStore.GetGeneralInformation(_applicationId);
            Assert.IsNull(_generalInfoData);
        }

        private void WhenGeneralInformationSectionIsRemoved()
        {
            _dataStore.RemoveGeneralInformation(_applicationForm.ApplicationId);
        }

        private void ThenTheGeneralInformationIsSameAsInitialized(bool update)
        {
            _returnedGeneralInfoData = _dataStore.GetGeneralInformation(_applicationForm.ApplicationId);
            Assert.IsNotNull(_returnedGeneralInfoData);
            Assert.AreEqual(update, _updateResult);
            Assert.AreEqual(_generalInfoData, _returnedGeneralInfoData);
        }

        private void WhenGeneralInformationSectionIsUpdated()
        {
            _updateResult =_dataStore.AddOrUpdateGeneralInformation(_applicationForm.ApplicationId, _generalInfoData);
        }

        private void GivenAnUpdatedGeneralInformationSection()
        {
            _generalInfoData.ContactFirstName = UpdatedFirstName;
            _generalInfoData.ContactLastName = UpdatedLastName;
        }

        private void GivenAnApplicationFormId(Guid applicationId)
        {
            _applicationId = applicationId;
        }

        private ApplicationFormDataStore _dataStore;
        private ApplicationFormDataModel _applicationForm;
        private IGeneralInformation _generalInformation;
        private GeneralInformationDataModel _generalInfoData;
        private Guid _applicationId;
        private GeneralInformationDataModel _returnedGeneralInfoData;
        private bool _updateResult;
        private const string UpdatedFirstName = "Updated First Name";
        private const string UpdatedLastName = "Updated Last Name";
    }
}
