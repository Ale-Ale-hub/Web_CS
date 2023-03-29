using Microsoft.AspNetCore.Mvc;
using Web_C_.Models;
using Web_C_.Models.order;

namespace Web_C_.Controllers
{
    public class Order : Controller
    {

        public Car Car { get; }



        public Order(Car car)
        {
            Car = car;
        }



        [HttpPost]
        

        public IActionResult AllCar(int Id)
        {
            PhoneModel phone = Car.getPhone(Id);
            Console.WriteLine(  phone.Name);
            return View();


        }
    }
}
