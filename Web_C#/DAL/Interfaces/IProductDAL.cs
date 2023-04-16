using Web_C_.BL.Implementations;
using Web_C_.BL.Implementations.Order;
using Web_C_.Database.Data;

namespace Web_C_.DAL.Interfaces
{
    public interface IProductDAL
    {
        public Task<ProductDto> GetProductIdAsync(int Id);
        public Task<IEnumerable<ProductDto>> GetProductsAsync(string query);

    }
}
