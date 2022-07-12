using Valeting.Domain.Core.Entities;

namespace Valeting.Domain.Core.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> GetByExternalId(Guid id);
        Task<Booking> Create(Booking booking);
        Task<Booking> Update(Booking booking);
        Task Remove(Booking booking);
    }
}
