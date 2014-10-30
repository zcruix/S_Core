using iPayment.Core.AppEntry.DTO.Enums;

namespace iPayment.Core.AppEntry.DTO
{
    public class ErrorDto
    {
        public string FieldName { get; set; }
        public ErrorSeverity ErrorSeverity { get; set; }
        public string ErrorMessage { get; set; }
        public object FieldValue { get; set; }
        public object State { get; set; }
    }
}
