using Microsoft.EntityFrameworkCore;
using Valeting.Domain.Core.Entities;
using Valeting.Domain.Core.Repositories;
using Valeting.Infra.Data.Context;

namespace Valeting.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookingContext _context;

        public CustomerRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
