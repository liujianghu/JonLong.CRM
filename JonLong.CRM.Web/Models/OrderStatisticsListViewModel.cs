using JonLong.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JonLong.CRM.Web.Models
{
    public class OrderStatisticsListViewModel
    {
        public OrderStatisticsListViewModel()
        {
            this.Items = new List<OrderStatistics>();
        }
        public List<OrderStatistics> Items
        {
            get;
            set;
        }

        public string ETDFrom { get; set; }
        public string ETDTo { get; set; }
        public string BundleNo { get; set; }
        public string ContainerNo { get; set; }

    }
}