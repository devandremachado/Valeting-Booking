using Microsoft.AspNetCore.Mvc;
using Valeting.Application.Models.Request;
using Valeting.Application.Services.Interfaces;
using Valeting.Web.DTO.Request;

namespace Valeting.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IBookingAppService _bookingAppService;

        public HomeController(IBookingAppService bookingAppService)
        {
            _bookingAppService = bookingAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllBookings()
        {
            var response = await _bookingAppService.GetAll();
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> CreateBooking(CreateBookingRequestDto request)
        {
            if (!ModelState.IsValid)
                return Json(new { IsSucess = false }); // TODO

            var booking = request.ToEntity();

            var response = await _bookingAppService.Create(booking);
            return Json(response);
        }

        [HttpPatch]
        public async Task<JsonResult> ApproveBooking(ApproveBookingRequest request)
        {
            var response = await _bookingAppService.Approve(Guid.Parse(request.ExternalId));
            return Json(response);
        }

        [HttpDelete]
        public async Task<JsonResult> RemoveBooking(RemoveBookingRequest request)
        {
            await _bookingAppService.Remove(Guid.Parse(request.ExternalId));

            return Json(new object()); //TODO
        }
    }
}
