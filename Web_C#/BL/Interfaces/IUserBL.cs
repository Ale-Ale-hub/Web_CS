using Web_C_.BL.Implementations;
using Web_C_.ModelsView;

namespace Web_C_.BL.Interfaces
{
    public interface IUserBL
    {
        public UserViewModel Authenticate(string email, string password);
        public bool UserVerification(string email, string phone, ref UserVerificationViewModel userVerification);
        public UserViewModel AddUser(RegistrationModel user);
        public bool UserVerification(string email, string phone);


    }
}
