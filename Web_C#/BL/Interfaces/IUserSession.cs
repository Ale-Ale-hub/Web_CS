using Web_C_.ModelsView;

namespace Web_C_.BL.Interfaces
{
    public interface IUserSession
    {
        Task<UserViewModel?> GetUserWithSession(Guid sessionID);




    }
}
