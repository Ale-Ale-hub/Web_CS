
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Web_C_.Models;

namespace Web_C_.Controllers
{
    public class Home : Controller
    {
        private readonly ILogger<Home> _logger;
        private readonly UserVerificationModel UserVerificationModel;

        public Home(ILogger<Home> logger, UserVerificationModel userVerificationModel )
        {
            _logger = logger;
            this.UserVerificationModel = userVerificationModel;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            ViewData["userVerification"]= new UserVerificationModel();
            return View();
        }
        [HttpPost]

        public IActionResult Registration(RegistrationModel registration)
        {
            UserVerificationModel userVerification = new UserVerificationModel();

            if (ModelState.IsValid && !UserVerificationModel.userVerification(registration.Name, registration.Email, registration.Phone,ref userVerification))
            {
                UserVerificationModel.AddingUser(registration);
                userVerification.Save();
                return View("SuccessfulRegistration", registration);

            }
            else
            {
                ViewData["userVerification"] = userVerification;
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