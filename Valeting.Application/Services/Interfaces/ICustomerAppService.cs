using Valeting.Application.Models.Response;
using Valeting.Domain.Core.Entities;
using Valeting.Shared.DomainObjects;

namespace Valeting.Application.Services.Interfaces
{
    public interface ICustomerAppService
    {
        Task<BaseResponse<GetCustomerResponse, BaseNotification>> GetByEmail(string email);
        Task<BaseResponse<GetCustomerResponse, BaseNotification>> Create(Customer book);
        Task<BaseResponse<GetCustomerResponse, BaseNotification>> Update(Customer book);
    }
}
