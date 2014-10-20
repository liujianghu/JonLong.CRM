using JonLong.CRM.Models;
using JonLong.CRM.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JonLong.CRM.DAL
{
    public class UserDataProvider
    {
        public static Tuple<List<User>,List<UserRoleInfo>> LoadUserList(string loginName = "")
        {
            var list = new List<User>();
            var roles = new List<UserRoleInfo>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@LoginName", SqlDbType.VarChar);
            parameters[0].Value = loginName;
            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_Sys_User_LoadAll"
                , parameters))
            {
                while (reader.Read())
                {
                    var user = new User();
                    user.UserId = reader.GetInt32(0);
                    user.LoginName = reader.GetString(1);
                    user.CustomerCode = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    user.PasswordPrompt = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    user.IsContractCustomer = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                    user.Email = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    list.Add(user);
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        roles.Add(new UserRoleInfo{
                            RoleName = reader.GetString(1),
                            UserId = reader.GetInt32(2)
                        });
                    }
                }
            }

            return new Tuple<List<User>, List<UserRoleInfo>>(list, roles);
        }

        public static User Login(string loginName, string password)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@LoginName", SqlDbType.VarChar);
            parameters[0].Value = loginName;

            parameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            parameters[1].Value = password;

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_Sys_User_Login"
                , parameters))
            {
                if (reader.Read())
                {
                    var user = new User();
                    user.UserId = reader.GetInt32(0);
                    user.LoginName = reader.GetString(1);
                    user.CustomerCode = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    user.CustomerName = reader.IsDBNull(3) ? "" : reader.GetString(3);

                    return user;
                }
            }

            return null;
        }

        public static User LoadById(int userId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UserId", SqlDbType.Int);
            parameters[0].Value = userId;

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
               , CommandType.StoredProcedure
               , "t_sys_User_LoadById"
               , parameters))
            {
                if (reader.Read())
                {
                    var user = new User();
                    user.UserId = reader.GetInt32(0);
                    user.LoginName = reader.GetString(1);
                    user.CustomerCode = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    user.PasswordPrompt = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    user.IsContractCustomer = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                    user.Email = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    return user;
                }
            }

            return null;

        }

        public static List<Role> LoadUserRole(int userId)
        {
            var list = new List<Role>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UserId", SqlDbType.Int);
            parameters[0].Value = userId;

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
               , CommandType.StoredProcedure
               , "t_UserRole_LoadByUserId"
               , parameters))
            {
                while (reader.Read())
                {
                    list.Add(new Role
                    {
                        RoleId = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            return list;
        }

        public static List<string> LoadUserPermissions(int userId)
        {
            var list = new List<string>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UserId", SqlDbType.Int);
            parameters[0].Value = userId;

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
               , CommandType.StoredProcedure
               , "dbo.t_UserRole_LoadUserPermssions"
               , parameters))
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }

            return list;
        }

        public static void SaveUserRole(int userId, string roles)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@UserId", SqlDbType.Int);
            parameters[0].Value = userId;
            parameters[1] = new SqlParameter("@Roles", SqlDbType.VarChar);
            parameters[1].Value = roles;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                 , CommandType.StoredProcedure
                 , "t_UserRole_Save"
                 , parameters);
            
        }

        public static void UpdatePassword(int userId, string password)
        {
            string sql = @"UPDATE [jncrm].[dbo].[t_Sys_User]
                         SET [Password] = '"+password+@"'
                         WHERE [UserId] = "+ userId+";";

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }

        public static string LoadCustomerCodeByName(string name)
        {
            string sql = "SELECT t.Kh_bh FROM dbo.t_bas_kh AS t WITH (NOLOCK) where ";
            sql += " t.Kh_jc = '"+name+"'";
            sql += " OR t.Kh_mc = '"+name+"';";

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        return reader.GetString(0);
                    }
                }
            }

            return String.Empty;
        }

    }
}
