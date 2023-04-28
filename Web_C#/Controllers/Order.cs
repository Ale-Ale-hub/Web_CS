using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Web_C_.BL.Implementations.Order;
using Web_C_.BL.Interfaces;
using Web_C_.Infrastructure;
using Web_C_.Middleware;

namespace Web_C_.Controllers
{

    public class Order : Controller
    {

        public Car? car;
        public Cart? cart;
        public Product? product;
        private ProductItem? ProductItem;
        private readonly OrderRepository orderRepository;
        private readonly IProductBL productBL;

        public Order(OrderRepository orderRepository, IProductBL productBL)
        {
            this.orderRepository = orderRepository;
            this.productBL = productBL;
        }

        public async Task<IActionResult> AddProductItem(int Id,int count =1)
        {
            ProductItem = await productBL.GetProductIdAsync(Id);
            product = new Product(ProductItem);
            if (HttpContext.Session.TryGetCart(out cart))
                car = orderRepository.GetById(cart.CartId);
            else
                car = orderRepository.CreatCart(out cart);


            product.AddProductItem(ProductItem, count);
            car.AddProduct(product);
            cart.TotalCount = car.TotalCount;
            cart.TotalPrice = car.TotalPrice;
            HttpContext.Session.SetCart(cart);
            return RedirectToAction(nameof(Order.Cart));
        }
        [SiteNotOrder()]

        public async Task<IActionResult> DeleteProductItem(int Id, int count = 1)
        {
            ProductItem = await productBL.GetProductIdAsync(Id);
            product = new Product(ProductItem);
            if (HttpContext.Session.TryGetCart(out cart))
            {
                car = orderRepository.GetById(cart.CartId);
                car.DeleteProductItem(product, count);

                cart.TotalCount = car.TotalCount;
                cart.TotalPrice = car.TotalPrice;

                HttpContext.Session.SetCart(cart);

            }

            return RedirectToAction(nameof(Order.Cart));

        }
        [HttpGet]
        [SiteNotOrder()]

        public IActionResult Cart() 
        {
            if (HttpContext.Session.TryGetCart(out cart))
            {
                car = orderRepository.GetById(cart.CartId);

                return View(car);
            }

            return View();
        }
        [SiteNotOrder()]

        public IActionResult DeleteProduct(int id)
        {
            if (HttpContext.Session.TryGetCart(out cart)) 
            {
                car = orderRepository.GetById(cart.CartId);
                if (car.products.Remove(car.products.First(idProducts => idProducts.Id == id)))
                {
                    if (!car.TryGetProducrtsValue()) 
                    {
                        HttpContext.Session.RemoveCart();
                        return RedirectToAction(nameof(Order.Cart), nameof(Order));


                    }


                    cart.TotalCount = car.TotalCount;
                    cart.TotalPrice = car.TotalPrice;
                    HttpContext.Session.SetCart(cart);

                    return RedirectToAction(nameof(Order.Cart), nameof(Order));
                    
                }
                //Sorry...
                return RedirectToAction();
            }
                return RedirectToAction(nameof(Home.Index), nameof(Home));

        }
        [SiteNotOrder()]

        public IActionResult DeleteCart(int id)
        {
            if (HttpContext.Session.TryGetCart(out cart))
            {
                if (orderRepository.DeleteCarItem(orderRepository.GetById(cart.CartId)))
                {
                    HttpContext.Session.RemoveCart();
                    return RedirectToAction(nameof(Order.Cart), nameof(Order));

                }
                //Sorry...
                return RedirectToAction();
            }

            return RedirectToAction(nameof(Home.Index), nameof(Home));

        }
    }
}
