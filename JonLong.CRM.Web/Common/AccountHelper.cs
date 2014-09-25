using JonLong.CRM.BLL;
using JonLong.CRM.Models;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Web.Security;
using JonLong.CRM.Utilities;
using System.Web;

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
            return JsonConvert.DeserializeObject<User>(identity.Ticket.Name);
        }
        public static User GetLoginUserInfo(IIdentity identity)
        {
            var ticket = (identity as FormsIdentity).Ticket;
            return JsonConvert.DeserializeObject<User>(ticket.Name);
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
            var permissions = UserManager.Instance.LoadUserPermissions(user.UserId);
            return PermissionHelper.IsSuperAdmin(permissions);
        }

        /// <summary>
        /// 验证用户是否是超级管理
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsSuperAdmin(User user)
        {
            if (user == null || user.UserId <=0)
            {
                return false;
            }
            var permissions = UserManager.Instance.LoadUserPermissions(user.UserId);
            return PermissionHelper.IsSuperAdmin(permissions);
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
            return PermissionHelper.IsSuperAdmin(permissions);
        }

        public static string GetCustomerCode(string customerCode)
        {
            if (customerCode.ToUpper() == "U0034"
                || customerCode.ToUpper() == "U0035"
                || customerCode.ToUpper() =="U0036"
                || customerCode.ToUpper() =="U0037")
            {
                return "U0005";
            }
            return customerCode;
        }

    }
}