using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.DB;
using WebApplication3.Models.EntityManager;
using System.Web.Routing;

namespace WebApplication3.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;

        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                UserManager UM = new UserManager();
                foreach (var roles in userAssignedRoles)
                {
                    var currentuser = httpContext.User.Identity.Name;
                    var x= currentuser;
                    authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "External"}));
        }
    }
}