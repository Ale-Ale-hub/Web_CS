
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Web_C_.BL.Implementations;
using Web_C_.BL.Interfaces;
using Web_C_.ModelsView;

namespace Web_C_.Controllers
{
    public class Home : Controller
    {
        private readonly ILogger<Home> _logger;
        private readonly IProductBL productBL;
        private readonly IUserBL userBL;

        public Home(ILogger<Home> logger, IProductBL productBL, IUserBL userBL )
        {
            _logger = logger;
            this.productBL = productBL;
            this.userBL = userBL;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Login()
        {
            ViewBag.Authenticate = true;
            return View();
        }
        [HttpPost]

        public IActionResult Login(string email, string password)
        {
            UserViewModel user = userBL.Authenticate(email, password);
            if (user == null)
            {
                ViewBag.Authenticate = false;
                return View();
            }
            ViewBag.Authenticate = true;
            return View("SuccessfulLogin", user);
        }
        public IActionResult Registration()
        {
            ViewData["UserVerification"]= new UserVerificationViewModel();
            return View();
        }
        [HttpPost]

        public IActionResult Registration(RegistrationModel registration)
        {
            UserVerificationViewModel userVerification = new UserVerificationViewModel();

            if (ModelState.IsValid && !userBL.UserVerification(registration.Email, registration.Phone,ref userVerification))
            {
                userBL.AddUser(registration);
                return View("SuccessfulRegistration", registration);

            }
            else
            {
                ViewData["UserVerification"] = userVerification;
                return View(registration); 
            }
            
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}