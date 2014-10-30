using System;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IDriverLicense
    {
        string Number { get; set; }
        string State { get; set; }
        DateTime IssuedDate { get; set; }
        DateTime ExpirationDate { get; set; }
    }
}