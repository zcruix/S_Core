using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class ContinuousResidence : IContinuousResidence
    {
        public int Years { get; set; }
        public int Months { get; set; }
    }
}