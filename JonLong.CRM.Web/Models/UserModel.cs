using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JonLong.CRM.Models;

namespace JonLong.CRM.Web.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.Roles = new List<Role>();
            this.UserRoles = new List<int>();
        }
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public List<int> UserRoles { get; set; }
    }
}