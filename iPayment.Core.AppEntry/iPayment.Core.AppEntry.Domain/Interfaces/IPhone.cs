using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IPhone : IValidator
    {
        string Number { get; set; }
        PhoneType PhoneType { get; set; }        
    }
}