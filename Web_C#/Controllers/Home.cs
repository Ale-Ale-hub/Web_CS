using Microsoft.AspNetCore.Mvc;
using Resunet.BL.Auth;

namespace Web_C_.Controllers
{
    public class Home : Controller
    {
        private readonly ISessionDb sessionDb;

        public Home(ISessionDb sessionDb)
        {
            this.sessionDb = sessionDb;
        }
        public async Task<IActionResult> Index()
        {
            return View( await sessionDb.IsLoggedInAsync());
        }
    }
}
