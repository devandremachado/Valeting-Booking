using AutoMapper;
using Valeting.Application.Models.Response;
using Valeting.Application.Services.Interfaces;
using Valeting.Domain.Core.Entities;
using Valeting.Domain.Core.Repositories;
using Valeting.Shared.DomainObjects;

namespace Valeting.Application.Services
{
    public class BookingAppService : IBookingAppService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAppService _customerAppService;
        private readonly IMapper _mapper;

        public BookingAppService(IBookingRepository bookingRepository,
                                ICustomerRepository customerRepository,
                                ICustomerAppService customerAppService,
                                IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
            _customerAppService = customerAppService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetBookingResponse>, BaseNotification>> GetAll()
        {
            var bookings = await _bookingRepository.GetAll();

            return _mapper.Map<IEnumerable<GetBookingResponse>>(bookings).ToList();
        }

        public async Task<BaseResponse<GetBookingResponse, BaseNotification>> Create(Booking booking)
        {
            var customerDb = await _customerRepository.GetByEmail(booking.Customer.Email);

            customerDb.Update(booking.Customer.Name, booking.Customer.Phone);
            booking.SetCustomer(customerDb);

            await _customerAppService.Update(customerDb);

            var response = await _bookingRepository.Create(booking);
            return _mapper.Map<GetBookingResponse>(response);
        }

        public async Task Remove(Guid externalId)
        {
            var booking = await _bookingRepository.GetByExternalId(externalId);

            if (booking is not null)
                await _bookingRepository.Remove(booking);
        }

        public async Task<BaseResponse<GetBookingResponse, BaseNotification>> Update(Booking booking)
        {
            var response = await _bookingRepository.Update(booking);
            return _mapper.Map<GetBookingResponse>(response);
        }

        public async Task<BaseResponse<GetBookingResponse, BaseNotification>> Approve(Guid externalId)
        {
            var booking = await _bookingRepository.GetByExternalId(externalId);

            if (booking is null) return null;

            booking.Approve();

            //TODO => send email to customer

            var response = await _bookingRepository.Update(booking);
            return _mapper.Map<GetBookingResponse>(response);
        }

    }
}
