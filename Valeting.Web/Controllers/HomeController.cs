using Microsoft.AspNetCore.Mvc;
using Valeting.Application.Services.Interfaces;
using Valeting.Web.DTO.Request;

namespace Valeting.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookingAppService _bookingAppService;
        private readonly ICustomerAppService _customerAppService;

        public HomeController(IBookingAppService bookingAppService, ICustomerAppService customerAppService)
        {
            _bookingAppService = bookingAppService;
            _customerAppService = customerAppService;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public async Task<JsonResult> GetCustomerByEmail(string email)
        {
            var customer = await _customerAppService.GetByEmail(email);
            return Json(customer);
        }
    }
}