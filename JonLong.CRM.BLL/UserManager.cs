using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.DAL;
using JonLong.CRM.Models;

namespace JonLong.CRM.BLL
{
    public class UserManager
    {
        protected UserManager() { }
        public static readonly UserManager Instance = new UserManager();

        public List<User> LoadUserList(string loginName)
        {
            var tuple = UserDataProvider.LoadUserList(loginName);
            var list = tuple.Item1;
            foreach (var item in list)
            {
                item.Roles = String.Join(",", tuple.Item2.Where(t => t.UserId == item.UserId).Select(t=>t.RoleName).ToArray());
            }
            return list;
        }

        public User Login(string loginName, string password)
        {
            if (String.IsNullOrEmpty(loginName)
                || String.IsNullOrEmpty(password))
            {
                return null;
            }

            return UserDataProvider.Login(loginName, password);

        }

        public User LoadById(int userId)
        {
            return UserDataProvider.LoadById(userId);
        }

        public List<Role> LoadUserRole(int userId)
        {
            return UserDataProvider.LoadUserRole(userId);
        }

        public List<string> LoadUserPermissions(int userId)
        {
            return UserDataProvider.LoadUserPermissions(userId);
        }

        public void SaveUserRoles(int userId, List<int> roleIds)
        {
            if (userId <=0)
            {
                return;
            }

            string roles = String.Empty;

            if (roleIds != null)
            {
                roles = String.Join(",", roleIds);
            }

            UserDataProvider.SaveUserRole(userId, roles);

        }
        

    }
}
