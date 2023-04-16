using Web_C_.BL.Implementations.Order;
using Web_C_.BL.Interfaces;
using Web_C_.DAL.Implementations;
using Web_C_.ModelsView;

namespace Web_C_.BL.Implementations
{
    public class ProductBL : IProductBL
    {
        private readonly SearchProductsDAL productDAL;

        public ProductBL(SearchProductsDAL productDAL)
        {
            this.productDAL = productDAL;
        }
        public async Task<PhoneViewModel> GetPhoneIdAsync(int id)
        {
            var phone = await productDAL.GetPhoneIdAsync(id);
            return new PhoneViewModel(phone.Id, phone.Name, phone.Price, phone.Amount > 0, phone.Description);
        }

        public async Task<IEnumerable<PhoneViewModel>> GetPhonesAsync()
        {
            var phones = await productDAL.GetPhonesAsync();
            List< PhoneViewModel > phoneViews = new List< PhoneViewModel >();
            foreach (var phone in phones)
            {
                phoneViews.Add(new PhoneViewModel(phone.Id, phone.Name, phone.Price, phone.Amount > 0, phone.Description));

            }
            return phoneViews;
        }

        public async Task<ProductItem> GetProductIdAsync(int id)
        {
            var product = await productDAL.GetProductIdAsync(id);
            return new ProductItem(product.Id,  product.Price, product.Name);
        }

        public async Task<IEnumerable<PhoneViewModel>> GetProductsAsync(string query)
        {
            List<PhoneViewModel> phoneViews = new List<PhoneViewModel>();
            var phones = await productDAL.GetProductsAsync(query);
            foreach (var phone in phones)
            {
                phoneViews.Add(new PhoneViewModel(phone.Id, phone.Name, phone.Price, phone.Amount > 0, phone.Description));

            }
            return phoneViews;
        }
    }
}
