using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class Error : IError
    {
        public string FieldName { get; set; }
        public ErrorSeverity ErrorSeverity { get; set; }
        public string ErrorMessage { get; set; }
        public object FieldValue { get; set; }
        public object State { get; set; }
    }
}