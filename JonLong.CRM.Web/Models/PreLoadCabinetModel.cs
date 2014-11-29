using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class PreLoadCabinetModel
    {
        public PreLoadCabinetModel()
        {
            this.SavedTotal = new PreLoadCabinetTotalModel();
            this.SavedItems = new List<PreLoadCabinet>();
        }

        public List<string> Bandnos { get; set; }

        public List<PreLoadCabinet> SavedItems { get; set; }
        public PreLoadCabinetTotalModel SavedTotal { get; set; }
        public Dictionary<string, PreLoadCabinetItemModel> Items { get; set; }

        public List<string> ShoeSizes { get; set; }

        public string Guid { get; set; }

        public CabinetTitle Title { get; set; }
    }
}