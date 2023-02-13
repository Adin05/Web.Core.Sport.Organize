using Microsoft.AspNetCore.Mvc;

namespace Web.Core.Sport.Organize.Controllers
{
    public class SportEventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
