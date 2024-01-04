using DemoProject.Domain.Primitives;

namespace DemoProject.Domain.Customers
{
    public class Customer : Entity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Phone { get; }
        public string Email { get; }

        private Customer(string firstName, string lastName, string phone, string email)
        {   
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

        public Customer(Guid id, string firstName, string lastName, string phone, string email) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

        public static Customer CreateCustomer(string firstName, string lastName, string phone, string email)
        {
            return new Customer(firstName, lastName, phone, email);
        }

        public static Customer UpdateCustomer(Guid id, string firstName, string lastName, string phone, string email)
        {
            return new Customer(id, firstName, lastName, phone, email);
        }
    }
}