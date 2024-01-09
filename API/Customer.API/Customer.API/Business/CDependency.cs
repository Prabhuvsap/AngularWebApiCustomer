using Customer.API.Business.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Customer.API.Business
{
    public class CDependency : IDependency
    {
        public string CustomerAddress;

        public CDependency()
        {
            CustomerAddress = string.Empty;
        }

        public async Task<string> AddAddress(string id, string address)
        {
            // Add logic here
            return "";
        }

        public async Task<string> GetAddress(Guid id)
        {
            // Get logic here
            return "";
        }

        public async Task<string> UpdateAddress(string id, string address)
        {
            // Update logic here
            return "";
        }
    }


}
