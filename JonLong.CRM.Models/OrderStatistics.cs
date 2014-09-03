using System;
using System.Collections.Generic;

namespace JonLong.CRM.Models
{
    public class OrderStatistics
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 发货日期(khys_fhrq)
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 绑定编号(khys_banderNo)
        /// </summary>
        public string BanderNo { get; set; }

        /// <summary>
        /// 货柜类型(khys_gz)
        /// </summary>
        public string ContainerType { get; set; }

        /// <summary>
        /// 货柜编号(khys_container)
        /// </summary>
        public string ContainerNo { get; set; }

        /// <summary>
        /// 用户编号(khys_khh)
        /// </summary>
        public string CustomerCode
        {
            get;
            set;
        }

        /// <summary>
        /// 装柜百分比(khys_bfb)
        /// </summary>
        public double Filled { get; set; }
        /// <summary>
        /// 生成完成百分比(khys_fhb)
        /// </summary>
        public double Complete { get; set; }

        /// <summary>
        /// 货柜总数量(sumS)
        /// </summary>
        public int ContainerSum { get; set; }

        /// <summary>
        /// 转为订单的日期
        /// </summary>
        public DateTime? ChangeDate { get; set; }

        /// <summary>
        /// 合同号(htbh) --已经不知道怎么命名了
        /// </summary>
        public string HTBH { get; set; }
        /// <summary>
        /// 客户订单号(khdd)
        /// </summary>
        public string ContractNo { get; set; }

        public List<Order> Orders { get; set; }

    }
}
