using Valeting.Domain.Core.Entities;

namespace Valeting.Domain.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Create(Customer customer);
        Task<Customer> GetByEmail(string email);
        Task<Customer> Update(Customer customer);
    }
}
