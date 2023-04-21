using Azure;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Resunet.BL.Auth;
using System.Net;
using Web_C_.DAL.Implementations;
using Web_C_.DAL.Interfaces;
using Web_C_.DAL.Model;

namespace Web_C_.BL.Implementations
{
    public class SessionDb : ISessionDb
    {
        private readonly ISessionDAL sessionDAL;
        private readonly IHttpContextAccessor httpContextAccessor;
        public SessionDb(ISessionDAL sessionDAL, IHttpContextAccessor httpContextAccessor)
        {
            this.sessionDAL = sessionDAL;
            this.httpContextAccessor = httpContextAccessor;
        }

        private void CreateSessionCookie(Guid sessionid)
        {
            CookieOptions options = new CookieOptions();
            options.Path = "/";
            options.HttpOnly = true;
            options.Secure = true;
            httpContextAccessor?.HttpContext?.Response.Cookies.Delete(AuthConstants.SessionCookieName);
            httpContextAccessor?.HttpContext?.Response.Cookies.Append(AuthConstants.SessionCookieName, sessionid.ToString(), options);
        }
        private async Task<SessionDto> CreateSession()
        {
            SessionDto sessionDto = new SessionDto()
            {
                DbSessionId = Guid.NewGuid(),
                Created = DateTime.Now,
                LastAccessed = DateTime.Now,
            
            };
             await sessionDAL.CreateSession(sessionDto);
            return sessionDto;

        }

        public async Task<SessionDto> GetSession()
        {
            Guid sesionId;
            var cookie = httpContextAccessor?.HttpContext?.Request?.Cookies.FirstOrDefault(m => m.Key == AuthConstants.SessionCookieName);
            if (cookie != null && cookie.Value.Value != null)
                sesionId = Guid.Parse(cookie.Value.Value);
            else 
                sesionId = Guid.NewGuid();
            var session = await sessionDAL.GetSession(sesionId);
            if (session == null)
            {
                session = await this.CreateSession();
                CreateSessionCookie(session.DbSessionId);
            }
            return session;

        }

        public async Task<int?> GetUserId()
        {
            var user = await this.GetSession();
            return user.UserId;
        }

        public async Task<bool> IsLoggedIn()
        {
            var user = await this.GetSession();
            return user.UserId != null;
        }

        public async Task SetUserId(int userId)
        {
            var session = await this.GetSession();
            session.UserId = userId;
            session.DbSessionId = Guid.NewGuid();
            CreateSessionCookie(session.DbSessionId);
            await sessionDAL.CreateSession(session);

        }
    }
}
