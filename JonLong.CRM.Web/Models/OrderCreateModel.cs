using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class OrderCreateModel
    {
        public OrderCreateModel()
        {
            this.Shoe = String.Empty;
            this.ContainerType = String.Empty;
        }
        public string ETD { get; set; }

        public string ContainerType { get; set; }

        public string BundleNo { get; set; }

        public string Shoe { get; set; }

        public string ContractNo { get; set; }

        public List<string> BundlerNoList { get; set; }

        public Dictionary<string,string> ShoeList { get; set; }

        public List<string> ContainerTypes { get; set; }

        public List<string> ShoeSizes { get; set; }

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
        public int Total { get; set; }


    }
}