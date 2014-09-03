using System;
using System.Collections.Generic;
using System.Linq;
using JonLong.CRM.Models;
using JonLong.CRM.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace JonLong.CRM.DAL
{
    public static class OrderDataProvider
    {
        public static List<OrderStatistics> LoadOrderStatistics(
              string customerCode
            , DateTime sendDateFrom
            , DateTime sendDateTo
            , string banderNo
            , string containerNo)
        {
            var list = new List<OrderStatistics>();
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@khbh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;
            parameters[1] = new SqlParameter("@SendDateFrom", SqlDbType.Date);
            parameters[1].Value = sendDateFrom;
            parameters[2] = new SqlParameter("@SendDateTo", SqlDbType.Date);
            parameters[2].Value = sendDateTo;
            parameters[3] = new SqlParameter("@banderNo", SqlDbType.VarChar);
            parameters[3].Value = banderNo;
            parameters[4] = new SqlParameter("@container", SqlDbType.VarChar);
            parameters[4].Value = containerNo;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_sale_khys_Load"
                , parameters))
            {
                while (reader.Read())
                {
                    var statistic = new OrderStatistics();
                    statistic.SendDate = reader.GetDateTime(0);
                    statistic.BanderNo = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    statistic.ContainerType = reader.GetString(2);
                    statistic.ContainerNo = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        statistic.Filled = Convert.ToDouble(reader.GetDecimal(4));
                    }
                    statistic.CustomerCode = reader.GetString(5);

                    statistic.Complete = Convert.ToDouble(reader.GetDecimal(6));
                    statistic.ContainerSum = reader.GetInt32(7);
                    statistic.Id = reader.GetInt32(8);
                    if (!reader.IsDBNull(9))
                    {
                        statistic.ChangeDate = reader.GetDateTime(9);
                    }
                    statistic.ContractNo = reader.GetString(11);
                    statistic.HTBH = reader.GetString(12);

                    list.Add(statistic);
                }


                return list;
            }
        }

        public static List<Order> LoadStatisticsDetail(
              DateTime sendDate
            , string customerCode
            , string bundlerNo
            , string containerType
            , string container)
        {

            var list = new List<Order>();
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@fhrq", SqlDbType.Date);
            parameters[0].Value = sendDate;
            parameters[1] = new SqlParameter("@khbh", SqlDbType.VarChar);
            parameters[1].Value = customerCode;
            parameters[2] = new SqlParameter("@bundleNo", SqlDbType.VarChar);
            parameters[2].Value = bundlerNo;
            parameters[3] = new SqlParameter("@khys_gz", SqlDbType.VarChar);
            parameters[3].Value = containerType;
            parameters[4] = new SqlParameter("@Container", SqlDbType.VarChar);
            parameters[4].Value = container;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_sale_khys_LoadDetail"
                , parameters))
            {
                while (reader.Read())
                {
                    var order = new Order();
                    order.Id = reader.GetInt32(0);
                    order.ModelNo = reader.GetString(1);
                    order.SendDate = reader.GetDateTime(2);
                    order.BanderNo = reader.GetString(3);
                    order.ContainerType = reader.GetString(4);
                    order.Total = reader.GetInt32(5);
                    order.Size1 = reader.GetInt32(6);
                    order.Size2 = reader.GetInt32(7);
                    order.Size3 = reader.GetInt32(8);
                    order.Size4 = reader.GetInt32(9);
                    order.Size5 = reader.GetInt32(10);
                    order.Size6 = reader.GetInt32(11);
                    order.Size7 = reader.GetInt32(12);
                    order.Size8 = reader.GetInt32(13);
                    order.Size9 = reader.GetInt32(14);
                    order.Size10 = reader.GetInt32(15);
                    order.Size11 = reader.GetInt32(16);
                    order.Size12 = reader.GetInt32(17);
                    order.Size13 = reader.GetInt32(18);
                    order.Size14 = reader.GetInt32(19);
                    order.Size15 = reader.GetInt32(20);
                    order.Size16 = reader.GetInt32(21);
                    order.Size17 = reader.GetInt32(22);
                    order.Size18 = reader.GetInt32(23);
                    order.Size19 = reader.GetInt32(24);
                    order.Size20 = reader.GetInt32(25);

                    if (!reader.IsDBNull(34))
                    {
                        order.OriginalETD = reader.GetDateTime(34);
                    }

                    list.Add(order);
                }

                return list;
            }


        }

        public static Order LoadOrderById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_sale_khys_LoadById"
                , parameters))
            {
                if (reader.Read())
                {
                    var order = new Order();
                    order.Id = reader.GetInt32(0);
                    order.ModelNo = reader.GetString(1);
                    order.SendDate = reader.GetDateTime(2);
                    order.BanderNo = reader.GetString(3);
                    order.ContainerType = reader.GetString(4);
                    order.Total = reader.GetInt32(5);
                    order.Size1 = reader.GetInt32(6);
                    order.Size2 = reader.GetInt32(7);
                    order.Size3 = reader.GetInt32(8);
                    order.Size4 = reader.GetInt32(9);
                    order.Size5 = reader.GetInt32(10);
                    order.Size6 = reader.GetInt32(11);
                    order.Size7 = reader.GetInt32(12);
                    order.Size8 = reader.GetInt32(13);
                    order.Size9 = reader.GetInt32(14);
                    order.Size10 = reader.GetInt32(15);
                    order.Size11 = reader.GetInt32(16);
                    order.Size12 = reader.GetInt32(17);
                    order.Size13 = reader.GetInt32(18);
                    order.Size14 = reader.GetInt32(19);
                    order.Size15 = reader.GetInt32(20);
                    order.Size16 = reader.GetInt32(21);
                    order.Size17 = reader.GetInt32(22);
                    order.Size18 = reader.GetInt32(23);
                    order.Size19 = reader.GetInt32(24);
                    order.Size20 = reader.GetInt32(25);

                    if (!reader.IsDBNull(34))
                    {
                        order.OriginalETD = reader.GetDateTime(34);
                    }
                    order.ContractNo = reader.GetString(36);
                    order.CustomerCode = reader.GetString(37);
                    return order;
                }
            }
            return null;
        }

        public static string UpdateOrder(Order order, string loginName)
        {
            SqlParameter[] parameters = new SqlParameter[29];
            parameters[0] = new SqlParameter("@id", SqlDbType.Int);
            parameters[0].Value = order.Id;
            parameters[1] = new SqlParameter("@fhrq", SqlDbType.DateTime);
            parameters[1].Value = order.SendDate;
            parameters[2] = new SqlParameter("@bundleNo", SqlDbType.VarChar);
            parameters[2].Value = order.BanderNo;
            parameters[3] = new SqlParameter("@gz", SqlDbType.VarChar);
            parameters[3].Value = order.ContainerType;
            parameters[4] = new SqlParameter("@gh", SqlDbType.VarChar);
            parameters[4].Value = String.Empty;
            parameters[5] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[5].Value = order.CustomerCode;
            parameters[6] = new SqlParameter("@s1", SqlDbType.Int);
            parameters[6].Value = order.Size1;
            parameters[7] = new SqlParameter("@s2", SqlDbType.Int);
            parameters[7].Value = order.Size2;
            parameters[8] = new SqlParameter("@s3", SqlDbType.Int);
            parameters[8].Value = order.Size3;
            parameters[9] = new SqlParameter("@s4", SqlDbType.Int);
            parameters[9].Value = order.Size4;
            parameters[10] = new SqlParameter("@s5", SqlDbType.Int);
            parameters[10].Value = order.Size5;
            parameters[11] = new SqlParameter("@s6", SqlDbType.Int);
            parameters[11].Value = order.Size6;
            parameters[12] = new SqlParameter("@s7", SqlDbType.Int);
            parameters[12].Value = order.Size7;
            parameters[13] = new SqlParameter("@s8", SqlDbType.Int);
            parameters[13].Value = order.Size8;
            parameters[14] = new SqlParameter("@s9", SqlDbType.Int);
            parameters[14].Value = order.Size9;
            parameters[15] = new SqlParameter("@s10", SqlDbType.Int);
            parameters[15].Value = order.Size10;
            parameters[16] = new SqlParameter("@s11", SqlDbType.Int);
            parameters[16].Value = order.Size11;
            parameters[17] = new SqlParameter("@s12", SqlDbType.Int);
            parameters[17].Value = order.Size12;
            parameters[18] = new SqlParameter("@s13", SqlDbType.Int);
            parameters[18].Value = order.Size13;
            parameters[19] = new SqlParameter("@s14", SqlDbType.Int);
            parameters[19].Value = order.Size14;
            parameters[20] = new SqlParameter("@s15", SqlDbType.Int);
            parameters[20].Value = order.Size15;
            parameters[21] = new SqlParameter("@s16", SqlDbType.Int);
            parameters[21].Value = order.Size16;
            parameters[22] = new SqlParameter("@s17", SqlDbType.Int);
            parameters[22].Value = order.Size17;
            parameters[23] = new SqlParameter("@s18", SqlDbType.Int);
            parameters[23].Value = order.Size18;
            parameters[24] = new SqlParameter("@s19", SqlDbType.Int);
            parameters[24].Value = order.Size19;
            parameters[25] = new SqlParameter("@s20", SqlDbType.Int);
            parameters[25].Value = order.Size20;
            parameters[26] = new SqlParameter("@userName", SqlDbType.VarChar);
            parameters[26].Value = loginName;
            parameters[27] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[27].Size = 500;
            parameters[27].Direction = ParameterDirection.InputOutput;
            parameters[28] = new SqlParameter("@khdd", SqlDbType.VarChar);
            parameters[28].Value = order.ContractNo;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "spr_khys_update"
                , parameters);

            return parameters[27].Value.ToString();
            
        }

        public static string Delete(int id,string loginName)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@khysID", SqlDbType.Int);
            parameters[0].Value = id;
            parameters[1] = new SqlParameter("@userName", SqlDbType.VarChar);
            parameters[1].Value = loginName;
            parameters[2] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[2].Size = 500;
            parameters[2].Direction = ParameterDirection.InputOutput;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "spr_khys_deleteN"
                , parameters);
            return parameters[2].Value.ToString();
        }

        public static string LoadContainerType(string customerCode, string bundleNo)
        {
            
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;
            parameters[1] = new SqlParameter("@bundleNo", SqlDbType.VarChar);
            parameters[1].Value = bundleNo;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_sale_khys_LoadContainer"
                , parameters))
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        return reader.GetString(0);
                    }
                }
            }

            return String.Empty;
        }

        public static List<string> LoadBundleNos(string customerCode)
        {
            var list = new List<string>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_sale_khys_LoadBundlerNos"
                , parameters))
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(1));
                }
            }

            return list;
        }

        public static string Create(Order order, string loginName)
        {
            SqlParameter[] parameters = new SqlParameter[30];
            parameters[0] = new SqlParameter("@xh", SqlDbType.VarChar);
            parameters[0].Value = order.ModelNo;
            parameters[1] = new SqlParameter("@fhrq", SqlDbType.DateTime);
            parameters[1].Value = order.SendDate;
            parameters[2] = new SqlParameter("@bundleNo", SqlDbType.VarChar);
            parameters[2].Value = order.BanderNo;
            parameters[3] = new SqlParameter("@gz", SqlDbType.VarChar);
            parameters[3].Value = order.ContainerType;
            parameters[4] = new SqlParameter("@gh", SqlDbType.VarChar);
            parameters[4].Value = String.Empty;
            parameters[5] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[5].Value = order.CustomerCode;
            parameters[6] = new SqlParameter("@sl", SqlDbType.Int);
            parameters[6].Value = order.Total;
            parameters[7] = new SqlParameter("@s1", SqlDbType.Int);
            parameters[7].Value = order.Size1;
            parameters[8] = new SqlParameter("@s2", SqlDbType.Int);
            parameters[8].Value = order.Size2;
            parameters[9] = new SqlParameter("@s3", SqlDbType.Int);
            parameters[9].Value = order.Size3;
            parameters[10] = new SqlParameter("@s4", SqlDbType.Int);
            parameters[10].Value = order.Size4;
            parameters[11] = new SqlParameter("@s5", SqlDbType.Int);
            parameters[11].Value = order.Size5;
            parameters[12] = new SqlParameter("@s6", SqlDbType.Int);
            parameters[12].Value = order.Size6;
            parameters[13] = new SqlParameter("@s7", SqlDbType.Int);
            parameters[13].Value = order.Size7;
            parameters[14] = new SqlParameter("@s8", SqlDbType.Int);
            parameters[14].Value = order.Size8;
            parameters[15] = new SqlParameter("@s9", SqlDbType.Int);
            parameters[15].Value = order.Size9;
            parameters[16] = new SqlParameter("@s10", SqlDbType.Int);
            parameters[16].Value = order.Size10;
            parameters[17] = new SqlParameter("@s11", SqlDbType.Int);
            parameters[17].Value = order.Size11;
            parameters[18] = new SqlParameter("@s12", SqlDbType.Int);
            parameters[18].Value = order.Size12;
            parameters[19] = new SqlParameter("@s13", SqlDbType.Int);
            parameters[19].Value = order.Size13;
            parameters[20] = new SqlParameter("@s14", SqlDbType.Int);
            parameters[20].Value = order.Size14;
            parameters[21] = new SqlParameter("@s15", SqlDbType.Int);
            parameters[21].Value = order.Size15;
            parameters[22] = new SqlParameter("@s16", SqlDbType.Int);
            parameters[22].Value = order.Size16;
            parameters[23] = new SqlParameter("@s17", SqlDbType.Int);
            parameters[23].Value = order.Size17;
            parameters[24] = new SqlParameter("@s18", SqlDbType.Int);
            parameters[24].Value = order.Size18;
            parameters[25] = new SqlParameter("@s19", SqlDbType.Int);
            parameters[25].Value = order.Size19;
            parameters[26] = new SqlParameter("@s20", SqlDbType.Int);
            parameters[26].Value = order.Size20;
            parameters[27] = new SqlParameter("@userName", SqlDbType.VarChar);
            parameters[27].Value = loginName;
            parameters[28] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[28].Size = 500;
            parameters[28].Direction = ParameterDirection.InputOutput;
            parameters[29] = new SqlParameter("@khdd", SqlDbType.VarChar);
            parameters[29].Value = order.ContractNo;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "spr_khys_insert"
                , parameters);

            return parameters[28].Value.ToString();


        }

        public static string ConvertToOrder(string bundlerNo)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@bn", SqlDbType.VarChar);
            parameters[0].Value = bundlerNo;
            parameters[1] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[1].Size = 100;
            parameters[1].Direction = ParameterDirection.InputOutput;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "spr_auto_zdysht"
                , parameters);

            return parameters[1].Value.ToString();
        }

    }
}
