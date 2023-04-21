
using Microsoft.AspNetCore.Mvc;
using Resunet.BL.Auth;
using System.Numerics;
using Web_C_.BL.Implementations;
using Web_C_.BL.Interfaces;
using Web_C_.ModelsView;

namespace Web_C_.Controllers
{
    public class Identification : Controller
    {
        private readonly ILogger<Identification> _logger;
        private readonly IProductBL productBL;
        private readonly IUserBL userBL;
        private readonly ISessionDb sessionDb;

        public Identification(ILogger<Identification> logger, IProductBL productBL, IUserBL userBL, ISessionDb sessionDb)
        {
            _logger = logger;
            this.productBL = productBL;
            this.userBL = userBL;
            this.sessionDb = sessionDb;
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(string email, string  password)
        {
            (int userId, UserViewModel? user) = await userBL.AuthenticateAsync(email, password);
            if (user == null)
            {
                userBL.ValidateLogin(ModelState);
                return View();
            }
            await sessionDb.SetUserIdAsync(userId);

            return View("SuccessfulLogin", user);
        }
        public IActionResult Registration()
        {
            //Проверка зарегестрирован ли пользователь
            //Если да то выдать сообщение; вы уже зарегестрированны...
            //Если нет продолжить выполнение следующего кода
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Registration(RegistrationModel registration)
        {
            if (ModelState.IsValid)
            {
                userBL.ValidateEmail(registration.Email, ModelState);
                userBL.ValidatePhone(registration.Phone, ModelState);
                
                if (ModelState.IsValid)
                {
                    UserViewModel user = await userBL.AddUserAsync(registration);

                    await sessionDb.SetUserIdAsync(await userBL.GetUserIdAsync(user.Email, user.Phone));

                    return View("SuccessfulRegistration", registration);
                }
            }
                return View(registration); 
            
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}