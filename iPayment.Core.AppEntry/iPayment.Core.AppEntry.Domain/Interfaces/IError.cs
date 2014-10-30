using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IError
    {
        string FieldName { get; set; }
        ErrorSeverity ErrorSeverity { get; set; }
        string ErrorMessage { get; set; }               
    }
}