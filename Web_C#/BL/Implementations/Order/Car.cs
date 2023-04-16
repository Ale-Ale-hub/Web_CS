using System.Linq;

namespace Web_C_.BL.Implementations.Order
{
    public class Car
    {
        //private  PhoneRepository phoneModel;

        //int Id { get; set; }
        //public Car(PhoneRepository phoneModel)
        //{
        //    this.phoneModel = phoneModel;
        //}

        //public PhoneRepository getPhone(int id)
        //{
        //    phoneModel = phoneModel.getPhones().FirstOrDefault(x => x.Id == id);
        //    if (phoneModel == null)
        //    {

        //        phoneModel = new PhoneRepository();
        //    }

        //    return phoneModel;
        //}

        public Car(int id)
        {
            Id = id;
            products = new List<Product>();
        }

        public int Id { get; }
        public int TypeProduct => products.Count;

        public int TotalCount
        {
            get

            {

                if (!products.Any())
                    return 0;
                else
                {
                    int sum = 0;
                    foreach (var item in products)
                    {
                        sum += item.TotalCount;
                    }
                    return sum;

                }
            }
        }


        public decimal TotalPrice
        {
            get

            {

                if (!products.Any())
                    return 0;
                else
                {
                    decimal sum = 0;
                    foreach (var item in products)
                    {
                        sum += item.TotalPrice;
                    }
                    return sum;

                }

            }
        }
        public List<Product> products;
        public bool AddProduct(Product product)
        {
            if (product == null)
                return false;

            if (products.FirstOrDefault(prod => prod.Id == product.Id) != null)
            {
                products.Find(prod => prod.Id == product.Id).TotalCount += product.TotalCount;
                return true;
            }
            else
            {
                products.Add(product);
                return true;
            }


        }
        public bool TryGetProducrtsValue()
        {
            return products.Any();
        }

        public bool DeleteProductItem(Product product, int count)
        {
            if (products.FirstOrDefault(prod => prod.Id == product.Id) != null)
            {

                products.Find(prod => prod.Id == product.Id).TotalCount -= count;
                return true;
            }
            return false;
        }
        //public bool ContainsProduct(Product product) 
        //{ 
        //    return products.Contains(product);

        //}
    }

}
