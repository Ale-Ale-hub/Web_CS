using Microsoft.EntityFrameworkCore;
using Web_C_.DAL.Interfaces;
using Web_C_.DAL.Model;
using Web_C_.Database;

namespace Web_C_.DAL.Implementations
{
    public class SessionDAL : ISessionDAL
    {
        public async Task CreateSession(SessionDto model)
        {
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
                await storeDbContext.Sessions.AddAsync(model);
                await storeDbContext.SaveChangesAsync();
            }


        }

        public async Task<SessionDto?> GetSession(Guid sessionId)
        {

            using (StoreDbContext storeDbContext = new StoreDbContext())
            {
              return await storeDbContext.Sessions.SingleOrDefaultAsync(session => session.DbSessionId == sessionId);
            }

        }

        public async Task UpdateSession(SessionDto model)
        {
            SessionDto? session;
            using (StoreDbContext storeDbContext = new StoreDbContext())
            {

                session = await storeDbContext.Sessions.SingleOrDefaultAsync(session => session.DbSessionId == model.DbSessionId);
                // ошибка такой сессии не существует
                if (session == null)
                    return; 
                session.Created = model.Created;
                session.LastAccessed = model.LastAccessed;
                session.UserId = model.UserId;
                await storeDbContext.SaveChangesAsync();


            }

        }
    }
}
