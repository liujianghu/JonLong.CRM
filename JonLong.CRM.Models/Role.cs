using System;
using System.Collections.Generic;

namespace JonLong.CRM.Models
{
    public class Role
    {
        public Role()
        {
            this.Permissions = new List<string>();
        }
        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<string> Permissions { get; set; }

        public List<int> PermissionIds { get; set; }

        public DateTime InsertDate { get; set; }
    }
}
