using System;

namespace JonLong.CRM.Models
{
    public class VarianceDetail
    {
        public int Id { get; set; }

        /// <summary>
        /// 0-deplay, 1-delete, 2-confirm
        /// </summary>
        public int EditType { get; set; }

        public string TGuid { get; set; }

        /// <summary>
        /// 差异类型
        /// </summary>
        public int CYLX { get; set; }

        public string CustomerCode { get; set; }

        public string ModelNo { get; set; }

        public string OldHtbh { get; set; }

        public string ContainerType { get; set; }

        public string ContainerNo { get; set; }

        public string LoginName { get; set; }

        public DateTime SendDate { get; set; }

        public string BundleNo { get; set; }

        public string ContractNo { get; set; }


        public int Total { get; set; }

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
