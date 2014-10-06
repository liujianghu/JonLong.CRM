using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class PreLoadCabinetEditModel
    {
        public int Id { get; set; }

        public decimal Filled { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}