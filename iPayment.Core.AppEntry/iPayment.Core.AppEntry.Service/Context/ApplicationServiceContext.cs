using System;
using System.Collections.Generic;
using System.Linq;
using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Data.Repositories;
using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Service.Enums;
using iPayment.Core.AppEntry.Service.Interfaces;

namespace iPayment.Core.AppEntry.Service.Context
{
    public class ApplicationServiceContext : IApplicationServiceContext
    {
        public IApplicationFormRepository ApplicationFormRepository { get; set; }
        public IApplicationForm ApplicationForm { get; set; }
        public Status Status { get; set; }
        public Guid ApplicationId { get { return ApplicationForm.ApplicationId; } }

        public ApplicationServiceContext(IApplicationFormRepository repository = null, IApplicationForm applicationForm = null)
        {
            Errors = new List<IError>();
            ApplicationFormRepository = repository ?? new ApplicationFormRepository();
            ApplicationForm = applicationForm ?? new ApplicationForm(Errors);
            Errors = ApplicationForm.Errors;
        }

        public bool IsValid(IValidator validator)
        {
            if (validator.IsValid()) return true;
            Errors.AddRange(validator.Errors);
            return IsValid();
        }

        public bool IsValid()
        {         
            return !Errors.Any();
        }

        public List<IError> Errors { get; set; }
    }
}