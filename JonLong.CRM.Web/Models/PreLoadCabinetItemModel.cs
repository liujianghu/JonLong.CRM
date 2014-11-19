using JonLong.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class PreLoadCabinetItemModel
    {
        public PreLoadCabinet Origin { get; set; }

        public PreLoadCabinet Loaded { get; set; }

        public PreLoadCabinet Loading { get; set; }
    }
}