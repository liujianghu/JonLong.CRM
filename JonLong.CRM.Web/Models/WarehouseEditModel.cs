using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class WarehouseEditModel
    {
        public WarehouseEditModel()
        {
            this.Detail = new Warehouse();
            
        }

        public List<string> ShoeSizes { get; set; }

        public Dictionary<string, string> Shoes { get; set; }

        public Warehouse Detail { get; set; }
    }
}