using System;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Service.Interfaces
{
    public interface IApplicationService
    {
        void SaveGeneralInformation(Guid applicationId, IGeneralInformation generalInfo);
        IGeneralInformation GetGeneralInformation(Guid applicationId);        
        IApplicationServiceContext Context { get; set; }
        IApplicationForm GetApplicationForm(Guid applicationId);
        IApplicationForm CreateApplicationForm(Guid applicationId);
    }
}