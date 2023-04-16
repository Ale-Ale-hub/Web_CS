using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using Web_C_.BL.Implementations;
using Web_C_.BL.Implementations.Order;
using Web_C_.DAL.Interfaces;
using Web_C_.DAL.Model.TypeProducts;
using Web_C_.Database;
using Web_C_.Database.Data;
using Web_C_.Infrastructure;

namespace Web_C_.DAL.Implementations
{
    public class SearchProductsDAL : IProductDAL, IProductPhoneDAL
    {
        public async Task<ProductDto> GetProductIdAsync(int Id)
        {
            ProductDto productDtos;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                productDtos = await storeDbContext.Products.SingleOrDefaultAsync(p => p.Id == Id);

            }
            return productDtos ?? new ProductDto();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(string query)
        {
            IEnumerable<ProductDto> productDtos;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                productDtos = await storeDbContext.Products.Where(p => p.Name.Contains(query)).ToListAsync();


            }
            return productDtos ?? Enumerable.Empty<ProductDto>();
        }


        public async Task<ProductDto> GetPhoneIdAsync(int id)
        {
            ProductDto phonesDto;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                phonesDto = await storeDbContext.Products.SingleOrDefaultAsync(item => item.Id == id && item is PhoneDto);

            }
            return phonesDto ?? new ProductDto();

        }

        public async Task<IEnumerable<ProductDto>> GetPhonesAsync()
        {
            IEnumerable<ProductDto> phonesDto;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                phonesDto = await storeDbContext.Products.Where(item => item is PhoneDto).ToListAsync();

            }
            return phonesDto ?? Enumerable.Empty<ProductDto>();

        }

        
        //public List<ProductItem> GetProductsId(int[] Id)
        //{
        //    List<ProductDto> productDtos;
        //    List<ProductItem> ProductItem = new List<ProductItem>();
        //    using (StoreDbContext storeDbContext = new StoreDbContext())
        //    {
        //        productDtos = storeDbContext.Products.ToList();

        //    }

        //    foreach (var itemProduct in productDtos)
        //    {
        //        foreach (int itemId in Id)
        //        {
        //            if (itemProduct.Id == itemId)
        //                ProductItem.Add(new ProductItem(itemProduct.Id, itemProduct.Price, itemProduct.Name));
        //        }
        //    }

        //    return ProductItem;
        //}
        
    }
}
