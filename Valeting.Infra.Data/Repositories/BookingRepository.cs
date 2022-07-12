using Microsoft.EntityFrameworkCore;
using Valeting.Domain.Core.Entities;
using Valeting.Domain.Core.Repositories;
using Valeting.Infra.Data.Context;

namespace Valeting.Infra.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<Booking> Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task Remove(Booking booking)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _context.Bookings
                .Include(x => x.Customer)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Booking> GetByExternalId(Guid id)
        {
            return await _context.Bookings
                .Include(x => x.Customer)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ExternalId == id);
        }

        public async Task<Booking> Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
