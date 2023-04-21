using Resunet.BL.Auth;
using Web_C_.BL.Interfaces;
using Web_C_.DAL.Interfaces;
using Web_C_.Database.Data;
using Web_C_.ModelsView;

namespace Web_C_.BL.Implementations
{
    public class UserSessionBL : IUserSession
    {
        private readonly ISessionDAL sessionDAL;
        private readonly IUserDAL userDAL;

        public UserSessionBL(ISessionDAL sessionDAL, IUserDAL userDAL)
        {
            this.sessionDAL = sessionDAL;
            this.userDAL = userDAL;
        }
        public async Task<UserViewModel?> GetUserWithSession( Guid sessionID)
        {
            var userSession = await sessionDAL.GetSession(sessionID);
            if (userSession == null || userSession.UserId == null) 
                return null;
            UserDto? user =  await userDAL.GetByUserIdAsync((int)userSession.UserId);
            if (user ==null)
                return null;
            return new UserViewModel(user.Name!,user.Email!, user.Phone!);
        }
    }
}
