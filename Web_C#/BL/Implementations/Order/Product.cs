
namespace Web_C_.BL.Implementations.Order
{
    public class Product
    {
        public int Id { get => ProductItem.Id; }
        public int TotalCount
        {
            get => totalCount;
            set
            {
                if (value <= 1)
                    totalCount = 1;
                else
                    totalCount = value;
            }
        }
        public int totalCount;
        public decimal TotalPrice
        {
            get

            {
                if (TotalCount <= 0)
                {
                    return 0;

                }
                else
                    return TotalCount * ProductItem.Price;
            }


        }
        public decimal totalPrice;

        public ProductItem ProductItem { get; }
        public Product(ProductItem productItem)
        {
            ProductItem = productItem;
        }
        public bool AddProductItem(ProductItem product, int count)
        {
            if (product == null || product.Id != Id)
                return false;
            TotalCount += count;
            return true;
        }
    }
}
