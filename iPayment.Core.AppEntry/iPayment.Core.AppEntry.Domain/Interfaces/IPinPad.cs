using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IPinPad
    {
        string Model { get; set; }
        PinPadCable PinPadCable { get; set; }
        bool ShouldDeployPinPad { get; set; }
        bool ShouldDeployPinPadCable { get; set; }
    }
}