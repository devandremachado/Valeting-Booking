using Valeting.Domain.Core.Enums;

namespace Valeting.Application.Models.Response
{
    public class GetBookingResponse
    {
        public Guid ExternalId { get; set; }

        public GetCustomerResponse Customer { get; set; }

        public DateTime BookingDate { get; set; }
        public string BookingDateFormat { get; set; }

        public BookingFlexibilityEnum Flexibility { get; set; }
        public string FlexibilityDescription { get; set; }

        public VehicleSizeEnum VehicleSize { get; set; }
        public string VehicleSizeDescription { get; set; }

        public bool IsApproved { get; set; }
    }
}
