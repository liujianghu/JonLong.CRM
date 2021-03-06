﻿using JonLong.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class OrderStatisticsViewModel
    {
        public bool IsSuperAdmin { get; set; }
        public List<Order> Orders { get; set; }
        public List<string> ShoeSizes { get; set; }

        public string SendDate { get; set; }

        public string BundleNo { get; set; }

        public string ContainerType { get; set; }

        public int OrderCount { get; set; }
        public int Total { get; set; }
        public int Size1Total { get; set; }
        public int Size2Total { get; set; }
        public int Size3Total { get; set; }
        public int Size4Total { get; set; }
        public int Size5Total { get; set; }
        public int Size6Total { get; set; }
        public int Size7Total { get; set; }
        public int Size8Total { get; set; }
        public int Size9Total { get; set; }
        public int Size10Total { get; set; }
        public int Size11Total { get; set; }
        public int Size12Total { get; set; }
        public int Size13Total { get; set; }
        public int Size14Total { get; set; }
        public int Size15Total { get; set; }
        public int Size16Total { get; set; }
        public int Size17Total { get; set; }
        public int Size18Total { get; set; }
    }
}