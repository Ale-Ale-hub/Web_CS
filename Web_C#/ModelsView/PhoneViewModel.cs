using Web_C_.BL.Implementations.Order;

namespace Web_C_.ModelsView
{
    public class PhoneViewModel : ProductItem
    {
        public bool Have { get; set; }
        public string Description { get; set; }

        public PhoneViewModel(int id, string name, decimal price, bool have, string description) :
            base(id, price, name)
        {

            Have = have;
            Description = description;

        }


    }
}
