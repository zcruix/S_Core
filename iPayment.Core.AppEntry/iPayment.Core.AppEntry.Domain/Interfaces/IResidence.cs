using iPayment.Core.AppEntry.Domain.Enums;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IResidence
    {
        IAddress Address { get; set; }
        IContinuousResidence ContinuousResidenceAtTheAddress { get; set; }
        ResidentialStatus Status { get; set; }        
    }
}