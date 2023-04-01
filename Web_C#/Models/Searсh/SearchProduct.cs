using Web_C_.Infrastructure;
using Web_C_.Models.Order;

namespace Web_C_.Models.Searсh
{
    public class SearchProduct
    {

        public SearchProduct()
        {
        }
        


        public ProductItem GetProductId(int Id)
        {
            //Поиск по базе через id...

            //Поиск телефонов
            if (PhoneRepository.getPhones().SingleOrDefault(p => p.Id == Id) == null)
            {
                
                return null;
            }
            return PhoneRepository.getPhones().SingleOrDefault(p => p.Id == Id);
            
             
        }


    }
}
