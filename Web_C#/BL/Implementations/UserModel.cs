using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Web_C_.BL.Interfaces;
using Web_C_.DAL.Implementations;
using Web_C_.DAL.Interfaces;
using Web_C_.Database;
using Web_C_.Database.Data;
using Web_C_.ModelsView;

namespace Web_C_.BL.Implementations
{
    public class UserModel : IUserBL
    {
        private readonly IUserDAL userDAL;

        public UserModel(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public UserViewModel AddUser(RegistrationModel user)
        {
            if (user == null || UserVerification(user.Email, user.Phone))
                return null;
            string salt = Guid.NewGuid().ToString();
            user.Password = HashPassword(user.Password, salt);
            userDAL.AddUser(new UserDto() { Name= user.Name, Email= user.Email, Phone = user.Phone, Password = user.Password, Salt = salt});
            return new UserViewModel(user.Name, user.Email, user.Phone);
        }

        public UserViewModel Authenticate(string email, string password)
        {
           UserDto user = userDAL.GetByUserEmail(email);
            
            if (user == null || user.Password != HashPassword(password, user.Salt))
              return null;
            SaveUser();
            return new UserViewModel(user.Name, user.Email, user.Phone);
        }

        private void SaveUser()
        {
            return;
        }

        public bool UserVerification(string email, string phone, ref UserVerificationViewModel userVerification)
        {
            userVerification.Email = userDAL.GetByUserEmail(email) == null ? false : true;
            userVerification.Phone = userDAL.GetByUserPhone(email) == null ? false : true;
            if (userVerification.Phone || userVerification.Email)
                        return true;
                    return false;
        }
        public bool UserVerification(string email, string phone)
        {
            
            
            if (userDAL.GetByUserEmail(email) == null ? false : true || userDAL.GetByUserPhone(email) == null ? false : true)
                return true;
            return false;
        }
        private string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                System.Text.Encoding.ASCII.GetBytes(salt),
                KeyDerivationPrf.HMACSHA512,
                5000,
                64
                ));
        }
        //public int Authenticate(string email, string password, out UserViewModel user)
        //{
        //    UserDto userDto;
        //    using (StoreDbContext storeDbContext = new StoreDbContext())
        //    {
        //        userDto = storeDbContext.Users.SingleOrDefault(user => user.Email == email);
        //    }
        //    if (userDto == null || userDto.Password != HashPassword(password, userDto.Salt))
        //    {
        //        user = null;
        //        return -1;
        //    }

        //    user = new UserViewModel(userDto.Id, userDto.Name, userDto.Email, userDto.Password, userDto.Phone);
        //    return userDto.Id;
        //}
        ////public UserViewModel AddUserId(int id)
        ////{
        ////    UserDto userDto;
        ////    using (StoreDbContext storeDbContext = new StoreDbContext())
        ////    {
        ////        userDto = storeDbContext.Users.Single(userDto => userDto.Id == id );
        ////    }
        ////    return 
        ////}
        //public bool UserVerification(string name, string email, string phone, ref UserModel userVerification)
        //{
        //    using (StoreDbContext storeDbContext = new StoreDbContext())
        //    {
        //        Name = storeDbContext.Users.Any(user => user.Name == name);
        //        Email = storeDbContext.Users.Any(user => user.Phone == phone);
        //        Phone = storeDbContext.Users.Any(user => user.Email == email);

        //    }
        //    if (Name || Email || Phone)
        //    {
        //        userVerification = this;
        //        return true;

        //    }
        //    return false;
        //}
        //public void AddUser(RegistrationModel user)
        //{
        //    string salt = Guid.NewGuid().ToString();
        //    user.Password = HashPassword(user.Password, salt);
        //    using (StoreDbContext storeDbContext = new StoreDbContext())
        //    {
        //        storeDbContext.Users.Add(new UserDto()
        //        {
        //            Name = user.Name,
        //            Email = user.Email,
        //            Phone = user.Phone,
        //            Password = user.Password,
        //            Salt = salt

        //        });

        //        storeDbContext.SaveChanges();
        //    }


        //}

    }
}
