using Microsoft.AspNetCore.Mvc.Filters;

namespace ZakupyAngularWebApp.Authentication
{
    public class WymagaLogowaniaAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        //public void OnAuthentication(AuthenticationContext filterContext)
        //{
        //    var cookie = filterContext.RequestContext.HttpContext.Request.Cookies["solidarnie"];

        //    if (cookie != null)
        //    {
        //    }
        //    else
        //    {
        //        //filterContext.HttpContext.Request.
        //        filterContext.Result = new RedirectToRouteResult(
        //            new RouteValueDictionary(new
        //            {
        //                controller = "Logowanie",
        //                action = "Login",
        //                returnUrl = filterContext.HttpContext.Request.RawUrl
        //            }));

        //        filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        //    }
        //}

        //public void OnAuthenticationChallenge(
        //    AuthenticationChallengeContext filterContext)
        //{
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
