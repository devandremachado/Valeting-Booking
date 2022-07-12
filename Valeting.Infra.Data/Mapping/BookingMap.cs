using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Valeting.Domain.Core.Entities;

namespace Valeting.Infra.Data.Mapping
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(c => c.ExternalId);

            builder.Property(c => c.BookingDate).IsRequired();
            builder.Property(c => c.Flexibility).IsRequired();
            builder.Property(c => c.VehicleSize).IsRequired();

            builder.HasOne(c => c.Customer);

            builder.ToTable("Bookings");
        }
    }
}
