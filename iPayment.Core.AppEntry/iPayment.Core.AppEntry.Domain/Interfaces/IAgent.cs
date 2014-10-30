namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IAgent
    {
        string UserName { get; set; }
        string Password { get; set; }
        string DisplayName { get; set; }
        string SalesNumber { get; set; }
        string Id { get; set; }
        bool IsAuthenticated { get; set; }
    }
}