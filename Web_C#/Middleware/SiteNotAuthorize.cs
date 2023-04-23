using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Resunet.BL.Auth;
using Web_C_.BL.Interfaces;

namespace Web_C_.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class SiteNotAuthorize : Attribute, IAsyncAuthorizationFilter
    {
        public SiteNotAuthorize()
        {
            
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            ISessionDb? session = context.HttpContext.RequestServices.GetService<ISessionDb>();
            if (session == null)
                throw new Exception("No user middleware");

            bool isLoginIn = await session.IsLoggedInAsync();
            if (isLoginIn)
                context.Result = new RedirectResult("/");
        }
    }
}
