using DemoProject.Shared;

namespace DemoProject.Domain.Customers
{
    public class CustomerErrors
    {
        public static readonly Error CustomerExist = new ("Customer.CustomerExist", "Customer already exist");
        public static readonly Error CustomerNotFound = new("Customer.CustomerNotFound", "Customer does not exist");
    }
}