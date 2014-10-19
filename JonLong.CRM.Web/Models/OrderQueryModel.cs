using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class OrderQueryModel
    {
        public string ETDFrom { get; set; }
        public string ETDTo { get; set; }
        public string BundleNo { get; set; }
        public string ContainerNo { get; set; }

        public string CustomerName { get; set; }

        public string CustomerCode { get; set; }
    }
}