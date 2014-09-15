using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonLong.CRM.Utilities
{
    public static class Constants
    {
        public static readonly Dictionary<string, string> Permissions = new Dictionary<string, string>
        {
            {"superadmin","superadmin"},
            {"user","user"},
            {"role","role"},
            {"order","order"},
            {"enroute","en route"},
            {"arrived","arrived"},
            {"ordervariance","order variance"},
            {"jlwarehouse", "JonLong Warehouse"}
        };

        /// <summary>
        /// 货柜类型
        /// </summary>
        public static readonly List<string> Containers = new List<string> { "20", "40", "40T", "LCL", "COURIER" };

        /// <summary>
        /// 超级管理员权限
        /// </summary>
        public const string SuperAdminPermission = "superadmin";

        /// <summary>
        /// 超级管理员默认使用的客户编号(khbh)
        /// </summary>
        public const string SuperAdminDefaultCustomerCode = "U0025";


    }
}
