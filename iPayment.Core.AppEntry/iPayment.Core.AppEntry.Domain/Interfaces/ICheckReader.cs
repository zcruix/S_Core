using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface ICheckReader
    {
        CheckReaderModel CheckReaderModel { get; set; }
        bool ShouldDeployCheckreader { get; set; }
    }
}