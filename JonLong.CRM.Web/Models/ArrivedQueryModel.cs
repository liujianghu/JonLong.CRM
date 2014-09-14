using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class ArrivedQueryModel
    {
        public ArrivedQueryModel()
        {
            this.BundleNo = "";
            this.Container = "";
        }
        public DateTime StartETD { get; set; }
        public DateTime EndETD { get; set; }
        public string BundleNo { get; set; }
        public string Container { get; set; }
    }
}