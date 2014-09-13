using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class EnrouteListViewModel
    {
        public List<Enroute> Enroutes { get; set; }

        public bool IsSuperAdmin { get; set; }
    }
}