using DemoProject.Domain.Customers;

namespace DemoProject.Application.Customers
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public static class CustomerExtension
    {
        public static CustomerDto ToDto(this Customer entity)
        {
            return new CustomerDto()
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Phone = entity.Phone
            };
        }

        public static List<CustomerDto> ToDto(this IEnumerable<Customer> entities)
        {
            List<CustomerDto> customerDtos = new();
            
            foreach (var entity in entities) 
            {
                customerDtos.Add(entity.ToDto());
            }   
            
            return customerDtos;
        }
    }
}
