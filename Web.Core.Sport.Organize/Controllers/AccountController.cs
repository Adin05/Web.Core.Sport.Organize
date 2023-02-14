using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountRepositories _accountRepositories;
        private readonly GlobalService _globalService;

        public AccountController(IAccountRepositories accountRepositories, GlobalService globalService) : base(globalService)
        {
            this._accountRepositories = accountRepositories;
            this._globalService = globalService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginDTO();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountRepositories.Login(loginDTO.Email, loginDTO.Password);

                if (response == null) return View();

                _globalService.Token = response.Token;
                _globalService.UserId = response.ID;

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountRepositories.Register(registerDTO);

                if (response == null) return View();


                return RedirectToAction("Login");
            }
            return View(registerDTO);
        }

        [HttpGet]
        public IActionResult GetLoginStatus()
        {
            bool isLoggedIn = false;
            if (!string.IsNullOrEmpty(_globalService.Token)) isLoggedIn = true;
            return Json(isLoggedIn);
        }

        public IActionResult Logout()
        {
            _globalService.Token = null;
            _globalService.UserId = 0;
            return RedirectToAction("Index", "Home");

        }
    }
}
