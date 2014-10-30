using System.Collections.Generic;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IValidator
    {
        bool IsValid();
        List<IError> Errors { get; set; }        
    }
}