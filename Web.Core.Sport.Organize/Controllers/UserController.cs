using Microsoft.AspNetCore.Mvc;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepositories _userRepositories;
        private readonly GlobalService _globalService;

        public UserController(IUserRepositories userRepositories, GlobalService globalService)
        {
            this._userRepositories = userRepositories;
            this._globalService = globalService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(_globalService.Token)) return RedirectToAction("Login", "Account");

            var model = _userRepositories.GetUser(_globalService.UserId, _globalService.Token);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(UserDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepositories.Update(userDTO);

                }

            }
            catch (System.Exception)
            {

                throw;
            }
            return View(userDTO);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (string.IsNullOrEmpty(_globalService.Token)) return RedirectToAction("Login", "Account");

            var model = new ChangePasswordDTO();
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepositories.ChangePassword(changePasswordDTO);
                    return RedirectToAction("Logout", "Account");
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                _userRepositories.Delete(_globalService.UserId);
                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
