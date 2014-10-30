using System;
using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Data.Store;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Data.Repositories
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly IApplicationFormDataStore _dataStore;

        public ApplicationFormRepository(IApplicationFormDataStore dataStore = null)
        {
            _dataStore = dataStore ?? new ApplicationFormDataStore();
        }

        public IApplicationForm CreateApplicationForm(IApplicationForm applicationForm)
        {
            throw new NotImplementedException();
        }

        public IApplicationForm GetApplicationForm(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveGeneralInformation(Guid id, IGeneralInformation generalInformation)
        {
            throw new NotImplementedException();
        }
    }
}