using JonLong.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class VarianceEditViewModel
    {
        public VarianceDetail Detail { get; set; }
        public List<string> ShoeSizes { get; set; }

        public List<string> Containers { get; set; }

        public Dictionary<string, string> BundleNos { get; set; }

    }
}