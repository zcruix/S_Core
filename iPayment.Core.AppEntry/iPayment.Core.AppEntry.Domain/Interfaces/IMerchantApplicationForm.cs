namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IMerchantApplicationForm :IValidator
    {
        string MerchantID { get; set; }
        IMerchantGeneralInformation MerchantGeneralInformation { get; set; }
        IEquipmentInformation Equipment { get; set; }
        IPrincipalInformation PrincipalInformation { get; set; }
    }
}