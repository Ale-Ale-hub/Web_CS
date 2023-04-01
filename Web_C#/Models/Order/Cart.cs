namespace Web_C_.Models.Order
{
    public class Cart
    {
        public int CartId { get; set; }
        //public int TypeProduct => products.Count;

        //public int TotalCount
        //{
        //    get

        //    {

        //        if (!products.Any())
        //            return 0;
        //        else
        //        {
        //            int sum = 0;
        //            foreach (var item in products)
        //            {
        //                sum += item.TotalCount;
        //            }
        //            return sum;

        //        }
        //    }

        //}
        //public decimal TotalPrice
        //{
        //    get

        //    {

        //        if (!products.Any())
        //            return 0;
        //        else
        //        {
        //            decimal sum = 0;
        //            foreach (var item in products)
        //            {
        //                sum += item.TotalPrice;
        //            }
        //            return sum;

        //        }

        //    }
        //}
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public Cart(int cartId)
        {
            CartId = cartId;
        }
        
    }
}
