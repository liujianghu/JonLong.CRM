using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class ArrivedListViewModel
    {
        public List<ArrivedModel> Items { get; set; }
        public DateTime StartETD { get; set; }
        public DateTime EndETD { get; set; }
        public string BundleNo { get; set; }
        public string Container { get; set; }
    }
}