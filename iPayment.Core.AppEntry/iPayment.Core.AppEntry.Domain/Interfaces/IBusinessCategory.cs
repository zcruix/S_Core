namespace iPayment.Core.AppEntry.Domain.Interfaces
{

    public interface IBusinessCategory
    {
        bool IsiPaymentMerchant { get; set; }
        bool IsPCSMerchant { get; set; }
        bool IsNBSMerchant { get; set; }
        bool IsPIRQMerchant { get; set; }        
    }
    
}