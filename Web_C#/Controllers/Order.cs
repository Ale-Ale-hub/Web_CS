using Microsoft.AspNetCore.Mvc;
using Web_C_.Infrastructure;
using Web_C_.Models;
using Web_C_.Models.Order;
using Web_C_.Models.Searсh;

namespace Web_C_.Controllers
{
    public class Order : Controller
    {

        public Car car;
        public Cart cart;
        public Product product;
        public SearchProduct SearchProduct;
        private ProductItem ProductItem;
        private readonly OrderRepository orderRepository;

        public Order( OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
            SearchProduct = new SearchProduct();
        }



        [HttpPost]
        public IActionResult AddItem(int Id,int count =1)
        {
            ProductItem = SearchProduct.GetProductId(Id);
            product = new Product(ProductItem);
            product.AddProductItem(ProductItem, count);
            if (HttpContext.Session.TryGetCart(out cart))
            {
                car = orderRepository.GetById(cart.CartId);
                car.AddProduct(product);

                cart.TotalCount = car.TotalCount;
                cart.TotalPrice = car.TotalPrice;

            }
            else
            {
                car = orderRepository.Creat();
                car.AddProduct(product);
                cart = new Cart(car.Id) 
                {
                    TotalCount = car.TotalCount,
                    TotalPrice = car.TotalPrice,
                };
            }
            HttpContext.Session.Set(cart);

            return RedirectToAction(nameof(Categories.Phone),nameof(Categories));


        }
        public IActionResult Cart() 
        {
            if (HttpContext.Session.TryGetCart(out cart))
            {
                car = orderRepository.GetById(cart.CartId);



            }

                return View(car);
        }
    }
}
