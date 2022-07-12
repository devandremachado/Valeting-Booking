using AutoMapper;
using Valeting.Application.Models.Response;
using Valeting.Domain.Core.Entities;

namespace Valeting.Application.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetCustomerResponse>();
            CreateMap<GetCustomerResponse, Customer>();
        }
    }
}
