using Microsoft.AspNetCore.Mvc;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Controllers
{
    public class BaseController: Controller
    {
        private readonly GlobalService _globalService;

        public BaseController(GlobalService globalService)
        {
            this._globalService = globalService;
        }
    }
}
