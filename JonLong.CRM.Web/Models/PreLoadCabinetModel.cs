using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class PreLoadCabinetModel
    {
        public List<PreLoadCabinet> SavedItems { get; set; }
        public Dictionary<string, PreLoadCabinetItemModel> Items { get; set; }

        public List<string> ShoeSizes { get; set; }

        public string Guid { get; set; }

        public CabinetTitle Title { get; set; }
    }
}