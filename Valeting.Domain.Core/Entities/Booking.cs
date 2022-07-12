using Valeting.Domain.Core.Enums;
using Valeting.Shared.CustomException;
using Valeting.Shared.DomainObjects;

namespace Valeting.Domain.Core.Entities
{
    public class Booking : Entity
    {
        protected Booking()
        { }

        public Booking(Customer customer, DateTime bookingDate, BookingFlexibilityEnum flexibility, VehicleSizeEnum vehicleSize)
        {
            Customer = customer;
            BookingDate = bookingDate;
            Flexibility = flexibility;
            VehicleSize = vehicleSize;
            IsApproved = false;
        }

        public Customer Customer { get; private set; }

        public DateTime BookingDate { get; private set; }

        public BookingFlexibilityEnum Flexibility { get; private set; }

        public VehicleSizeEnum VehicleSize { get; private set; }

        public bool IsApproved { get; private set; }

        public void SetCustomer(Customer customer)
        {
            if (Customer is null)
                throw new DomainException("Custommer cannot be null");

            Customer = customer;
        }

        public void Approve()
        {
            IsApproved = true;
        }

    }
}
