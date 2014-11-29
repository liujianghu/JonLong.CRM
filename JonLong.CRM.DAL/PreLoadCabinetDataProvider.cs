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
        public static Tuple<List<PreLoadCabinet>, List<PreLoadCabinet>> LoadAviailable(string customerCode, string mbn = "")
        {
            var list = new List<PreLoadCabinet>();
            var list2 = new List<PreLoadCabinet>();
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;
            parameters[1] = new SqlParameter("@mBn", SqlDbType.VarChar);
            parameters[1].Value = customerCode;
            parameters[2] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[2].Size = 32;
            parameters[2].Direction = ParameterDirection.InputOutput;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "spr_calc_yzk"
                , parameters))
            {
                while (reader.Read())
                {
                    var cabinet = new PreLoadCabinet();

                    //cabinet.ModelNo = reader.GetString(3);
                    //cabinet.XHB = reader.GetString(4);
                    //cabinet.SendDate = reader.GetDateTime(1);
                    //cabinet.BanderNo = reader.GetString(2);
                    //cabinet.XHB = reader.IsDBNull(4)?"":reader.GetString(4);
                    //cabinet.Total = reader.GetInt32(5);
                    //cabinet.Size1 = reader.GetInt32(6);
                    //cabinet.Size2 = reader.GetInt32(7);
                    //cabinet.Size3 = reader.GetInt32(8);
                    //cabinet.Size4 = reader.GetInt32(9);
                    //cabinet.Size5 = reader.GetInt32(10);
                    //cabinet.Size6 = reader.GetInt32(11);
                    //cabinet.Size7 = reader.GetInt32(12);
                    //cabinet.Size8 = reader.GetInt32(13);
                    //cabinet.Size9 = reader.GetInt32(14);
                    //cabinet.Size10 = reader.GetInt32(15);
                    //cabinet.Size11 = reader.GetInt32(16);
                    //cabinet.Size12 = reader.GetInt32(17);
                    //cabinet.Size13 = reader.GetInt32(18);
                    //cabinet.Size14 = reader.GetInt32(19);
                    //cabinet.Size15 = reader.GetInt32(20);
                    //cabinet.Size16 = reader.GetInt32(21);
                    //cabinet.Size17 = reader.GetInt32(22);
                    //cabinet.Size18 = reader.GetInt32(23);
                    //cabinet.Size19 = reader.GetInt32(24);
                    //cabinet.Size20 = reader.GetInt32(25);
                    cabinet.Id = reader.GetInt32(0);
                    cabinet.WcSta = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                    {
                        cabinet.SendDate = reader.GetDateTime(2);
                    }

                    cabinet.BanderNo = reader.GetString(3);
                    cabinet.ModelNo = reader.GetString(4);
                    cabinet.XHB = reader.IsDBNull(5) ? "" : reader.GetString(5);

                    cabinet.Total = reader.GetInt32(8);

                    cabinet.Size1 = reader.GetInt32(9);
                    cabinet.Size2 = reader.GetInt32(10);
                    cabinet.Size3 = reader.GetInt32(11);
                    cabinet.Size4 = reader.GetInt32(12);
                    cabinet.Size5 = reader.GetInt32(13);
                    cabinet.Size6 = reader.GetInt32(14);
                    cabinet.Size7 = reader.GetInt32(15);
                    cabinet.Size8 = reader.GetInt32(16);
                    cabinet.Size9 = reader.GetInt32(17);
                    cabinet.Size10 = reader.GetInt32(18);
                    cabinet.Size11 = reader.GetInt32(19);
                    cabinet.Size12 = reader.GetInt32(20);
                    cabinet.Size13 = reader.GetInt32(21);
                    cabinet.Size14 = reader.GetInt32(22);
                    cabinet.Size15 = reader.GetInt32(23);
                    cabinet.Size16 = reader.GetInt32(24);
                    cabinet.Size17 = reader.GetInt32(25);
                    cabinet.Size18 = reader.GetInt32(26);
                    cabinet.Size19 = reader.GetInt32(27);
                    cabinet.Size20 = reader.GetInt32(28);

                    list.Add(cabinet);
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        var cabinet1 = new PreLoadCabinet();
                        cabinet1.Id = reader.GetInt32(0);
                        cabinet1.WcSta = reader.GetInt32(1);
                        if (!reader.IsDBNull(2))
                        {
                            cabinet1.SendDate = reader.GetDateTime(2);
                        }

                        cabinet1.BanderNo = reader.GetString(3);
                        cabinet1.ModelNo = reader.GetString(4);
                        cabinet1.XHB = reader.IsDBNull(5) ? "" : reader.GetString(5);

                        cabinet1.Total = reader.GetInt32(8);

                        cabinet1.Size1 = reader.GetInt32(9);
                        cabinet1.Size2 = reader.GetInt32(10);
                        cabinet1.Size3 = reader.GetInt32(11);
                        cabinet1.Size4 = reader.GetInt32(12);
                        cabinet1.Size5 = reader.GetInt32(13);
                        cabinet1.Size6 = reader.GetInt32(14);
                        cabinet1.Size7 = reader.GetInt32(15);
                        cabinet1.Size8 = reader.GetInt32(16);
                        cabinet1.Size9 = reader.GetInt32(17);
                        cabinet1.Size10 = reader.GetInt32(18);
                        cabinet1.Size11 = reader.GetInt32(19);
                        cabinet1.Size12 = reader.GetInt32(20);
                        cabinet1.Size13 = reader.GetInt32(21);
                        cabinet1.Size14 = reader.GetInt32(22);
                        cabinet1.Size15 = reader.GetInt32(23);
                        cabinet1.Size16 = reader.GetInt32(24);
                        cabinet1.Size17 = reader.GetInt32(25);
                        cabinet1.Size18 = reader.GetInt32(26);
                        cabinet1.Size19 = reader.GetInt32(27);
                        cabinet1.Size20 = reader.GetInt32(28);

                        list2.Add(cabinet1);
                    }
                }


            }
            return new Tuple<List<PreLoadCabinet>, List<PreLoadCabinet>>(list, list2);
        }

        public static void Save(PreLoadCabinet info)
        {
            #region Populate Parameters

            SqlParameter[] parameters = new SqlParameter[28];

            parameters[0] = new SqlParameter("@tGuid", SqlDbType.VarChar);
            parameters[0].Value = info.TGuid;

            parameters[1] = new SqlParameter("@fhrq", SqlDbType.DateTime);
            if(info.SendDate > DateTime.Now.AddYears(-10))
            {
                parameters[1].Value = info.SendDate;
            }
            else
            {
                parameters[1].Value = null;
            }

            parameters[2] = new SqlParameter("@bn", SqlDbType.VarChar);
            parameters[2].Value = info.BanderNo;

            parameters[3] = new SqlParameter("@xh", SqlDbType.VarChar);
            parameters[3].Value = info.ModelNo;

            parameters[4] = new SqlParameter("@xhb", SqlDbType.VarChar);
            parameters[4].Value = info.XHB;

            parameters[5] = new SqlParameter("@sumS", SqlDbType.Int);
            parameters[5].Value = info.Total;

            parameters[6] = new SqlParameter("@s1", SqlDbType.Int);
            parameters[6].Value = info.Size1;

            parameters[7] = new SqlParameter("@s2", SqlDbType.Int);
            parameters[7].Value = info.Size2;

            parameters[8] = new SqlParameter("@s3", SqlDbType.Int);
            parameters[8].Value = info.Size3;

            parameters[9] = new SqlParameter("@s4", SqlDbType.Int);
            parameters[9].Value = info.Size4;

            parameters[10] = new SqlParameter("@s5", SqlDbType.Int);
            parameters[10].Value = info.Size5;

            parameters[11] = new SqlParameter("@s6", SqlDbType.Int);
            parameters[11].Value = info.Size6;

            parameters[12] = new SqlParameter("@s7", SqlDbType.Int);
            parameters[12].Value = info.Size7;

            parameters[13] = new SqlParameter("@s8", SqlDbType.Int);
            parameters[13].Value = info.Size8;

            parameters[14] = new SqlParameter("@s9", SqlDbType.Int);
            parameters[14].Value = info.Size9;

            parameters[15] = new SqlParameter("@s10", SqlDbType.Int);
            parameters[15].Value = info.Size10;

            parameters[16] = new SqlParameter("@s11", SqlDbType.Int);
            parameters[16].Value = info.Size11;

            parameters[17] = new SqlParameter("@s12", SqlDbType.Int);
            parameters[17].Value = info.Size12;

            parameters[18] = new SqlParameter("@s13", SqlDbType.Int);
            parameters[18].Value = info.Size13;

            parameters[19] = new SqlParameter("@s14", SqlDbType.Int);
            parameters[19].Value = info.Size14;

            parameters[20] = new SqlParameter("@s15", SqlDbType.Int);
            parameters[20].Value = info.Size15;

            parameters[21] = new SqlParameter("@s16", SqlDbType.Int);
            parameters[21].Value = info.Size16;

            parameters[22] = new SqlParameter("@s17", SqlDbType.Int);
            parameters[22].Value = info.Size17;

            parameters[23] = new SqlParameter("@s18", SqlDbType.Int);
            parameters[23].Value = info.Size18;

            parameters[24] = new SqlParameter("@s19", SqlDbType.Int);
            parameters[24].Value = info.Size19;

            parameters[25] = new SqlParameter("@s20", SqlDbType.Int);
            parameters[25].Value = info.Size20;

            parameters[26] = new SqlParameter("@khdd", SqlDbType.VarChar);
            parameters[26].Value = info.Khdd;

            parameters[27] = new SqlParameter("@khjq", SqlDbType.DateTime);
            parameters[27].Value = info.Khjq;

            #endregion

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                                       , CommandType.StoredProcedure
                                       , "[dbo].[t_sale_yzk_Save]"
                                       , parameters);
        }

        public static void Update(PreLoadCabinet cabinet)
        {
            string sql = @"UPDATE [dbo].[t_sale_yzk]
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
                     WHERE  id = " + cabinet.Id;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }

        public static void Delete(int id)
        {
            string sql = @"DELETE FROM [dbo].[t_sale_yzk] where [id]=" + id;

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
            parameters[3].Scale = 4;

            parameters[4] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[4].Size = 32;
            parameters[4].Direction = ParameterDirection.InputOutput;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.StoredProcedure, "spr_calc_yzkBfb", parameters);
            float filled = 0;

            float.TryParse(parameters[3].Value.ToString(), out filled);
            filled = filled;

            return filled;

        }

        public static CabinetTitle LoadTitle(string khbh)
        {
            string sql = "select top 1 * from t_sale_yzkM where khbh='" + khbh + "'  order by updateTime desc";
            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    var entity = new CabinetTitle();
                    if (!reader.IsDBNull(0))
                    {
                        entity.Id = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        entity.TGuid = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        entity.Khbh = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        entity.Fhrq = reader.GetDateTime(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        entity.Bn = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        entity.Gzlx = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        entity.Bfb = reader.GetDecimal(6);
                    }

                    return entity;
                }
            }

            return null;
        }

        public static string Confirm(string tguid, string khh, DateTime? fhrq, string userName, string gz)
        {
            #region Populate Parameters

            SqlParameter[] parameters = new SqlParameter[6];

            parameters[0] = new SqlParameter("@tGuid", SqlDbType.VarChar);
            parameters[0].Value = tguid;

            parameters[1] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[1].Value = khh;

            parameters[2] = new SqlParameter("@fhrq", SqlDbType.DateTime);
            parameters[2].Value = fhrq;

            parameters[3] = new SqlParameter("@userName", SqlDbType.VarChar);
            parameters[3].Value = userName;

            parameters[4] = new SqlParameter("@gz", SqlDbType.VarChar);
            parameters[4].Value = gz;

            parameters[5] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Size = 500;

            #endregion

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                                       , CommandType.StoredProcedure
                                       , "[dbo].[spr_khys_qryzk]"
                                       , parameters);

            return parameters[5].Value.ToString();
        }

        public static void UpdateBfb(string guid, double bfb)
        {
            string sql = "UPDATE dbo.t_sale_yzkM SET bfb = " + bfb + " WHERE tGuid = '" + guid + "';";
            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }

        public static List<string> LoadBandno(string khbh)
        {
            var list = new List<string>();
            string sql = "select top 3 banderNo from t_sale_khyslist where  khbh='" + khbh + "' ;";
            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }

            return list;
        }
    }
}
