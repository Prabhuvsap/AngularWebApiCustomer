
using Customer.API.Business.Interfaces;
using Customer.API.Data;
using System;

namespace Customer.API.Business
{
    public class CustomerService : ICustomerService
    {
        private CustomerDBContext customerData;
       // private readonly IDependency _dependency;
   
        public CustomerService()//IDependency dependency
        {
            customerData = new CustomerDBContext();
            //_dependency = new CDependency(dependency);
        }
        public async Task<IList<ICustomer>> GetCustomers()
        {
            IList<ICustomer> customers = await Task.Run(() => customerData.LoadCustomersData());
            return customers;
        }

        public async Task<ICustomer> AddCustomer(ICustomer customer)
        {
            var guidID = Guid.NewGuid();
            customer.Id = guidID.ToString();
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
            //await Task.Run(() => _dependency.AddAddress(Guid.Parse(customer.Id), customer.Address));
            return customer;
        }

        public async Task DeleteCustomer(Guid id)
        {
            await Task.Run(() => customerData.DeleteCustomerData(id));
        }
    }
}
