using System;
using System.Collections.Generic;
using System.Linq;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class ApplicationForm : ObjectBase, IApplicationForm
    {
        public ApplicationForm(List<IError> errorContext = null)
        {
            Errors = errorContext ?? new List<IError>();    
        }

        public Guid ApplicationId { get; set; }
        public IGeneralInformation GeneralInformation { get; set; }
        public IPrincipalInformation PrincipalInformation { get; set; }
        public IEquipmentInformation Equipment { get; set; }
        
        public bool IsValid()
        {
            return !Errors.Any();
        }

        public List<IError> Errors { get; set; }
    }
}