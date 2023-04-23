using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Web_C_.BL.Interfaces;
using Web_C_.DAL.Interfaces;
using Web_C_.Database.Data;
using Web_C_.ModelsView;

namespace Web_C_.BL.Implementations
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL userDAL;

        public UserBL(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public async Task<UserViewModel> AddUserAsync(RegistrationModel user)
        {
            string salt = Guid.NewGuid().ToString();
            user.Password = HashPassword(user.Password, salt);
            await userDAL.AddUser(new UserDto() { Name= user.Name, Email= user.Email, Phone = user.Phone, Password = user.Password, Salt = salt});
            return new UserViewModel(user.Name, user.Email, user.Phone);
        }

        public async Task<(int id,UserViewModel?)> AuthenticateAsync(string email, string password)
        {
           UserDto? user = await userDAL.GetByUserEmailAsync(email);
            
            if (user == null || user.Password != HashPassword(password, user.Salt!))
              return (0, null);
            SaveUser();

            return (user.Id, new UserViewModel(user.Name!, user.Email!, user.Phone!));
        }
        public async Task<int> GetUserIdAsync(string? email, string? phone)
        {
            if (email == null && phone == null)
                return 0;
            if (email != null)
                return (await userDAL.GetByUserEmailAsync(email))?.Id ?? 0;
            return (await userDAL.GetByUserEmailAsync(phone!))?.Id ?? 0;
        }

        private void SaveUser()
        {
            return;
        }

        public void ValidateLogin(ModelStateDictionary modelState)
        {
            modelState.TryAddModelError(nameof(UserViewModel.Password), new ValidationResult("Вы неправильно ввели пароль или email").ErrorMessage!);
        }


        public async Task ValidatePhoneAsync(string phone, ModelStateDictionary modelState)
        {
            if ((await userDAL.GetByUserPhoneAsync(phone)) == null)
                return;

            modelState.TryAddModelError(nameof(RegistrationModel.Phone), new ValidationResult("Телефон уже существует").ErrorMessage!);
        }

        public async Task ValidateEmailAsync(string email, ModelStateDictionary modelState)
        {
            if ((await userDAL.GetByUserEmailAsync(email)) == null)
                return;

            modelState.TryAddModelError(nameof(RegistrationModel.Email), new ValidationResult("Email уже существует").ErrorMessage!);
        }

        public async Task<UserDto?> GetByUserIdAsync(int id)
        {
            return await userDAL.GetByUserIdAsync(id);

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

    }
}
