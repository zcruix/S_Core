using System.Collections.Generic;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface ITerminalInformation
    {
        List<ITerminal> Terminals { get; set; }
    }
}