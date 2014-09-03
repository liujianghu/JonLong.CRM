using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonLong.CRM.Models
{
    /// <summary>
    /// t_bas_kh
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户编号(kh_bh)
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户名称(kh_mc)
        /// </summary>
        public string Name { get; set; }
    }
}
