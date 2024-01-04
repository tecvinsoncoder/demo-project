namespace DemoProject.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> Add(Customer customer, CancellationToken cancellationToken);
        Task<Customer> Update(Customer customer, CancellationToken cancellationToken);
        Task<IEnumerable<Customer>> GetCustomers(int? page, int? pageSize, CancellationToken cancellationToken);
        Task<Customer> GetById(Guid id, CancellationToken cancellationToken);
        Task<int> Delete(Guid id, CancellationToken cancellationToken);
        Task<bool> Exist(Customer customer, CancellationToken cancellationToken);
        Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken = default);
    }
}