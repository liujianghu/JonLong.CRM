using JonLong.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Models
{
    public class UserListViewModel
    {
        public string LoginName { get; set; }
        public UserListViewModel()
        {
            this.Users = new List<User>();
        }
        public List<User> Users { get; set; }
    }
}