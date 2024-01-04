namespace Customer.API.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IList<ICustomer>> GetCustomers();
        Task<ICustomer> AddCustomer(ICustomer customer);
        Task<ICustomer> GetCustomer(Guid id);
        Task<ICustomer> UpdateCustomer(ICustomer customer);
        Task DeleteCustomer(Guid id);
    }
}
