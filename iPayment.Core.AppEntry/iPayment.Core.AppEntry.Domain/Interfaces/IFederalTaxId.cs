using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IFederalTaxId : IValidator
    {
        string Number { get; set; }
        TaxIdType TaxIdType { get; set; }    
    }
}