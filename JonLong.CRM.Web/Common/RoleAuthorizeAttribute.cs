using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using JonLong.CRM.BLL;
using Newtonsoft.Json;
using JonLong.CRM.Models;
using JonLong.CRM.Utilities;

namespace JonLong.CRM.Web.Common
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAuth = false;
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "Account"
                        ,
                        action = "login"
                        ,
                        returnUrl = filterContext.HttpContext.Request.Url
                        ,
                        returnMessage = "您无权查看."
                    }));
                return;
            }

            if (filterContext.RequestContext.HttpContext.User.Identity != null)
            {
                var actionDescriptor = filterContext.ActionDescriptor;
                var controllerDescriptor = actionDescriptor.ControllerDescriptor;
                var controller = controllerDescriptor.ControllerName;
                //var action = actionDescriptor.ActionName;
                var user = AccountHelper.GetLoginUserInfo(filterContext.RequestContext.HttpContext.User.Identity);
                if (user == null || user.UserId <= 0)
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "Error"
                        ,
                        action = "index"
                        ,
                        returnUrl = filterContext.HttpContext.Request.Url
                        ,
                        returnMessage = "您无权查看."
                    }));
                    return;
                }

                var permissions = UserManager.Instance.LoadUserPermissions(user.UserId);
                if (!PermissionHelper.IsAllowed(controller, permissions))
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "Error"
                        ,
                        action = "Index"
                        ,
                        returnUrl = filterContext.HttpContext.Request.Url
                        ,
                        returnMessage = "您无权查看."
                    }));
                    return;
                }

            }

            base.OnAuthorization(filterContext);
        }
    }
}