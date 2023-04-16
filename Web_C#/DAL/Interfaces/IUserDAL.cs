using Web_C_.Database.Data;

namespace Web_C_.DAL.Interfaces
{
    public interface IUserDAL
    {
        public UserDto GetByUserId(int userId);
        public UserDto GetByUserEmail(string email);
        public UserDto GetByUserPhone(string phone);

        public IEnumerable<UserDto> GetByUserName(string name);
        public bool AddUser(UserDto user);

    }
}
