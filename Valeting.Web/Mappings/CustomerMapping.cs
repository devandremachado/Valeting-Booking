using Valeting.Domain.Core.Entities;
using Valeting.Web.DTO.Response;

namespace Valeting.Web.Mappings
{
    public static class CustomerMapping
    {
        public static CustomerResponseDto ToDto(Customer customer)
        {
            if (customer is null) return null;

            return new CustomerResponseDto
            {
                ExternalId = customer.ExternalId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
            };
        }

        public static Customer ToEntity(CustomerResponseDto request)
        {
            if (request is null) return null;

            return new Customer(request.Name, request.Email, request.Phone);
        }
    }
}
