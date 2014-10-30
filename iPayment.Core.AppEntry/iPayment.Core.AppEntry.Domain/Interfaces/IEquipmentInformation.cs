namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IEquipmentInformation
    {
        ITerminalInformation TerminalInformation { get; set; }
        IGatewayInformation GatewayInformation { get; set; }
        ISoftwareInformation SoftwareInformation { get; set; }
        bool IsEquipmentLeased { get; set; }
        IEquipmentLeaseInformation EquipmentLeaseInformation { get; set; }
    }
}