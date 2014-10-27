using System;
using System.Collections.Generic;
using System.Linq;
using JonLong.CRM.Models;
using JonLong.CRM.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace JonLong.CRM.DAL
{
    public class PreLoadCabinetDataProvider
    {
        public static List<PreLoadCabinet> LoadAviailable(string customerCode)
        {
            var list = new List<PreLoadCabinet>();
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;
            parameters[1] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[1].Size = 32;
            parameters[1].Direction = ParameterDirection.InputOutput;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "spr_calc_yzk"
                , parameters))
            {
                while (reader.Read())
                {
                    var cabinet = new PreLoadCabinet();
                    cabinet.ModelNo = reader.GetString(3);
                    cabinet.SendDate = reader.GetDateTime(1);
                    cabinet.BanderNo = reader.GetString(2);
                    cabinet.XHB = reader.IsDBNull(4)?"":reader.GetString(4);
                    cabinet.Total = reader.GetInt32(5);
                    cabinet.Size1 = reader.GetInt32(6);
                    cabinet.Size2 = reader.GetInt32(7);
                    cabinet.Size3 = reader.GetInt32(8);
                    cabinet.Size4 = reader.GetInt32(9);
                    cabinet.Size5 = reader.GetInt32(10);
                    cabinet.Size6 = reader.GetInt32(11);
                    cabinet.Size7 = reader.GetInt32(12);
                    cabinet.Size8 = reader.GetInt32(13);
                    cabinet.Size9 = reader.GetInt32(14);
                    cabinet.Size10 = reader.GetInt32(15);
                    cabinet.Size11 = reader.GetInt32(16);
                    cabinet.Size12 = reader.GetInt32(17);
                    cabinet.Size13 = reader.GetInt32(18);
                    cabinet.Size14 = reader.GetInt32(19);
                    cabinet.Size15 = reader.GetInt32(20);
                    cabinet.Size16 = reader.GetInt32(21);
                    cabinet.Size17 = reader.GetInt32(22);
                    cabinet.Size18 = reader.GetInt32(23);
                    cabinet.Size19 = reader.GetInt32(24);
                    cabinet.Size20 = reader.GetInt32(25);

                    list.Add(cabinet);
                }

                return list;
            }

        }

        public static int Insert(PreLoadCabinet cabinet)
        {
            string sql = @"INSERT INTO [jncrm].[dbo].[t_sale_yzk]
                           ([tGuid]
                           ,[fhrq]
                           ,[bn]
                           ,[xh]
                           ,[xhb]
                           ,[sumS]
                           ,[s1]
                           ,[s2]
                           ,[s3]
                           ,[s4]
                           ,[s5]
                           ,[s6]
                           ,[s7]
                           ,[s8]
                           ,[s9]
                           ,[s10]
                           ,[s11]
                           ,[s12]
                           ,[s13]
                           ,[s14]
                           ,[s15]
                           ,[s16]
                           ,[s17]
                           ,[s18]
                           ,[s19]
                           ,[s20])
                     VALUES
                           ('"+cabinet.TGuid+@"'
                           ,'" + cabinet.SendDate + @"'
                           ,'" + cabinet.BanderNo + @"'
                           ,'" + cabinet.ModelNo + @"'
                           ,'" + cabinet.XHB + @"'
                           ," + cabinet.Total + @"
                           ," + cabinet.Size1 + @"
                           ," + cabinet.Size2 + @"
                           ," + cabinet.Size3 + @"
                            ," + cabinet.Size4 + @"
                            ," + cabinet.Size5 + @"
                            ," + cabinet.Size6 + @"
                            ," + cabinet.Size7 + @"
                            ," + cabinet.Size8 + @"
                            ," + cabinet.Size9 + @"
                            ," + cabinet.Size10 + @"
                            ," + cabinet.Size11 + @"
                            ," + cabinet.Size12 + @"
                            ," + cabinet.Size13 + @"
                            ," + cabinet.Size14 + @"
                            ," + cabinet.Size15 + @"
                            ," + cabinet.Size16 + @"
                            ," + cabinet.Size17 + @"
                            ," + cabinet.Size18 + @"
                            ," + cabinet.Size19 + @"
                           ," + cabinet.Size20 + ") ";
            sql += " SET @Id = SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Direction = ParameterDirection.InputOutput;
                
            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql,parameters);

            int id = 0;
            int.TryParse(parameters[0].Value.ToString(), out id);
            return id;
        }

        public static void Update(PreLoadCabinet cabinet)
        {
            string sql = @"UPDATE [jncrm].[dbo].[t_sale_yzk]
                       SET [sumS] = "+cabinet.Total+@"
                          ,[s1] = "+cabinet.Size1+@"
                          ,[s2] = " + cabinet.Size2 + @"
                            ,[s3] = " + cabinet.Size3 + @"
                            ,[s4] = " + cabinet.Size4 + @"
                            ,[s5] = " + cabinet.Size5 + @"
                            ,[s6] = " + cabinet.Size6 + @"
                            ,[s7] = " + cabinet.Size7 + @"
                            ,[s8] = " + cabinet.Size8 + @"
                            ,[s9] = " + cabinet.Size9 + @"
                            ,[s10] = " + cabinet.Size10 + @"
                            ,[s11] = " + cabinet.Size11 + @"
                            ,[s12] = " + cabinet.Size12 + @"
                            ,[s13] = " + cabinet.Size13 + @"
                            ,[s14] = " + cabinet.Size14 + @"
                            ,[s15] = " + cabinet.Size15 + @"
                            ,[s16] = " + cabinet.Size16 + @"
                            ,[s17] = " + cabinet.Size17 + @"
                            ,[s18] = " + cabinet.Size18 + @"
                            ,[s19] = " + cabinet.Size19 + @"
                            ,[s20] = " + cabinet.Size20 + @"
                     WHERE  id = " +cabinet.Id;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }

        public static void Delete(int id)
        {
            string sql = @"DELETE FROM [jncrm].[dbo].[t_sale_yzk] where [id]=" + id;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }

        public static float GetFilled(string customerCode, string guid, string containerNo)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;
            parameters[1] = new SqlParameter("@guid", SqlDbType.VarChar);
            parameters[1].Value = guid;
            parameters[2] = new SqlParameter("@gzlx", SqlDbType.VarChar);
            parameters[2].Value = containerNo;

            parameters[3] = new SqlParameter("@bfb", SqlDbType.Float);
            parameters[3].Direction = ParameterDirection.InputOutput;

            parameters[4] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[4].Size = 32;
            parameters[4].Direction = ParameterDirection.InputOutput;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.StoredProcedure, "spr_calc_yzkBfb", parameters);
            float filled = 0;

            float.TryParse(parameters[3].Value.ToString(), out filled);
            filled = filled;

            return filled;

        }
    }
}
