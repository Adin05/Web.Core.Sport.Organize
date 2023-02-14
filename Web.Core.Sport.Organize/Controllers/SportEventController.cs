using Microsoft.AspNetCore.Mvc;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Controllers
{
    public class SportEventController : BaseController
    {
        private readonly GlobalService _globalService;
        private readonly ISportEventRepositories _sportEventRepositories;

        public SportEventController(GlobalService globalService, ISportEventRepositories sportEventRepositories) : base(globalService)
        {
            this._globalService = globalService;
            this._sportEventRepositories = sportEventRepositories;
        }

        public IActionResult Index(int page = 1, int perPage = 10)
        {
            if (string.IsNullOrEmpty(_globalService.Token)) return RedirectToAction("Login", "Account");

            var model = _sportEventRepositories.GetSportEvent(page, perPage);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SportEventDTO();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(SportEventDTO sportEventDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _sportEventRepositories.Create(sportEventDTO);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _sportEventRepositories.GetSportEvent(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(SportEventDTO SportEventDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _sportEventRepositories.Update(SportEventDTO);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _sportEventRepositories.Delete(id);
                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
