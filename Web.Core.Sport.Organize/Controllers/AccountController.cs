using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.WindowsRuntime;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;

namespace Web.Core.Sport.Organize.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepositories _accountRepositories;

        public AccountController(IAccountRepositories accountRepositories)
        {
            this._accountRepositories = accountRepositories;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginDTO();
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var response = _accountRepositories.Login(loginDTO.Email,loginDTO.Password);
                return RedirectToAction("Index","Home");
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
        public IActionResult Register(RegisterDTO registerDTO)
        {
            if(ModelState.IsValid)
            {
                var model = new RegisterDTO();
                _accountRepositories.Register(model);
            }
            return View(registerDTO);
        }
    }
}
