using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class OrderEditModel
    {
        public Order Order { get; set; }
        public List<string> ShoeSizes { get; set; }

        public List<string> Containers { get; set; }

        public Dictionary<string,string> BundleNos { get; set; }

        public string Message { get; set; }
    }
}