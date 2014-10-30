using System.Collections.Generic;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class BusinessInformation : IBusinessInformation
    {
        public Ownership Ownership { get; set; }
        public MerchantType MerchantType { get; set; }
        public BusinessLocation BusinessLocation { get; set; }
        public IBusinessCategory BusinessCategory { get; set; }
        public IMarketingMethods MarketingMethods { get; set; }
        public int B2BPercent { get; set; }
        public int B2CPercent { get; set; }
        public ProductOrServiceFulfillmentSource ProductOrServiceFulfillmentSource { get; set; }
        public List<string> ProductsOrServicesSold { get; set; }
        public MasterCardVisaTransactionSettlementDateOption MasterCardVisaTransactionSettlementDateOption { get; set; }
        public CustomerReturnPolicy CustomerReturnPolicy { get; set; }
        public int NumberOfDaysToProductOrServiceDelivery { get; set; }
        public IMerchantProcessingHistory MerchantProcessingHistory { get; set; }
    }
}