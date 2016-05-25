using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.AspNet.Identity;

namespace SF.API
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (AuthorizeRequest(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        private bool AuthorizeRequest(HttpActionContext actionContext)
        {
            var isAdmin = actionContext.RequestContext.Principal.IsInRole("Admin");

            var userIdParam = (string)actionContext.ControllerContext.RouteData.Values["userId"];
            var hasAccess = ((System.Security.Claims.ClaimsIdentity) actionContext.RequestContext.Principal.Identity).HasClaim(
                c => (c.Type == "userId" && c.Value == userIdParam) || isAdmin);

            return hasAccess;
        }
    }
}