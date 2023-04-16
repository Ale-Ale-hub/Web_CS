
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Web_C_.BL.Implementations.Order;
using Web_C_.BL.Interfaces;
using Web_C_.DAL.Implementations;
using Web_C_.Database;
using Web_C_.Database.Data;

namespace Web_C_.Controllers
{
    public class Categories : Controller
    {
        private readonly IProductBL productBL;
        bool sortByName = false;
        public Categories(IProductBL productBL)
        {
            this.productBL = productBL;
        }
        public IActionResult Phone()
        {
            

            return View("Result", productBL.GetPhonesAsync().Result);

        }
        [HttpPost]
        public IActionResult Result(string query) 
        {
            
            return View(productBL.GetProductsAsync(query).Result);
        }
        //public IActionResult SortByName()
        //{
        //    sortByName = sortByName == false?true:false;
        //    using (StoreDbContext storeDbContext = new StoreDbContext())
        //    {
        //        List<ProductDto> products = new List<ProductDto>();
        //        int[] i = { 1, 2, 3 };

        //        if (sortByName)
        //        {
        //            products = storeDbContext.Products.Where(prod => prod.Id == 1).OrderBy(nam => nam.Name).ToList();

        //        }
        //        else
        //        {
        //            products = storeDbContext.Products.Where(prod => prod.Id == 1).OrderByDescending(nam => nam.Name).ToList();


        //        }
        //    }
        //    return View();
        //}



    }
}
