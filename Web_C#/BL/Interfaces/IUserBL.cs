using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Web_C_.BL.Implementations;
using Web_C_.ModelsView;

namespace Web_C_.BL.Interfaces
{
    public interface IUserBL
    {
        public (int id, UserViewModel) Authenticate(string email, string password);
        public UserViewModel AddUser(RegistrationModel user);
        public int GetUserId(string? email, string? phone);
        public void ValidateEmail(string email, ModelStateDictionary modelState);
        public void ValidatePhone(string phone, ModelStateDictionary modelState);
        public void ValidateLogin(ModelStateDictionary modelState);

    }
}
