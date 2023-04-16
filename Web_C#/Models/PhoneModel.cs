
using Web_C_.Models.Order;

namespace Web_C_.Models
{
    public class PhoneModel : ProductItem
    {
        public bool Have { get; set; }
        public string Description { get; set; }

        public PhoneModel(int id, string name, int price, bool have, string description) :
            base(id, price,  name )
        {
           
            Have = have;
            Description = description;
            
        }
        

}
}
