﻿using Web_C_.Database.Data;

namespace Web_C_.DAL.Interfaces
{
    public interface IUserDAL
    {
        public Task<UserDto?> GetByUserIdAsync(int userId);
        public Task<UserDto?> GetByUserEmail(string email);
        public Task<UserDto?> GetByUserPhone(string phone);

        public IEnumerable<UserDto> GetByUserName(string name);
        public Task AddUser(UserDto user);

    }
}
