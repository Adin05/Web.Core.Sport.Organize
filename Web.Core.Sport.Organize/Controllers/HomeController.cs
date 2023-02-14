using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Models;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GlobalService _globalService;

        public HomeController(ILogger<HomeController> logger, GlobalService globalService)
        {
            _logger = logger;
            this._globalService = globalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CheckIsSuccess()
        {
            bool isSuccess = false;
            if (_globalService.IsSuccess) isSuccess = true;
            return Json(isSuccess);
        }
    }
}
