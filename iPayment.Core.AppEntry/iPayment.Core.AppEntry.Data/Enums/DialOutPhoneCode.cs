using System.ComponentModel.DataAnnotations;

namespace iPayment.Core.AppEntry.Data.Enums
{
    public enum DialOutPhoneCode
    {
        [Display(ShortName = "8")]
        Eight,

        [Display(ShortName = "9")]
        Nine,
        Other,
        None,
        UnKnown
    }
}