using AutoMapper;
using Valeting.Application.Models.Response;
using Valeting.Domain.Core.Entities;

namespace Valeting.Application.Mapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, GetBookingResponse>()
                .ForMember(x => x.FlexibilityDescription, opt => opt.MapFrom(p => p.Flexibility.ToString()))
                .ForMember(x => x.VehicleSizeDescription, opt => opt.MapFrom(p => p.VehicleSize.ToString()))
                .ForMember(x => x.BookingDateFormat, opt => opt.MapFrom(p => p.BookingDate.ToString("MM/dd/yyyy")));

            CreateMap<GetBookingResponse, Booking>();
        }
    }
}
