using AutoMapper;
using Valeting.Application.Models.Response;
using Valeting.Application.Services.Interfaces;
using Valeting.Domain.Core.Entities;
using Valeting.Domain.Core.Repositories;
using Valeting.Shared.DomainObjects;

namespace Valeting.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetCustomerResponse, BaseNotification>> Create(Customer customer)
        {
            var response = await _customerRepository.Create(customer);
            return _mapper.Map<GetCustomerResponse>(response);
        }

        public async Task<BaseResponse<GetCustomerResponse, BaseNotification>> GetByEmail(string email)
        {
            var response = await _customerRepository.GetByEmail(email);
            return _mapper.Map<GetCustomerResponse>(response);
        }

        public async Task<BaseResponse<GetCustomerResponse, BaseNotification>> Update(Customer customer)
        {
            var response = await _customerRepository.Update(customer);
            return _mapper.Map<GetCustomerResponse>(response);
        }
    }
}
