using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonLong.CRM.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public List<int> Roles { get; set; }
    }
}
