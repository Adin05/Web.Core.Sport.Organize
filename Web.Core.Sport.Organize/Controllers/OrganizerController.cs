using Microsoft.AspNetCore.Mvc;
using Web.Core.Sport.Organize.Interfaces;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Controllers
{
    public class OrganizerController : BaseController
    {
        private readonly GlobalService _globalService;
        private readonly IOrganizerRepositories _organizerRepositories;

        public OrganizerController(GlobalService globalService, IOrganizerRepositories organizerRepositories) : base(globalService)
        {
            this._globalService = globalService;
            this._organizerRepositories = organizerRepositories;
        }

        public IActionResult Index(int page= 1, int perPage = 10)
        {
            if (string.IsNullOrEmpty(_globalService.Token)) return RedirectToAction("Login", "Account");

            var model = _organizerRepositories.GetOrganizers(page, perPage);
            return View(model);
        }
    }
}
