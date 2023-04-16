using Web_C_.DAL.Interfaces;
using Web_C_.Database;
using Web_C_.Database.Data;

namespace Web_C_.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public bool AddUser(UserDto user)
        {
            if (user == null) 
                return false;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                storeDbContext.Users.Add(user);
                storeDbContext.SaveChanges();
            }
            return true;
        }

        public UserDto GetByUserEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return new UserDto();
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
               return storeDbContext.Users.SingleOrDefault(user => user.Email == email); 

            }

        }
        public UserDto GetByUserPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return new UserDto();
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                return storeDbContext.Users.SingleOrDefault(user => user.Phone == phone);

            }

        }
        public UserDto GetByUserId(int userId)
        {
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                return storeDbContext.Users.SingleOrDefault(user => user.Id == userId);
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
