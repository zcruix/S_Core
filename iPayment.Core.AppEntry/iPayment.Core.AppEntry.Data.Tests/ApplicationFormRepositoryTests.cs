using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Data.Model;
using iPayment.Core.AppEntry.Data.Repositories;
using iPayment.Core.AppEntry.Data.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iPayment.Core.AppEntry.Data.Tests
{
    [TestClass]
    public class ApplicationFormRepositoryTests
    {
        [TestMethod]
        public void can_create_applicationFormRepository_with_applicationFormDataStore()
        {
            GivenAnApplicationFormDataStore();
            WhenApplicationFormRepositoryIsInstantiated(_dataStore);
            ThenTheApplicationFormRepositoryIsNotNull();
        }

        [TestMethod]
        public void can_create_application_form()
        {
            GivenAnApplicationFormDataStore();
            WhenCreateApplicationFormIsCalled();
            ThenTheApplicationFormIsCreated();
        }

        private void ThenTheApplicationFormIsCreated()
        {
            Assert.IsNotNull(_applicationForm);
        }

        private void WhenCreateApplicationFormIsCalled()
        {
            _applicationForm = _dataStore.CreateApplicationForm();
        }

        private void ThenTheApplicationFormRepositoryIsNotNull()
        {
            Assert.IsNotNull(_repository);
        }

        private void WhenApplicationFormRepositoryIsInstantiated(IApplicationFormDataStore dataStore)
        {
            _repository = new ApplicationFormRepository(dataStore);
        }

        private void GivenAnApplicationFormDataStore()
        {
            _dataStore = new ApplicationFormDataStore();
        }

        private IApplicationFormRepository _repository;
        private IApplicationFormDataStore _dataStore;
        private ApplicationFormDataModel _applicationForm;
    }
}
