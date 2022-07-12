using Valeting.Application.Models.Response;
using Valeting.Domain.Core.Entities;
using Valeting.Shared.DomainObjects;

namespace Valeting.Application.Services.Interfaces
{
    public interface IBookingAppService
    {
        Task<BaseResponse<IEnumerable<GetBookingResponse>, BaseNotification>> GetAll();

        Task<BaseResponse<GetBookingResponse, BaseNotification>> Create(Booking book);

        Task<BaseResponse<GetBookingResponse, BaseNotification>> Update(Booking book);

        Task Remove(Guid externalId);

        Task<BaseResponse<GetBookingResponse, BaseNotification>> Approve(Guid externalId);
    }
}
