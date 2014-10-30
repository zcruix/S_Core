using System;
using System.Collections.Generic;
using System.Linq;
using iPayment.Core.AppEntry.Data.Exceptions;
using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Interfaces;
using IApplicationForm = iPayment.Core.AppEntry.Domain.Interfaces.IApplicationForm;

namespace iPayment.Core.AppEntry.Data.Repositories
{
    public class MockApplicationFormRepository : IApplicationFormRepository
    {
        private readonly List<IApplicationForm> _applicationForms;

        public MockApplicationFormRepository() : this(null){}

        private MockApplicationFormRepository(List<IApplicationForm> merchantApplicationForms = null)
        {
            _applicationForms = merchantApplicationForms ?? new List<IApplicationForm>();
        }

        public IApplicationForm GetApplicationForm(Guid id)
        {
            return _applicationForms.Find(x => x.ApplicationId == id);
        }

        public void SaveGeneralInformation(Guid id, IGeneralInformation generalInformation)
        {
            var applicationForm = GetApplicationForm(id);
            if (applicationForm == null)
                throw new ApplicationFormNotFoundException();
                        
            applicationForm.GeneralInformation = generalInformation;
        }

        public IApplicationForm CreateApplicationForm(IApplicationForm applicationForm = null)
        {
            var newApplicationForm = (applicationForm ?? new ApplicationForm { ApplicationId = Guid.NewGuid() });
            _applicationForms.Add(newApplicationForm);
            return newApplicationForm;
        }

        public void UpdateApplicationForm(Guid applicationId, IApplicationForm applicationForm)
        {
            if (_applicationForms.All(x => x.ApplicationId == applicationId))
            {
                _applicationForms.Add(GetApplicationForm(applicationId));
            }

            if (_applicationForms.All(x => x.ApplicationId != applicationId))
            {
                _applicationForms.Add(applicationForm);
            }
        }
    }
}