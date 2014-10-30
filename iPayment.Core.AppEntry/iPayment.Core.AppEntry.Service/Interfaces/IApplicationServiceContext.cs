using System;
using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Service.Enums;

namespace iPayment.Core.AppEntry.Service.Interfaces
{
    public interface IApplicationServiceContext : IValidator
    {
        Guid ApplicationId { get; }
        IApplicationFormRepository ApplicationFormRepository { get; set; }
        IApplicationForm ApplicationForm { get; set; }        
        Status Status { get; set; }
        bool IsValid(IValidator validator);
    }
}