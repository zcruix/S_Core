
using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface ITerminal
    {
        string Brand { get; set; }
        Condition Condition { get; set; }
        string Model { get; set; }
        IPrinter Printer { get; set; }
        IPinPad PinPad { get; set; }
        ICheckReader CheckReader { get; set; }
        ICardReader CardReader { get; set; }
        bool CanTerminalAutoClose { get; set; }
        WirelessBand WirelessBand { get; set; }
        DialOutPhoneCode DialOutPhoneCode { get; set; }
        Processor Processor { get; set; }
        string Notes { get; set; }
    }
}