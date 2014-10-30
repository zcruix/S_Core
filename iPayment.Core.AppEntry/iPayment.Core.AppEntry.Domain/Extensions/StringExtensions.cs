namespace iPayment.Core.AppEntry.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string s)
        {
            double n;
            return double.TryParse(s, out n);
        }
    }
}