using System.Collections.Generic;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IPrincipalInformation
    {
        List<IPrincipal> Principals { get; set; }         
    }
}