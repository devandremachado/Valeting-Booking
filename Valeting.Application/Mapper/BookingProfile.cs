using AutoMapper;
using Valeting.Application.Models.Response;
using Valeting.Domain.Core.Entities;

namespace Valeting.Application.Mapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, GetBookingResponse>();
            CreateMap<GetBookingResponse, Booking>();
        }
    }
}
