using System.ComponentModel;

namespace iPayment.Core.AppEntry.Data.Enums
{
    public enum TaxIdType
    {
        [Description("Social Security Number")]
        SSN,
        [Description("Employer Identification Number")]
        EIN,
        [Description("Individual Tax Identification Number")]
        ITIN,
        [Description("Preparer Taxpayer Identification Number")]
        PTIN,
        UnKnown
    }
}