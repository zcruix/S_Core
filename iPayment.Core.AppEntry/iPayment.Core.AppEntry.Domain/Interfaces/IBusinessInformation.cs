using System.Collections.Generic;
using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IBusinessInformation
    {
        Ownership Ownership { get; set; }
        MerchantType MerchantType { get; set; }
        BusinessLocation BusinessLocation { get; set; }
        IBusinessCategory BusinessCategory { get; set; } 
        IMarketingMethods MarketingMethods { get; set; }
        int B2BPercent { get; set; }
        int B2CPercent { get; set; }
        ProductOrServiceFulfillmentSource ProductOrServiceFulfillmentSource { get; set; }
        List<string> ProductsOrServicesSold { get; set; }
        MasterCardVisaTransactionSettlementDateOption MasterCardVisaTransactionSettlementDateOption { get; set; }
        CustomerReturnPolicy CustomerReturnPolicy { get; set; }
        int NumberOfDaysToProductOrServiceDelivery { get; set; }
        IMerchantProcessingHistory MerchantProcessingHistory { get; set; }
    }
}