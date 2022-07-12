﻿using Microsoft.AspNetCore.Mvc;
using Valeting.Application.Services.Interfaces;

namespace Valeting.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
