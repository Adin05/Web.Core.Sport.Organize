using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Controllers
{
    public class SportEventController : BaseController
    {
        private readonly GlobalService _globalService;
        private readonly ISportEventRepositories _sportEventRepositories;
        private readonly IOrganizerRepositories _organizerRepositories;

        public SportEventController(GlobalService globalService, ISportEventRepositories sportEventRepositories, IOrganizerRepositories organizerRepositories) : base(globalService)
        {
            this._globalService = globalService;
            this._sportEventRepositories = sportEventRepositories;
            this._organizerRepositories = organizerRepositories;
        }

        public IActionResult Index(int? organizerId = null, int page = 1, int perPage = 10)
        {
            if (string.IsNullOrEmpty(_globalService.Token)) return RedirectToAction("Login", "Account");

            var model = _sportEventRepositories.GetSportEvent(page, perPage, organizerId);

            var organizer = _organizerRepositories.GetOrganizers(1, 10);

            ViewBag.Options = organizer.Data.Select(m => new SelectListItem
            {
                Value = m.ID.ToString(),
                Text = m.OrganizerName
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SportEventDTO();
            var organizer = _organizerRepositories.GetOrganizers(1, 10);

            ViewBag.Options = organizer.Data.Select(m => new SelectListItem
            {
                Value = m.ID.ToString(),
                Text = m.OrganizerName
            }).ToList();
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

            var organizer = _organizerRepositories.GetOrganizers(1, 10);

            ViewBag.Options = organizer.Data.Select(m => new SelectListItem
            {
                Value = m.ID.ToString(),
                Text = m.OrganizerName
            }).ToList();

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
