using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.DAL;
using JonLong.CRM.Models;

namespace JonLong.CRM.BLL
{
    public class RoleManager
    {
        protected RoleManager() { }

        public static readonly RoleManager Instance = new RoleManager();

        public bool IsAdmin(string userId)
        {
            return true;
        }

        public bool Insert(string name, List<string> permissions)
        {
            if (String.IsNullOrEmpty(name))
            {
                return false;
            }
            string permissionStr = String.Empty;
            if (permissions != null && permissions.Any())
            {
                permissionStr = String.Join(",", permissions.ToArray());
            }
            
            RoleDataProvider.Insert(name, permissionStr);

            return true;
        }

        public bool Update(Role role)
        {
            if (role == null || role.RoleId == 0 || String.IsNullOrEmpty(role.Name))
            {
                return false;
            }

            RoleDataProvider.Update(role);

            return true;
        }

        public bool Delete(int roleId)
        {
            if (roleId <= 0)
            {
                return false;
            }

            RoleDataProvider.Delete(roleId);
            return true;
        }

        public List<Role> LoadAll()
        {
            return RoleDataProvider.LoadAll();
        }

        public Role LoadById(int roleId)
        {
            return RoleDataProvider.LoadById(roleId);
        }

        public List<Permission> LoadAllPermissions()
        {
            return UserDataProvider.LoadAllPermissions();
        }

    }
}
