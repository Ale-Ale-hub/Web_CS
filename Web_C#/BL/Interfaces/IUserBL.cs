using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Web_C_.BL.Implementations;
using Web_C_.ModelsView;

namespace Web_C_.BL.Interfaces
{
    public interface IUserBL
    {
        public Task<(int id, UserViewModel?)> AuthenticateAsync(string email, string password);
        public Task<UserViewModel> AddUserAsync(RegistrationModel user);
        public Task<int> GetUserIdAsync(string? email, string? phone);
        public Task ValidateEmailAsync(string email, ModelStateDictionary modelState);
        public Task ValidatePhoneAsync(string phone, ModelStateDictionary modelState);
        public void ValidateLogin(ModelStateDictionary modelState);

    }
}
