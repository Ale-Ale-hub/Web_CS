using Web_C_.BL.Implementations;
using Web_C_.Database.Data;

namespace Web_C_.DAL.Interfaces
{
    public interface IProductPhoneDAL
    {
        public Task<IEnumerable<ProductDto>> GetPhonesAsync();
        public Task<ProductDto> GetPhoneIdAsync(int id);

    }
}
