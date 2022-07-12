using Microsoft.AspNetCore.Mvc;

namespace Valeting.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarBooking : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
