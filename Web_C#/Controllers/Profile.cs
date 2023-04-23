using Microsoft.AspNetCore.Mvc;
using Web_C_.Middleware;

namespace Web_C_.Controllers
{
    [SiteAuthorize()]
    public class Profile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
