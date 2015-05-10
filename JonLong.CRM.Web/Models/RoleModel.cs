using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.Utilities;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class RoleModel
    {
        public RoleModel()
        {
            this.SelectedPermissions = new List<string>();
            this.Permissions = new Dictionary<string, List<Permission>>();
        }
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
        
        public Dictionary<string,List<Permission>> Permissions { get; set; }
        public List<string> SelectedPermissions { get; set; }
    }
}