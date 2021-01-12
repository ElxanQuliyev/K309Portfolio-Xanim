using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K309Portfolio.Areas.AdminPanel.Controllers
{
    public class AdminFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        [AdminFilter]
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                //Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }
            if (HttpContext.Current.Session["ActiveAdmin"] == null)
            {
                filterContext.Result = new RedirectResult("~/AdminPanel/AdminAccount/Login");
            }
        }
    }
}