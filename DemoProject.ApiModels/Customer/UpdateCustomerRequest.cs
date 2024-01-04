namespace DemoProject.ApiModels.Customer
{
    public class UpdateCustomerRequest : CustomerModel
    {
        public Guid CustomerId { get; set; }
    }
}
