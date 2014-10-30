namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IMerchantApplicationFormTemplate
    {
        string Description { get; set; }
        string Id { get; set; }
        string Version { get; set; }        
    }
}