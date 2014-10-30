using System;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Data.Interfaces
{
    public interface IApplicationFormRepository
    {
        IApplicationForm CreateApplicationForm(IApplicationForm applicationForm);
        IApplicationForm GetApplicationForm(Guid applicationId);
        void SaveGeneralInformation(Guid id, IGeneralInformation generalInformation);
    }
}