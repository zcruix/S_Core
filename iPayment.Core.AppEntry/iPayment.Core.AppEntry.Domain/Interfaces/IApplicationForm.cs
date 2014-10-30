using System;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IApplicationForm : IAudit, IValidator
    {
        Guid ApplicationId { get; set; }
        IGeneralInformation GeneralInformation { get; set; }
        IEquipmentInformation Equipment { get; set; }
        IPrincipalInformation PrincipalInformation { get; set; }
    }
}