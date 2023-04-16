using Web_C_.BL.Implementations.Order;
using Web_C_.Database.Data;
using Web_C_.ModelsView;

namespace Web_C_.BL.Interfaces
{
    public interface IProductBL
    {
        public Task<ProductItem> GetProductIdAsync(int id);
        public Task<IEnumerable<PhoneViewModel>> GetProductsAsync(string query);
        public Task<IEnumerable<PhoneViewModel>> GetPhonesAsync();
        public Task<PhoneViewModel> GetPhoneIdAsync(int id);
    }
}
