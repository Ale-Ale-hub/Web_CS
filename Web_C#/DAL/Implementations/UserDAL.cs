using Microsoft.EntityFrameworkCore;
using Web_C_.DAL.Interfaces;
using Web_C_.Database;
using Web_C_.Database.Data;

namespace Web_C_.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public async Task AddUser(UserDto user)
        {
            if (user == null) 
                return;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
               await storeDbContext.Users.AddAsync(user);
               await storeDbContext.SaveChangesAsync();
            }
        }

        public async Task<UserDto?> GetByUserEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
               return await storeDbContext.Users.SingleOrDefaultAsync(user => user.Email == email); 

            }

        }
        public async Task<UserDto?> GetByUserPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return null;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                return await storeDbContext.Users.SingleOrDefaultAsync(user => user.Phone == phone);

            }

        }
        public async Task<UserDto?> GetByUserIdAsync(int userId)
        {
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                return await storeDbContext.Users.SingleOrDefaultAsync(user => user.Id == userId);
            }
        }

        public IEnumerable<UserDto> GetByUserName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3)
                return Enumerable.Empty<UserDto>();
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
              return storeDbContext.Users.Where(user => user.Name == name);
            }
        }
    }
}
