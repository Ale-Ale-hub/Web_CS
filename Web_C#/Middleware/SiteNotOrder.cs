using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Resunet.BL.Auth;
using Web_C_.BL.Implementations.Order;

namespace Web_C_.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class SiteNotOrder : Attribute, IAuthorizationFilter
    {
        
        public SiteNotOrder()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
           
            
            if (!context.HttpContext.Session.TryGetCart(out Cart cart))
                context.Result = new RedirectResult("/");
        }

    }
}
