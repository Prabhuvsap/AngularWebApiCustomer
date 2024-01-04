using Customer.API.Business.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Customer.API.Models
{
    public class CustomerModel : ICustomer
    {
        [Required]
        public string Id { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public string Email { get ; set ; }
        public DateTime CreatedDateTime { get ; set ; }
        public DateTime UpdatedDateTime { get ; set ; }

    }
}
