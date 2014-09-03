using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public List<int> UserRoles { get; set; }
    }
}