using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Web_C_.BL.Implementations.Order;
using Web_C_.BL.Interfaces;
using Web_C_.Infrastructure;

namespace Web_C_.Controllers
{
    public class Order : Controller
    {

        public Car car;
        public Cart cart;
        public Product product;
        private ProductItem ProductItem;
        private readonly OrderRepository orderRepository;
        private readonly IProductBL productBL;

        public Order(OrderRepository orderRepository, IProductBL productBL)
        {
            this.orderRepository = orderRepository;
            this.productBL = productBL;
        }


        
        public IActionResult AddProductItem(int Id,int count =1)
        {
            ProductItem = productBL.GetProductIdAsync(Id).Result;
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
            return RedirectToAction(nameof(Order.Cart));
        }
        public IActionResult DeleteProductItem(int Id, int count = 1)
        {
            ProductItem = productBL.GetProductIdAsync(Id).Result;
            product = new Product(ProductItem);
            if (HttpContext.Session.TryGetCart(out cart))
            {
                car = orderRepository.GetById(cart.CartId);
                car.DeleteProductItem(product, count);

                cart.TotalCount = car.TotalCount;
                cart.TotalPrice = car.TotalPrice;

                HttpContext.Session.Set(cart);

            }

            return RedirectToAction(nameof(Order.Cart));

        }
        [HttpGet]
        public IActionResult Cart() 
        {
            if (HttpContext.Session.TryGetCart(out cart))
            {
                car = orderRepository.GetById(cart.CartId);

                return View(car);

            }

            return View();
        }
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
                    HttpContext.Session.Set(cart);

                    return RedirectToAction(nameof(Order.Cart), nameof(Order));
                    
                }
                //Sorry...
                return RedirectToAction();
            }
            
                return RedirectToAction(nameof(Home.Index), nameof(Home));


        }
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
