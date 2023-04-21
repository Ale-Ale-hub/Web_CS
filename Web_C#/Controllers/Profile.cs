using Microsoft.AspNetCore.Mvc;

namespace Web_C_.Controllers
{
    public class Profile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
