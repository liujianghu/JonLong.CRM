using JonLong.CRM.BLL;
using JonLong.CRM.Models;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Web.Security;
using JonLong.CRM.Utilities;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System;

namespace JonLong.CRM.Web.Common
{
    public static class AccountHelper
    {
        public static User GetCurrentUser()
        {
            var identity = HttpContext.Current.User.Identity as FormsIdentity;
            if (identity == null)
            {
                return null;
            }
            var user = JsonConvert.DeserializeObject<User>(identity.Ticket.Name);
            user.Permissions = CookieHelper.Get<List<Permission>>("permission");
            return user;
        }
        public static User GetLoginUserInfo(IIdentity identity)
        {
            var ticket = (identity as FormsIdentity).Ticket;
            return JsonConvert.DeserializeObject<User>(ticket.Name);
        }

        public static HashSet<string> commonActions = new HashSet<string>
        {
            "loadcontainer","loadsizebyshoe", "statistscdetail", "updatepassword"
            , "editprofile","preload","variancedetail","shipment","order",// variance order
            "exportdata"
        };

        public static bool IsAllowed(List<Permission> permissions, string controllerName, string actionName = "")
        {
            var user = GetCurrentUser();
            if (user == null || user.UserId <= 0)
            {
                return false;
            }
            controllerName = controllerName.ToLower();
            if (!String.IsNullOrEmpty(actionName))
            {
                actionName = actionName.ToLower();
            }
            if (controllerName == "home" || controllerName == "download")
            {
                return true;
            }
            if (permissions == null || !permissions.Any())
            {
                return false;
            }
            if (permissions.Exists(t => t.Controller == Constants.SuperAdminPermission))
            {
                return true;
            }
            if (permissions.Exists(t => t.Controller == controllerName
                && (String.IsNullOrEmpty(actionName) || t.Action == actionName 
                || commonActions.Contains(actionName))))
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// 验证是否有权限访问此功能
        /// </summary>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public static bool IsAllowed(string controllerName, string actionName = "")
        {
            var user = GetCurrentUser();
            if (user == null || user.UserId <= 0)
            {
                return false;
            }
            controllerName = controllerName.ToLower();
            if (!String.IsNullOrEmpty(actionName))
            {
                actionName = actionName.ToLower();
            }
            if (controllerName == "home" || controllerName == "download")
            {
                return true;
            }

            var permissions = user.Permissions;
            if (permissions == null || !permissions.Any())
            {
                return false;
            }
            if (permissions.Exists(t => t.Controller == Constants.SuperAdminPermission))
            {
                return true;
            }
            if (permissions.Exists(t => t.Controller == controllerName
                && (String.IsNullOrEmpty(actionName) || t.Action == actionName || commonActions.Contains(actionName))))
            {
                return true;
            }

            return false;

        }


        /// <summary>
        /// 验证当前用户是否是超级管理员
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static bool IsSuperAdmin(IIdentity identity)
        {
            var user = GetLoginUserInfo(identity);
            if (user == null || user.UserId <= 0)
            {
                return false;
            }
            return IsSuperAdmin(user.Permissions);
        }


        /// <summary>
        /// 验证用户是否是超级管理
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsSuperAdmin(User user)
        {
            if (user == null || user.UserId <= 0)
            {
                return false;
            }
            return IsSuperAdmin(user.Permissions);
        }

        /// <summary>
        /// 验证用户是否是超级管理
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool IsSuperAdmin(int userId)
        {
            if (userId <= 0)
            {
                return false;
            }
            var permissions = UserManager.Instance.LoadUserPermissions(userId);
            return IsSuperAdmin(permissions);
        }

        /// <summary>
        /// 判断是否拥有超级管理员的权限
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public static bool IsSuperAdmin(List<Permission> permissions)
        {
            if (permissions == null || !permissions.Any())
            {
                return false;
            }
            if (permissions.Exists(t => t.Controller == Constants.SuperAdminPermission.ToLower()))
            {
                return true;
            }
            return false;
        }

        public static string GetCustomerCode(string customerCode)
        {
            if (customerCode.ToUpper() == "U0034"
                || customerCode.ToUpper() == "U0035"
                || customerCode.ToUpper() == "U0036"
                || customerCode.ToUpper() == "U0037")
            {
                return "U0005";
            }
            return customerCode;
        }

    }
}