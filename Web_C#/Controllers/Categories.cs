
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
        public Categories(IProductBL productBL)
        {
            this.productBL = productBL;
        }
        public async Task<IActionResult> Phone()
        {
            return View("Result", await productBL.GetPhonesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Result(string query) 
        {
            
            return View(await productBL.GetProductsAsync(query));
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
