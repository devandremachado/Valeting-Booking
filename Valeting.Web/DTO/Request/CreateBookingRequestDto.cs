using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Valeting.Domain.Core.Entities;
using Valeting.Domain.Core.Enums;

namespace Valeting.Web.DTO.Request
{
    public class CreateBookingRequestDto
    {
        [Required]
        public CreateCustomerRequestDto Customer { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public BookingFlexibilityEnum Flexibility { get; set; }

        [Required]
        public VehicleSizeEnum VehicleSize { get; set; }

        public Booking ToEntity()
        {
            var customer = new Customer(Customer.Name, Customer.Email, Customer.Phone);
            return new Booking(customer, BookingDate, Flexibility, VehicleSize);
        }
    }
}
