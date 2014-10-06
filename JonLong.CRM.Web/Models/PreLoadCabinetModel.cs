using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class PreLoadCabinetModel
    {
        public List<PreLoadCabinet> Items { get; set; }

        public List<string> ShoeSizes { get; set; }

        public string Guid { get; set; }
    }
}