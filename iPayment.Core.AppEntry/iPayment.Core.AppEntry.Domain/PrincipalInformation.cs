using System.Collections.Generic;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class PrincipalInformation : IPrincipalInformation
    {
        public List<IPrincipal> Principals { get; set; }
    }
}