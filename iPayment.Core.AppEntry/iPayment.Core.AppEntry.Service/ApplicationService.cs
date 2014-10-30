using System;
using iPayment.Core.AppEntry.Data.Exceptions;
using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Service.Context;
using iPayment.Core.AppEntry.Service.Extensions;
using iPayment.Core.AppEntry.Service.Interfaces;

namespace iPayment.Core.AppEntry.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationFormRepository _repository;        
        public IApplicationServiceContext Context { get; set; }

        public ApplicationService(IApplicationServiceContext applicationServiceContext = null)
        {
            Context = applicationServiceContext ?? new ApplicationServiceContext();            
            _repository = Context.ApplicationFormRepository;            
        }

        public IApplicationForm GetApplicationForm(Guid applicationId)
        {
            var applicationForm = _repository.GetApplicationForm(applicationId);
            if (applicationForm != null) return applicationForm;

            throw new ApplicationFormNotFoundException();
        }

        public IApplicationForm CreateApplicationForm(Guid applicationId)
        {
            return _repository.CreateApplicationForm(new ApplicationForm {ApplicationId = applicationId});
        }

        public IGeneralInformation GetGeneralInformation(Guid applicationId)
        {
            var merchantApplicationForm = GetApplicationForm(Context.ApplicationId);
            return merchantApplicationForm.GeneralInformation;
        }

        public void SaveGeneralInformation(Guid applicationId, IGeneralInformation generalInfo)
        {
            if (!Context.IsValid(generalInfo)) return;

            var generalInfoFromRepository = GetGeneralInformation(applicationId);
            Context.InvokeSave(() => _repository.SaveGeneralInformation(Context.ApplicationId, generalInfo),
                generalInfoFromRepository.OperationStatus());
        }
    }
}