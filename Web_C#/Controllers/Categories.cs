using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_C_.Models;

namespace Web_C_.Controllers
{
    public class Categories : Controller
    {
        public Categories(PhoneModel phoneModel)
        {
            PhoneModel = phoneModel;
        }

        public PhoneModel PhoneModel { get; }

        public IActionResult Phone()
        {

            return View(PhoneModel.getPhones());

        }
 
        
    }
}
