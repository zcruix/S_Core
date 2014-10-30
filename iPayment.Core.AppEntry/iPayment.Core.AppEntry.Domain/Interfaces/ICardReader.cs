using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface ICardReader
    {
        CardReaderModel CardReaderModel { get; set; }
        bool ShouldDeployCardReader { get; set; }
    }
}