using System;
using Web_C_.DAL.Model;

namespace Resunet.BL.Auth
{
    public interface ISessionDb
    {
        Task<SessionDto> GetSession();

        Task SetUserId(int userId);

        Task<int?> GetUserId();

        Task<bool> IsLoggedIn();
    }
}

