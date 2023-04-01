using Web_C_.Models.Order;

namespace Web_C_.Infrastructure
{
    public class OrderRepository
    {


        public List<Car> car;
        //public int Id { get; }

        public OrderRepository()
        {
            car = new List<Car>();

        }
        public Car GetById(int id) => car.Single(car => car.Id == id);
        public Car Creat()
        {
            int nextId = car.Count + 1;
            Car product = new Car(nextId);
            car.Add(product);
            return product;
        }
        
        


    }
}
