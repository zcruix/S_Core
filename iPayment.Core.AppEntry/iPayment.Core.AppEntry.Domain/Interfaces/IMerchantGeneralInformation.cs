namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IMerchantGeneralInformation : IValidator
    {
        string DoingBusinessAsName { get; set; }
        string LegalBusinessName { get; set; }
        
        string ContactFirstName { get; set; }
        string ContactLastName { get; set; }

        bool IsMailingAddressSameAsBusinessAddress { get; set; }

        string BusinessEmail { get; set; }
        string BusinessWebsiteUrl { get; set; }
        string BusinessOperatingHours { get; set; }
        
        IFederalTaxId FederalTaxID { get; set; }
        
        int NumberOfLocations { get; set; }
        
        IPhone BusinessPhone { get; set; }
        IPhone BusinessFax { get; set; }
        IPhone CustomerServicePhone { get; set; }
                
        IAddress MailingAddress { get; set; }
        IAddress BusinessAddress { get; set; }

        IContinuousResidence ContinuousResidenceAtTheBusinessAddress { get; set; }
        bool IsDoingBusinessAsNameSameAsLegalBusinessName { get; set; }        
    }
}