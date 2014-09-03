using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonLong.CRM.Models
{
    public class Order
    {
        public int Id { get; set; }

        /// <summary>
        /// 客户鞋型(khyx_xh)
        /// </summary>
        public string ModelNo { get; set; }
        /// <summary>
        /// 数量合计(khys_sl)
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 发货日期(fhrq)
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 客户代码(khys_khh)
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户原交期(khys_khjq)
        /// </summary>
        public DateTime OriginalETD { get; set; }
        /// <summary>
        /// 绑定编号(khys_banderNo)
        /// </summary>
        public string BanderNo { get; set; }

        /// <summary>
        /// 货柜类型(khys_gz)
        /// </summary>
        public string ContainerType { get; set; }

        /// <summary>
        /// 客户订单号(khdd)
        /// </summary>
        public string ContractNo { get; set; }

        /// <summary>
        /// size1型号的数量
        /// </summary>
        public int Size1 { get; set; }
        public int Size2 { get; set; }
        public int Size3 { get; set; }
        public int Size4 { get; set; }
        public int Size5 { get; set; }
        public int Size6 { get; set; }
        public int Size7 { get; set; }
        public int Size8 { get; set; }
        public int Size9 { get; set; }
        public int Size10 { get; set; }
        public int Size11 { get; set; }
        public int Size12 { get; set; }
        public int Size13 { get; set; }
        public int Size14 { get; set; }
        public int Size15 { get; set; }
        public int Size16 { get; set; }
        public int Size17 { get; set; }
        public int Size18 { get; set; }
        public int Size19 { get; set; }
        public int Size20 { get; set; }


    }
}
