using System.Collections.Generic;
using System.Linq;

namespace JonLong.CRM.Utilities
{
    public static class PermissionHelper
    {
        /// <summary>
        /// 严重是否有权限访问此功能
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public static bool IsAllowed(string controllerName, List<string> permissions)
        {
            if (controllerName.ToLower() == "home" || controllerName.ToLower() == "download")
            {
                return true;
            }
            if (permissions == null || !permissions.Any())
            {
                return false;
            }

            if (permissions.Contains(Constants.SuperAdminPermission))
            {
                return true;
            }

            if (permissions.Contains(controllerName.ToLower()))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// 判断是否拥有超级管理员的权限
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public static bool IsSuperAdmin(List<string> permissions)
        {
            if (permissions == null || !permissions.Any())
            {
                return false;
            }
            if (permissions.Contains(Constants.SuperAdminPermission))
            {
                return true;
            }
            return false;
        }

    }
}
