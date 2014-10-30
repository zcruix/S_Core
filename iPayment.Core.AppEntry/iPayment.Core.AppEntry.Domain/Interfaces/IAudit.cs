using System;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IAudit
    {
        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }        
    }
}