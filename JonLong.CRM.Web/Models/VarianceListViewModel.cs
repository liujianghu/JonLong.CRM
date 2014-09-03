using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class VarianceListViewModel
    {
        public List<OrderVarianceModel> Variances { get; set; }
    }
}