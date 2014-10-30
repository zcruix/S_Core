namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IMarketingMethods
    {
        bool HasOptedDirectMail { get; set; }
        bool HasOptedInternet { get; set; }
        bool HasOptedMagazineorCatalog { get; set; }
        bool HasOptedNewsPaper { get; set; }
        bool HasOptedTVorRadio { get; set; }
        bool HasOptedYellowPages { get; set; }
    }
}