using Microsoft.AspNetCore.Mvc;

namespace Web.Core.Sport.Organize.Controllers
{
    public class OrganizerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
