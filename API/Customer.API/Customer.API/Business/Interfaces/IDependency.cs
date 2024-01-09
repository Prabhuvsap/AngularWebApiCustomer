namespace Customer.API.Business.Interfaces
{
    public interface IDependency
    {
        Task<string> AddAddress(string id, string address);
        Task<string> GetAddress(Guid id);
        Task<string> UpdateAddress(string id, string address);
    }
}
