
using Customer.API.Business.Interfaces;
using Customer.API.Data;

namespace Customer.API.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerService _customerService;
        private CustomerDBContext customerData;
        public CustomerService(ICustomerService customerService) {
            _customerService = customerService;
        }

        public CustomerService()
        {
            customerData = new CustomerDBContext();
        }
        public async Task<IList<ICustomer>> GetCustomers()
        {
            IList<ICustomer> customers = await Task.Run(() => customerData.LoadCustomersData());
            return customers;
        }

        public async Task<ICustomer> AddCustomer(ICustomer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            customer.FirstName = customer.FirstName;
            customer.LastName = customer.LastName;
            customer.Email = customer.Email;
            customer.CreatedDateTime = DateTime.Now;
            customer.UpdatedDateTime = DateTime.Now;
            await Task.Run(() => customerData.AddCustomerData(customer));
            return customer;
        }

        public async Task<ICustomer> GetCustomer(Guid id)
        {
            ICustomer customer = await Task.Run(() => customerData.GetCustomerData(id));
            return customer;
        }

        public async Task<ICustomer> UpdateCustomer(ICustomer customer)
        {
            customer.UpdatedDateTime = DateTime.Now;
            await Task.Run(() => customerData.UpdateCustomerData(customer));
            return customer;
        }

        public async Task DeleteCustomer(Guid id)
        {
            await Task.Run(() => customerData.DeleteCustomerData(id));
        }
    }
}
