using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonLong.CRM.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }

        public string Roles { get; set; }
        /// <summary>
        /// 用户编号(Khbh)
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户名称(kh_mc)
        /// </summary>
        public string CustomerName { get; set; }

        public string PasswordPrompt { get; set; }

        /// <summary>
        /// 是否是合同客户(htkh)
        /// </summary>
        public bool IsContractCustomer { get; set; }

        /// <summary>
        /// (khEmail)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 状态(1-正常; 0-关闭)
        /// </summary>
        public int State { get; set; }

    }
}
