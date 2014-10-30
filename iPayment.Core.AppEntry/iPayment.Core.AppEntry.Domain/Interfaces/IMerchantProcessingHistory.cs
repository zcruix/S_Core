namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IMerchantProcessingHistory
    {
        bool HadAcceptedCreditCards { get; set; }
        bool HadMerchantAccountClosedByAProcessor { get; set; }                 
    }
}