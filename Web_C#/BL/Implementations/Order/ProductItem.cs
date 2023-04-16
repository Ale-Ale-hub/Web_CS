namespace Web_C_.BL.Implementations.Order
{
    public class ProductItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public ProductItem(int id, decimal price, string name)
        {
            Id = id;
            Price = price;
            Name = name;
        }


    }
}
