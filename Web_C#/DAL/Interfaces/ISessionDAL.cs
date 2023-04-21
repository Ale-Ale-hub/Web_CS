using Web_C_.DAL.Model;

namespace Web_C_.DAL.Interfaces
{
    public interface ISessionDAL
    {

        Task<SessionDto?> GetSession(Guid sessionId);

        Task UpdateSession(SessionDto model);

        Task CreateSession(SessionDto model);

    }
}
