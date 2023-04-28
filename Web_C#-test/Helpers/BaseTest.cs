

using Microsoft.AspNetCore.Http;
using Resunet.BL.Auth;
using Web_C_.BL.Implementations;
using Web_C_.BL.Interfaces;
using Web_C_.DAL.Implementations;
using Web_C_.DAL.Interfaces;

namespace Web_C__test.Helpers
{
    public class BaseTest
    {
        public IUserDAL userDAL = new UserDAL();
        public ISessionDAL sessionDAL = new SessionDAL();
        public ProductsDAL productsDAL = new ProductsDAL();
        public ISessionDb sessionDb;
        public IUserSessionBL userSession;
        public IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        public IProductBL productBL;
        public IUserBL userBL;
        public BaseTest()
        {
            userBL = new UserBL(userDAL);
            productBL = new ProductBL(productsDAL);
            userSession = new UserSessionBL(sessionDAL, userDAL);
            sessionDb = new SessionDb(sessionDAL, httpContextAccessor);
        }

    }
}
