using iPayment.Core.AppEntry.DTO.Enums;

namespace iPayment.Core.AppEntry.DTO.Templates
{
    public class FederalTaxId 
    {        
        public string Number { get; set; }
        public TaxIdType TaxIdType { get; set; }         
    }
}