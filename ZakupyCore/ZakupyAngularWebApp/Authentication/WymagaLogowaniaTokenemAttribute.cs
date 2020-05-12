using System.Linq;
using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ZakupyAngularWebApp.Authentication
{
    public class WymagaLogowaniaTokenemAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        private const string KLUCZ_TOKEN_HEADER = "ak_user_token";

        public WymagaLogowaniaTokenemAttribute()
        {
        }

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
            ITokenGenerationService tokenGenerationService;
            tokenGenerationService = (ITokenGenerationService)
                context.HttpContext.RequestServices
                    .GetService(typeof(ITokenGenerationService));

            var tokenHeaderValues = context.HttpContext.Request.Headers[KLUCZ_TOKEN_HEADER];
            var firstValue = tokenHeaderValues.FirstOrDefault();
            if (firstValue == null || !VerifyToken(firstValue, tokenGenerationService))
            {
                context.Result = new ObjectResult(context.ModelState)
                {
                    Value = null,
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }

        private bool VerifyToken(
            string token,
            ITokenGenerationService tokenGenerationService)
        {
            return tokenGenerationService.VerifyToken(token);
        }
    }
}
