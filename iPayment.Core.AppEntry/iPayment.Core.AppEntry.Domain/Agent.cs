using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class Agent : IAgent
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string SalesNumber { get; set; }
        public string Id { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
