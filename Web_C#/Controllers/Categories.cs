using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_C_.Infrastructure;
using Web_C_.Models;

namespace Web_C_.Controllers
{
    public class Categories : Controller
    {

        public IActionResult Phone()
        {

            return View(PhoneRepository.getPhones());

        }
 
        
    }
}
