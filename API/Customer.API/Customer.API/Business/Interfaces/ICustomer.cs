namespace Customer.API.Business.Interfaces
{
    public interface ICustomer
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        DateTime CreatedDateTime { get; set; }
        DateTime UpdatedDateTime { get; set; }

    }
}
