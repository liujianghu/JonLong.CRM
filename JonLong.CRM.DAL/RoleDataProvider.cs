using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.Utilities;
using JonLong.CRM.Models;

namespace JonLong.CRM.DAL
{
    public class RoleDataProvider
    {
        public static void Insert(string name, string permissions)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@RoleName", SqlDbType.VarChar);
            parameters[0].Value = name;

            parameters[1] = new SqlParameter("@Permissions", SqlDbType.VarChar);
            parameters[1].Value = permissions;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_Role_Insert"
                , parameters);
        }

        public static List<Role> LoadAll()
        {
            var list = new List<Role>();
            using (var reader = SqlHelper.ExecuteReader(
                  ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_Role_LoadAll"))
            {
                while (reader.Read())
                {
                    list.Add(new Role
                        {
                            RoleId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            InsertDate = reader.GetDateTime(2)
                        });
                }
            }
            return list;
        }

        public static void Update(Role role)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@RoleId", SqlDbType.Int);
            parameters[0].Value = role.RoleId;
            parameters[1] = new SqlParameter("@RoleName", SqlDbType.VarChar);
            parameters[1].Value = role.Name;
            parameters[2] = new SqlParameter("@Permissions", SqlDbType.VarChar);
            if (role.Permissions != null && role.Permissions.Any())
            {
                parameters[2].Value = String.Join(",", role.Permissions.ToArray());
            }
            else
            {
                parameters[2].Value = String.Empty;
            }
            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_Role_Update"
                , parameters);
        }

        public static void Delete(int roleId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@RoleId", SqlDbType.Int);
            parameters[0].Value = roleId;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_Role_Delete"
                , parameters);
        }

        public static Role LoadById(int roleId)
        {
            Role role = null;

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@RoleId", SqlDbType.Int);
            parameters[0].Value = roleId;

            using (var reader = SqlHelper.ExecuteReader(
                  ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_Role_LoadById"
                , parameters))
            {
                
                if (reader.Read())
                {
                    role = new Role
                    {
                        RoleId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        InsertDate = reader.GetDateTime(2)
                    };
                }

                if (role != null && reader.NextResult())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        }
                        role.Permissions.Add(reader.GetInt32(0).ToString());
                    }
                }

                return role;
                
            }

        }

    }
}
